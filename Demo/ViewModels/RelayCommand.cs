using System.Diagnostics;
using System.Windows.Input;

namespace Demo.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region Fields 
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields 


        #region Constructors 
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; 
            _canExecute = canExecute;
        }
        #endregion // Constructors 


        #region ICommand Members 
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter); // returning true by default makes it so I can have a button that does something no matter what, even when I haven't implementated a predicate yet
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) 
        { 
            _execute(parameter); 
        }
        #endregion // ICommand Members 
    }

}
