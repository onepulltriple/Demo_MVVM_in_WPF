using System.Diagnostics;
using System.Windows.Input;

namespace Demo.Infrastructure
{
    public class RelayCommand : ICommand
    {
        // changed here was:
        // now nullable object in Action<object>
        // Func instead of Predicate
        // everything in the bottom half

        private readonly Action<object?> _execute;
        //private readonly Predicate<object> _canExecute;
        private readonly Func<object?, bool>? _canExecute;


        #region Constructors 
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        //public RelayCommand(Action<object?> execute, Predicate<object> canExecute)
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; 
            _canExecute = canExecute;
        }
        #endregion // Constructors 

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


        //#region ICommand Members 
        //[DebuggerStepThrough]
        //public bool CanExecute(object parameter)
        //{
        //    return _canExecute == null ? true : _canExecute(parameter); // returning true by default makes it so I can have a button that does something no matter what, even when I haven't implementated a predicate yet
        //}

        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        //public void Execute(object parameter) 
        //{ 
        //    _execute(parameter); 
        //}
        //#endregion // ICommand Members 
    }

}
