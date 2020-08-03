﻿using System;
using System.Windows.Input;

namespace Ferma.Helper
{
    public class DelegateCommand : ICommand
    {
        #region Flieds
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region Constructor

        public DelegateCommand(Action action, Func<bool> canAction = null) : this((x)=>action(), (x) => canAction?.Invoke() ?? true)
        {

        }

       public DelegateCommand(Action<object> execute) : this(execute, null)
       {
   
      }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;

        }

        
        #endregion

        #region ICommand members

        public bool CanExecute(object parametr)
        {
            return _canExecute?.Invoke(parametr) ?? true;

        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion
    }
}

