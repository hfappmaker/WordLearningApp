using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Xml;
using System.Xml.Linq;
using Common.Visitors;
using static Common.Utility.ActionHistoryManager;

namespace Common.Entry
{
    public abstract class WlDirectory : WlEntry
    {
        protected ObservableCollection<WlEntry> Entries { get; } = new ObservableCollection<WlEntry>();


        private Subject<EventPattern<NotifyCollectionChangedEventArgs>> CollectionChanged { get; } = new();


        private Subject<bool> ExpandedChanged { get; } = new Subject<bool>();


        public bool IsExpanded { get; private set; }


        public void ChangeExpanded()
            => Execute(() => ChangeExpandedAction(), () => ChangeExpandedAction());
        


        private void ChangeExpandedAction()
        {
            IsExpanded = !IsExpanded;
            ExpandedChanged.OnNext(IsExpanded);
        }


        public IDisposable RegisterExpandedChanged(Action<bool> handler) => ExpandedChanged.Subscribe(handler);
        


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


        protected abstract WlEntry CreateChildEntry(XElement childElement);


        public WlDirectory(XElement element) : base(element)
        {
            foreach (var item in element.Elements())
            {
                CreateChildEntry(item).AddToAction(this);
            }

            Entries.CollectionChanged += NotifyCollectionChanged;
        }


        private void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            => CollectionChanged.OnNext(new EventPattern<NotifyCollectionChangedEventArgs>(sender, e));
        


        public override void ClearCheck()
        {
            base.ClearCheck();
            foreach (var entry in Entries)
            {
                entry.ClearCheck();
            }
        }


        internal void Add(WlEntry entry) => Entries.Add(entry);
        


        internal void Remove(WlEntry entry) => Entries.Remove(entry);
        


        internal override void DisposeEntry()
        {
            base.DisposeEntry();
            foreach (var entry in Entries)
            {
                entry.DisposeEntry();
            }
        }


        internal override void RestoreEntry()
        {
            base.RestoreEntry();
            foreach (var entry in Entries)
            {
                entry.RestoreEntry();
            }
        }


        public string EntryType => Element.Name.ToString();


        public string Name { get => GetElementValue(); set => SetElementValue(value); }


        public IEnumerable<WlEntry> EntryIterator => Entries;


        public IDisposable RegisterCollectionChanged(Action<ObservableCollection<WlEntry>, NotifyCollectionChangedEventArgs> handler)
            => CollectionChanged.Subscribe(value => handler(value.Sender as ObservableCollection<WlEntry>, value.EventArgs));

        
        public override void Accept(IWlEntrySetterVisitor visitor)
            => visitor.Visit(this);

        
        public override IEnumerable<WlEntry> Accept(IWlEntryGetterVisitor visitor)
            => visitor.Visit(this);     
    }
}
