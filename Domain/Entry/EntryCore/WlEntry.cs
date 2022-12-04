using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using WordLearning.Domain.Aggregate;
using WordLearning.Domain.Entry.Visitors;
using WordLearning.Domain.Transaction;

namespace WordLearning.Domain.Entry.EntryCore
{
    public abstract class WlEntry : WlEntity
    {
        private readonly IDictionary<string, object> _attributes = new Dictionary<string, object>();

        public WlEntry()
        {
        }

        protected WlDirectory Parent { get; set; }

        public T GetParent<T>() where T : WlDirectory
        {
            if (Parent is not T)
            {
                throw new InvalidCastException();
            }

            return Parent as T;
        }

        public IAggregateRoot GetRoot()
        {
            var current = this;
            while (current != null && current is not IAggregateRoot)
            {
                current = current.Parent;
            }

            if (current is null)
            {
                throw new InvalidOperationException("集約ルートが見つかりません。");
            }

            return current as IAggregateRoot;
        }

        public int Rank
        {
            get
            {
                int rank = 0;
                WlEntry currentEntry = this;
                while (currentEntry.Parent != null)
                {
                    currentEntry = currentEntry.Parent;
                    rank++;
                }

                return rank;
            }
        }

        private Subject<bool> CheckedChanged { get; } = new();

        public Subject<(string PropertyName, object Value)> PropertyValueChanged { get; } = new();

        public bool IsChecked { get; private set; }

        internal bool IsDisposed { get; private set; }

        internal virtual void DisposeEntry()
        {
            IsDisposed = true;
        }

        internal virtual void RestoreEntry()
        {
            IsDisposed = false;
        }

        public void ChangeSelect()
        {
            Execute(() => ChangeSelectAction(), () => ChangeSelectAction());
        }

        private void ChangeSelectAction()
        {
            if (Parent is not null)
            {
                WlEntry currentSelectedEntry = Parent.CurrentSelectedEntry;
                if (currentSelectedEntry == this)
                {
                    Parent.CurrentSelectedEntry = null;
                }
                else
                {
                    Parent.CurrentSelectedEntry = this;
                }
            }
        }

        public void ChangeCheck()
        {
            Execute(() => ChangeCheckAction(), () => ChangeCheckAction());
        }

        public virtual void ClearCheck()
        {
            if (IsChecked)
            {
                ChangeCheck();
            }
        }

        private void ChangeCheckAction()
        {
            IsChecked = !IsChecked;
            CheckedChanged.OnNext(IsChecked);
        }

        public void MoveTo(WlDirectory destination)
        {
            if (Parent == null)
            {
                throw new InvalidOperationException();
            }

            WlDirectory currentParent = Parent;
            Execute(() => MoveToAction(currentParent), () => MoveToAction(destination));
        }

        internal virtual void MoveToAction(WlDirectory destination)
        {
            DeleteAction();
            AddToAction(destination);
        }

        public virtual void Delete()
        {
            if (Parent == null)
            {
                throw new InvalidOperationException();
            }

            Execute(() => AddToAction(Parent), () => DeleteAction());
        }

        internal virtual void DeleteAction()
        {
            Parent?.Remove(this);
            Parent = null;
            DisposeEntry();
        }

        public void AddTo(WlDirectory destination)
        {
            if (Parent != null)
            {
                throw new InvalidOperationException();
            }

            Execute(() => DeleteAction(), () => AddToAction(destination));
        }

        internal virtual void AddToAction(WlDirectory destination)
        {
            Parent = destination;
            Parent?.Add(this);
            RestoreEntry();
        }

        public void Save(string fileName)
        {
            SaveCore(fileName);
        }

        protected virtual void SaveCore(string fileName)
        {
            Parent.SaveCore(fileName);
        }

        protected void SetValue<T>(T value, [CallerMemberName] string name = "")
        {
            T oldValue = (T)_attributes[name];
            Execute(() => SetValueCore(name, oldValue), () => SetValueCore(name, value));
        }

        protected T GetValue<T>([CallerMemberName] string name = "")
        {
            if (!_attributes.ContainsKey(name))
            {
                _attributes[name] = default(T);
            }

            return (T)_attributes[name];
        }

        private void SetValueCore<T>(string name, T value)
        {
            _attributes[name] = value;
            PropertyValueChanged.OnNext((name, value));
        }

        public IDisposable RegisterCheckedChanged(Action<bool> handler)
        {
            IDisposable currentDisposable = null;

            void registerAction() => currentDisposable = CheckedChanged.Subscribe(handler);
            void disposedAction() => currentDisposable.Dispose();
            Execute(disposedAction, registerAction);
            return Disposable.Create(() => Execute(registerAction, disposedAction));
        }


        public IDisposable RegisterPropertyValueChanged(string propertyName, Action<object> handler)
        {
            IDisposable currentDisposable = null;

            void registerAction() => currentDisposable = PropertyValueChanged
                                                .Where(source => source.PropertyName == propertyName)
                                                .Subscribe(source => handler(source.Value));
            void disposedAction() => currentDisposable.Dispose();
            Execute(disposedAction, registerAction);

            return Disposable.Create(() => Execute(registerAction, disposedAction));
        }

        public virtual void Accept(IWlEntrySetterVisitor visitor)
        {
            visitor.Visit(this);
        }

        public virtual IEnumerable<WlEntry> Accept(IWlEntryGetterVisitor visitor)
        {
            return visitor.Visit(this);
        }

        protected void Execute(Action undoAction, Action redoAction)
        {
            redoAction();

            GetRoot().ActionCompleted.OnNext((undoAction, redoAction));
        }
    }
}
