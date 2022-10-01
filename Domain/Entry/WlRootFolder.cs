using System;
using System.Reactive.Subjects;
using WordLearning.Domain.Aggregate;

namespace WordLearning.Domain.Entry
{
    public class WlRootFolder : WlFolder, IAggregateRoot
    {
        public int ID { get; }

        public Subject<(Action undoAction, Action redoAction)> ActionCompleted { get; } = new();

        public WlRootFolder()
        {
            ID = 
        }
    }
}