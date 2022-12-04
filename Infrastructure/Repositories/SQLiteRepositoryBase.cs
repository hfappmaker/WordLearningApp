using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordLearning.Domain.Aggregate;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Domain.Repositories;
using WordLearning.Infrastructure.UnitOfWorks;

namespace WordLearning.Infrastructure.Repositories
{
    public abstract class SQLiteRepositoryBase<T> : IWlRepository<T> where T : WlEntity, IAggregateRoot
    {
        public void Delete(T aggregateRoot)
        {
            var tracker = SQLiteUnitOfWork<T>.Instance.GetAggregateTracker(aggregateRoot.EntityID);

            if (tracker.State != EntityState.Unchanged)
            {
                throw new InvalidOperationException();
            }

            tracker.State = EntityState.Deleted;
        }

        public T GetById(int id)
        {
            var tracker = SQLiteUnitOfWork<T>.Instance.GetAggregateTracker(id);

            if (tracker.State != EntityState.Unchanged)
            {
                throw new InvalidOperationException();
            }

            return tracker.Value;
        }

        public void Insert(T aggregateRoot)
        {
            var tracker = SQLiteUnitOfWork<T>.Instance.GetAggregateTracker(aggregateRoot.EntityID);

            if (tracker.State != EntityState.Detached)
            {
                throw new InvalidOperationException();
            }

            tracker.State = EntityState.Added;
        }

        public void Save()
        {
            SQLiteUnitOfWork<T>.Instance.SaveChanges();
        }

        public void Update(T aggregateRoot)
        {
            var tracker = SQLiteUnitOfWork<T>.Instance.GetAggregateTracker(aggregateRoot.EntityID);

            if (tracker.State != EntityState.Unchanged)
            {
                throw new InvalidOperationException();
            }

            tracker.State = EntityState.Modified;
        }

        public T Create()
        {
            T root = Activator.CreateInstance<T>();
            SQLiteUnitOfWork<T>.Instance.Register(root);
            return root;
        }
    }
}