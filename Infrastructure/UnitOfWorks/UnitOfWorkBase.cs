using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WordLearning.Domain.Aggregate;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Infrastructure.Mappers;
using WordLearning.Infrastructure.Stores;

namespace WordLearning.Infrastructure.UnitOfWorks
{
    internal abstract class UnitOfWorkBase<T> where T : WlEntity, IAggregateRoot
    {
        private readonly ConcurrentDictionary<Guid, AggregateTracker<T>> _store = new();
        private readonly ConcurrentDictionary<int, Guid> _idDictionary = new();
        private readonly ConcurrentDictionary<Guid, int> _guidDictionary = new();
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWorkBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SaveChanges()
        {
            foreach (var pair in _store)
            {
                if (!_guidDictionary.ContainsKey(pair.Key))
                {
                    switch (pair.Value.State)
                    {
                        case EntityState.Added:
                            var id = _serviceProvider.GetService<IAggregateRootStore<T>>().Insert(pair.Value.Value);
                            _idDictionary[id] = pair.Value.Value.EntityID;
                            _guidDictionary[pair.Value.Value.EntityID] = id;
                            pair.Value.State = EntityState.Unchanged;
                            break;
                        case EntityState.Detached:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    int id = _guidDictionary[pair.Key];
                    switch (pair.Value.State)
                    {
                        case EntityState.Deleted:
                            _serviceProvider.GetService<IAggregateRootStore<T>>().Delete(id);
                            _idDictionary.Remove(id, out _);
                            _guidDictionary.Remove(pair.Value.Value.EntityID, out _);
                            pair.Value.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                            _serviceProvider.GetService<IAggregateRootStore<T>>().Delete(id);
                            _idDictionary.Remove(id, out _);
                            _guidDictionary.Remove(pair.Value.Value.EntityID, out _);
                            var newID = _serviceProvider.GetService<IAggregateRootStore<T>>().Insert(pair.Value.Value);
                            _idDictionary[newID] = pair.Value.Value.EntityID;
                            _guidDictionary[pair.Value.Value.EntityID] = newID;
                            pair.Value.State = EntityState.Unchanged;
                            break;
                        case EntityState.Unchanged:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public AggregateTracker<T> GetAggregateTracker(int id)
        {
            if (_idDictionary.ContainsKey(id))
            {
                return _store[_idDictionary[id]];
            }

            T readData = _serviceProvider.GetService<IAggregateRootMapper<T>>().GetById(id).Result;

            _store.TryAdd(readData.EntityID, new AggregateTracker<T>(readData, EntityState.Unchanged));
            _idDictionary[id] = readData.EntityID;
            _guidDictionary[readData.EntityID] = id;
            return _store[readData.EntityID];
        }

        public AggregateTracker<T> GetAggregateTracker(Guid entityID)
        {
            if (_store.ContainsKey(entityID))
            {
                return _store[entityID];
            }

            throw new InvalidOperationException();
        }

        public void Register(T root)
        {
            if (_store.ContainsKey(root.EntityID))
            {
                throw new InvalidOperationException();
            }

            _store.TryAdd(root.EntityID, new AggregateTracker<T>(root, EntityState.Detached));
        }
    }
}