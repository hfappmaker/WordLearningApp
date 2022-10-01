using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WordLearning.CoreLibrary.Core
{
    public interface IWlEnumerable<T> : IEnumerable<T>, IDisposable
        where T : Java.Lang.Object
    {
        public IDisposable RegisterCollectionChanged(Action<WlObservableCollection<T>, NotifyCollectionChangedEventArgs> handler);
    }
}