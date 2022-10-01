using System;
using System.Collections.Concurrent;
using WordLearning.Domain.Aggregate;

namespace WordLearning.Domain.BusinessTransaction
{
    internal class BusinessTransaction : IDisposable
    {
        private static ConcurrentDictionary<IAggregateRoot, ConcurrentStack<TransactionCommand>> _commandStore = new();
        private bool disposedValue;
        private readonly IDisposable _disposable;
        private readonly IAggregateRoot _aggregateRoot;

        public void Execute(Action action)
        {
            try
            {
                action();
                Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        private void Commit()
        {
            _commandStore[_aggregateRoot].Push(new TransactionCommand(_currentCommands));
        }

        private void Rollback()
        {
            while (_currentCommands.TryPop(out ICommand command))
            {
                command.Undo();
            };
        }

        private class Command : ICommand
        {
            public Action UndoAction { get; }

            public Action RedoAction { get; }

            public void Undo()
            {
                UndoAction?.Invoke();
            }


            public void Redo()
            {
                RedoAction?.Invoke();
            }


            public Command(Action undoAction, Action redoAction)
            {
                UndoAction = undoAction;
                RedoAction = redoAction;
            }
        }

        private const int MAX_TRANSACTION_COUNT = 1000;

        private readonly ConcurrentStack<ICommand> _currentCommands = new ();

        private void Record(ICommand command)
        {
            _currentCommands.Push(command);

            if (_currentCommands.Count > MAX_TRANSACTION_COUNT)
            {
                throw new InvalidOperationException();
            }
        }

        public BusinessTransaction(IAggregateRoot root)
        {
            _aggregateRoot = root;
            _disposable = root.ActionCompleted.Subscribe(tuple => Record(new Command(tuple.undoAction, tuple.redoAction)));
            _commandStore[root] = new ConcurrentStack<TransactionCommand>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _disposable.Dispose();// TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~BusinessTransaction()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}