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
    internal class TransactionCommand : ICommand
    {
        private readonly IEnumerable<ICommand> _commands;


        public DateTime CreateTime { get; }


        public TransactionCommand(IEnumerable<ICommand> commands)
        {
            _commands = commands;
            CreateTime = DateTime.Now;
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
}