using WordLearning.CoreLibrary.Core;
using WordLearning.Domain.Entry.Visitors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace WordLearning.Domain.Entry.EntryCore
{
    public abstract class WlDirectory : WlEntry, IWlEnumerable<WlEntry>
    {
        public WlDirectory(IEnumerable<WlEntry> entries) : base()
        {
            foreach (WlEntry entry in entries)
            {
                entry.AddToAction(this);
            }

            Entries.CollectionChanged += NotifyCollectionChanged;
        }

        protected WlObservableCollection<WlEntry> Entries { get; } = new WlObservableCollection<WlEntry>();

        private Subject<EventPattern<NotifyCollectionChangedEventArgs>> CollectionChanged { get; } = new();

        private Subject<bool> ExpandedChanged { get; } = new Subject<bool>();

        public bool IsExpanded { get; private set; }


        public void ChangeExpanded()
        {
            Execute(() => ChangeExpandedAction(), () => ChangeExpandedAction());
        }

        private void ChangeExpandedAction()
        {
            IsExpanded = !IsExpanded;
            ExpandedChanged.OnNext(IsExpanded);
        }

        public IDisposable RegisterExpandedChanged(Action<bool> handler)
        {
            IDisposable currentDisposable = null;
            void registerAction() => currentDisposable = ExpandedChanged.Subscribe(handler);
            void disposeAction() => currentDisposable.Dispose();
            Execute(disposeAction, registerAction);
            return Disposable.Create(() => Execute(registerAction, disposeAction));
        }

        public WlEntry this[int index] => Entries[index];

        private WlEntry _currentSelectedEntry;
        public WlEntry CurrentSelectedEntry
        {
            get
            {
                if (_currentSelectedEntry == null || _currentSelectedEntry.IsDisposed)
                {
                    return null;
                }
                else
                {
                    return _currentSelectedEntry;
                }
            }

            internal set => _currentSelectedEntry = value;
        }

        private void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged.OnNext(new EventPattern<NotifyCollectionChangedEventArgs>(sender, e));
        }

        public override void ClearCheck()
        {
            base.ClearCheck();
            foreach (WlEntry entry in Entries)
            {
                entry.ClearCheck();
            }
        }

        internal void Add(WlEntry entry)
        {
            Entries.Add(entry);
        }

        internal void Remove(WlEntry entry)
        {
            Entries.Remove(entry);
        }

        internal override void DisposeEntry()
        {
            base.DisposeEntry();
            foreach (WlEntry entry in Entries)
            {
                entry.DisposeEntry();
            }
        }

        internal override void RestoreEntry()
        {
            base.RestoreEntry();
            foreach (WlEntry entry in Entries)
            {
                entry.RestoreEntry();
            }
        }

        public string EntryType { get; }

        public string Name { get => GetValue<string>(); set => SetValue(value); }

        public IDisposable RegisterCollectionChanged(Action<WlObservableCollection<WlEntry>, NotifyCollectionChangedEventArgs> handler)
        {
            IDisposable currentDisposable = null;
            void registerAction() => currentDisposable = CollectionChanged.Subscribe(value => handler(value.Sender as WlObservableCollection<WlEntry>, value.EventArgs));
            void disposeAction() => currentDisposable.Dispose();
            Execute(disposeAction, registerAction);
            return Disposable.Create(() => Execute(registerAction, disposeAction));
        }

        public override void Accept(IWlEntrySetterVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IEnumerable<WlEntry> Accept(IWlEntryGetterVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public IEnumerator<WlEntry> GetEnumerator()
        {
            return ((IEnumerable<WlEntry>)Entries).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Entries).GetEnumerator();
        }
    }
}
