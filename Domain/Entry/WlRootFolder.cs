using System;
using System.Reactive.Subjects;
using WordLearning.Domain.Aggregate;
using Microsoft.Extensions.DependencyInjection;
using WordLearning.Domain.Repositories;
using System.Reflection;

namespace WordLearning.Domain.Entry
{
    public class WlRootFolder : WlFolder, IAggregateRoot
    {
        public Subject<(Action undoAction, Action redoAction)> ActionCompleted { get; } = new();

        public Subject<bool> Disposed { get; } = new();

        public WlRootFolder(string name) : base(name) { }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Disposed.OnNext(disposing);
        }
    }
}