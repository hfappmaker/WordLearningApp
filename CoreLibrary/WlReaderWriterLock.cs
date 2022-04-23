using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common.EventStore
{
    public class WlReaderWriterLock
    {
        private readonly ReaderWriterLock _lock = new();


        public void BeginReadTransaction(int millisecondsTimeout)
        {
            _lock.AcquireReaderLock(millisecondsTimeout);
        }


        public void BeginWriteTransaction(int millisecondsTimeout)
        {
            _lock.AcquireWriterLock(millisecondsTimeout);
        }


        public void EndReadTransaction()
        {
            if (_lock.IsReaderLockHeld)
            {
                _lock.ReleaseReaderLock();
            }
        }


        public void EndWriteTransaction()
        {
            if (_lock.IsWriterLockHeld)
            {
                _lock.ReleaseWriterLock();
            }
        }


        public bool IsReaderLockHeld => _lock.IsReaderLockHeld;

        public bool IsWriterLockHeld => _lock.IsWriterLockHeld;

    }
}