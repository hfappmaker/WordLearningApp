using Common.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Common.EventStore
{
    public static class CommandHistoryManager
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


        private const int MAX_TRANSACTION_COUNT = 1000;


        private static readonly IReadOnlyDictionary<object, ConcurrentStack<ICommand>> _undoCommandsList
            = new ConcurrentDictionary<object, ConcurrentStack<ICommand>>();


        private static readonly ConcurrentDictionary<object, ConcurrentStack<TransactionCommand>> _storedCommands = new();


        private static void Record(object commandHistoryKey, ICommand command)
        {
            _undoCommandsList[commandHistoryKey].Push(command);
            if (_undoCommandsList[commandHistoryKey].Count > MAX_TRANSACTION_COUNT)
            {
                throw new InvalidOperationException();
            }
        }


        public static void Execute(object commandHistoryKey, Action undoAction, Action redoAction)
        {
            Execute<object, object>(commandHistoryKey, _ => { undoAction?.Invoke(); return null; }, _ => { redoAction?.Invoke(); return null; });
        }


        private static void Execute<T1, T2>(object commandHistoryKey, Func<T1, T2> undoFunc, Func<T2, T1> redoFunc)
        {
            Command<T1, T2> command = new(undoFunc, redoFunc);
            command.Redo();
            Record(commandHistoryKey, command);
        }


        public static void StoreCommand(object commandHistoryKey)
        {
            if (_undoCommandsList.Count > 0)
            {
                var commands = new List<ICommand>();
                while (_undoCommandsList[commandHistoryKey].TryPop(out ICommand command))
                {
                    commands.Add(command);
                };

                TransactionCommand transactionCommand = new(commands);

                _storedCommands[commandHistoryKey].Push(transactionCommand);
            }
        }


        public static void UndoCommand(object commandHistoryKey)
        {
            while (_undoCommandsList[commandHistoryKey].TryPop(out ICommand command))
            {
                command.Undo();
            }
        }
    }
}
