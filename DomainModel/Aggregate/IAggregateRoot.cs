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
using System.Threading;

namespace Common.EventStore
{
    public interface IAggregateRoot
    {
        public bool CanRead { get; }

        public bool CanWrite { get; }

        public void BeginReadTransaction(int millisecondsTimeout = 3000);

        public void BeginWriteTransaction(int millisecondsTimeout = 3000);

        public void EndReadTransaction();

        public void Commit();

        public void Rollback();
    }
}