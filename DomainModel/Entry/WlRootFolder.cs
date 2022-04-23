using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Common.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace WordLearning.Entry
{
    public class WlRootFolder : WlFolder, IAggregateRoot
    {
        private XElement _oldElement;

        public WlRootFolder(XElement element) : base(element)
        {
            _oldElement = element;
        }

        public bool IsEdited => _oldElement.ToString() != Element.ToString();


        private readonly WlReaderWriterLock _lock = new WlReaderWriterLock();

        public void BeginReadTransaction(int millisecondsTimeout = 3000)
        {
            _lock.BeginReadTransaction(millisecondsTimeout);
        }

        public void BeginWriteTransaction(int millisecondsTimeout = 3000)
        {
            _lock.BeginWriteTransaction(millisecondsTimeout);
        }

        public void EndReadTransaction()
        {
            _lock.EndReadTransaction();
        }

        public void EndWriteTransaction()
        {
            _lock.EndWriteTransaction();
        }

        public bool CanRead => _lock.IsReaderLockHeld;

        public bool CanWrite => _lock.IsWriterLockHeld;

        public void Commit()
        {
            CommandHistoryManager.StoreCommand(this);

            EndWriteTransaction();
        }

        public void Rollback()
        {
            CommandHistoryManager.UndoCommand(this);

            EndWriteTransaction();
        }

        protected override void SaveCore(string fileName)
        {
            Element.Save(fileName);
            _oldElement = new XElement(Element);
        }
    }
}