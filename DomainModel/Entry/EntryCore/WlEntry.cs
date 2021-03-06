using Common.EventStore;
using Common.Visitors;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Common.Entry
{
    public abstract class WlEntry : Java.Lang.Object
    {
        protected WlDirectory Parent { get; set; }


        public T GetParent<T>() where T : WlDirectory
        {
            if (Parent is not T)
            {
                throw new InvalidCastException();
            }

            return Parent as T;
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


        public IAggregateRoot Root
        {
            get
            {
                WlEntry currentEntry = this;
                while (currentEntry.Parent != null)
                {
                    currentEntry = currentEntry.Parent;
                }

                return currentEntry as IAggregateRoot;
            }
        }


        protected XElement Element { get; }


        private Subject<bool> CheckedChanged { get; } = new();


        public Subject<(string PropertyName, string Value)> PropertyValueChanged { get; } = new();


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
            Element.Remove();
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
            Parent?.Element.Add(Element);
            RestoreEntry();
        }


        public WlEntry(XElement element)
        {
            Element = element;
        }

        public void Save(string fileName)
        {
            SaveCore(fileName);
        }


        protected virtual void SaveCore(string fileName)
        {
            Parent.SaveCore(fileName);
        }


        protected void SetElementValue(string value, [CallerMemberName] string name = "")
        {
            string oldValue = GetElementValue(name);
            Execute(() => SetElementValueCore(name, oldValue), () => SetElementValueCore(name, value));
        }


        protected string GetElementValue([CallerMemberName] string name = "")
        {
            return XmlConvert.DecodeName(Element.Attribute(name).Value);
        }

        private void SetElementValueCore(string name, string value)
        {
            Element.Attribute(name).Value = XmlConvert.EncodeName(value);
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


        public IDisposable RegisterPropertyValueChanged(string propertyName, Action<string> handler)
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
            if (!Root.CanWrite)
            {
                throw new InvalidOperationException();
            }

            CommandHistoryManager.Execute(Root, undoAction, redoAction);
        }
    }
}
