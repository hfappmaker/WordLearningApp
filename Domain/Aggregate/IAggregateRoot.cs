using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace WordLearning.Domain.Aggregate
{
    public interface IAggregateRoot : IDisposable
    {
        Subject<(Action undoAction, Action redoAction)> ActionCompleted { get; }


        Subject<bool> Disposed { get; }
    }
}