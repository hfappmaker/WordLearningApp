using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utility
{
    public static class ActionHistoryManager
    {
        private class Command<T1, T2> : ICommand
        {
            public Func<T1, T2> UndoFunc { get; }
            public Func<T2, T1> RedoFunc { get; }
            private T1 _undoArg;
            private T2 _redoArg;

            public void Undo()
            {
                if (UndoFunc is not null)
                {
                    _redoArg = UndoFunc.Invoke(_undoArg);
                }
            }


            public void Redo()
            {
                if (RedoFunc is not null)
                {
                    _undoArg = RedoFunc.Invoke(_redoArg);
                }
            }


            public Command(Func<T1, T2> undoFunc, Func<T2, T1> redoFunc)
            {
                UndoFunc = undoFunc;
                RedoFunc = redoFunc;
            }
        }


        private class TransactionCommand : ICommand
        {
            private readonly List<ICommand> _commands = new();
            public void AddCommand(ICommand command)
            {
                _commands.Add(command);
            }


            public void Undo()
            {
                foreach (ICommand command in _commands)
                {
                    command.Undo();
                }
            }


            public void Redo()
            {
                foreach (ICommand command in Enumerable.Reverse(_commands))
                {
                    command.Redo();
                }
            }
        }

        private interface ICommand
        {
            public void Undo();

            public void Redo();
        }


        private const int MAX_TRANSACTION_LEVEL = 10;


        private const int MAX_UNDO_COUNT = 1000;


        private static readonly IReadOnlyList<Deque<ICommand>> _undoCommandsList
            = new List<Deque<ICommand>>(Enumerable.Range(0, MAX_TRANSACTION_LEVEL).Select(_ => new Deque<ICommand>()));


        private static readonly IReadOnlyList<Queue<ICommand>> _redoCommandsList
            = new List<Queue<ICommand>>(Enumerable.Range(0, MAX_TRANSACTION_LEVEL).Select(_ => new Queue<ICommand>()));


        private static int transactionLevel;


        private static void Record(ICommand command)
        {
            _redoCommandsList[transactionLevel].Clear();
            _undoCommandsList[transactionLevel].PushBack(command);
            if (_undoCommandsList[transactionLevel].Count > MAX_UNDO_COUNT)
            {
                _undoCommandsList[transactionLevel].PopFront();
            }
        }


        public static void Execute(Action undoAction, Action redoAction)
        {
            Execute<object, object>(_ => { undoAction?.Invoke(); return null; }, _ => { redoAction?.Invoke(); return null; });
        }


        public static void Execute<T1, T2>(Func<T1, T2> undoFunc, Func<T2, T1> redoFunc)
        {
            Command<T1, T2> command = new(undoFunc, redoFunc);
            command.Redo();
            Record(command);
        }


        public static void Undo()
        {
            if (_undoCommandsList[transactionLevel].TryPop(out ICommand command))
            {
                command.Undo();
                _redoCommandsList[transactionLevel].Enqueue(command);
            }
        }


        public static void Redo()
        {
            if (_redoCommandsList[transactionLevel].TryDequeue(out ICommand command))
            {
                command.Redo();
                _undoCommandsList[transactionLevel].PushBack(command);
            }
        }


        public static void BeginTransaction()
        {
            if (transactionLevel >= MAX_TRANSACTION_LEVEL)
            {
                throw new InvalidOperationException();
            }

            transactionLevel++;
        }


        public static void Commit()
        {
            if (transactionLevel == 0)
            {
                return;
            }

            TransactionCommand transactionCommand = new();
            _redoCommandsList[transactionLevel].Clear();
            while (_undoCommandsList[transactionLevel].TryPop(out ICommand command))
            {
                transactionCommand.AddCommand(command);
            }

            transactionLevel--;

            Record(transactionCommand);
        }


        public static void Rollback()
        {
            Commit();
            Undo();
        }
    }
}
