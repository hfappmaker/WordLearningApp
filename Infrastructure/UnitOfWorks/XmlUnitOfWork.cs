using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WordLearning.Domain.Aggregate;

namespace WordLearning.Infrastructure.UnitOfWorks
{
    public class XmlUnitOfWork
    {
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<int, AggregateTracker>> _store = new();

        public XmlUnitOfWork() { }

        public void SaveChanges()
        {

        }

        private bool IsLoaded(Type type, int id)
        {
            return _store[type].ContainsKey(id);
        }

        public void Add(IAggregateRoot root)
        {
            if (!_store.ContainsKey(root.GetType()))
            {
                _store.TryAdd(root.GetType(), new ConcurrentDictionary<int, AggregateTracker>());
            }

            if (_store[root.GetType()].ContainsKey(root.ID))
            {
                throw new InvalidOperationException();
            }

            _store[root.GetType()].TryAdd(root.ID, new AggregateTracker(root, EntityState.Added));
        }

        public void ChangeEntityState(IAggregateRoot root, EntityState state)
        {
            _store[root.GetType()][root.ID].State = state;
        }

        public T GetAggregateRoot<T>(int id) where T : IAggregateRoot
        {
            if (IsLoaded(typeof(T), id))
            {
                AggregateTracker monitor = _store[typeof(T)][id];

                if (monitor.State != EntityState.Unchanged)
                {
                    throw new InvalidOperationException();
                }

                return (T)monitor.Value;
            }

            // TODO: read
            T readData = default;

            if (!_store.ContainsKey(typeof(T)))
            {
                _store.TryAdd(typeof(T), new ConcurrentDictionary<int, AggregateTracker>());
            }

            _store[typeof(T)].TryAdd(id, new AggregateTracker(readData, EntityState.Unchanged));
            return readData;
        }

        private class AggregateTracker
        {
            public IAggregateRoot Value { get; }
            public AggregateTracker(IAggregateRoot root, EntityState state)
            {
                Value = root;
                State = state;
            }

            public EntityState State { get; set; }
        }
    }
}