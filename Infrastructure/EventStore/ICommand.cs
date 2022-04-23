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

namespace Common.EventStore
{
    internal interface ICommand
    {
        public void Undo();

        public void Redo();
    }
}