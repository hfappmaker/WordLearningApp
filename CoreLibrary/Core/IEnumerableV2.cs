using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WordLearning.CoreLibrary.Core
{
    public interface IEnumerableV2<T> : IEnumerable<T>, IDisposable
        where T : Java.Lang.Object
    {
        public IDisposable RegisterCollectionChanged(Action<ObservableCollectionV2<T>, NotifyCollectionChangedEventArgs> handler);
    }
}