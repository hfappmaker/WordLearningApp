using Android.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using WordLearning.CoreLibrary.Core;
using WordLearning.Domain.Entry.Visitors;
using WordLearning.Domain.Utility;
using WordLearning.CoreLibrary.Extension;

namespace WordLearning.Domain.Entry
{
    public class WlStartMoveCollection : IEnumerableV2<WlFolder>
    {
        private readonly CompositeDisposable _disposable = new();

        public WlFolder CurrentSelectedFolder { get; private set; }

        public WlStartMoveCollection()
        {
            Entries.CollectionChanged += NotifyCollectionChanged;

            WlUtility.RootFolder.Accept(new GetAllFolderVisitor()).Cast<WlFolder>()
                .ForEach(item => _disposable.Add(item.RegisterExpandedChanged(value => 
                { 
                    Entries.Clear(); 
                    Entries.AddRange(GetEntries()); 
                }))
            );

            Entries.AddRange(GetEntries());
        }

        private static IEnumerable<WlFolder> GetEntries()
        {
            return WlUtility.RootFolder.Accept(new GetHierarchicalEntryVisitor(WlUtility.RootFolder.Accept(new GetCheckedEntryVisitor())))
                                            .TypeSelect<WlFolder>();
        }

        protected ObservableCollectionV2<WlFolder> Entries { get; } = new ObservableCollectionV2<WlFolder>();

        private Subject<EventPattern<NotifyCollectionChangedEventArgs>> CollectionChanged { get; } = new();

        public IEnumerator<WlFolder> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        public IDisposable RegisterCollectionChanged(Action<ObservableCollectionV2<WlFolder>, NotifyCollectionChangedEventArgs> handler)
        {
            var disposable = CollectionChanged.Subscribe(value => handler(value.Sender as ObservableCollectionV2<WlFolder>, value.EventArgs));
            _disposable.Add(disposable);
            return disposable;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        private void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged.OnNext(new EventPattern<NotifyCollectionChangedEventArgs>(sender, e));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}