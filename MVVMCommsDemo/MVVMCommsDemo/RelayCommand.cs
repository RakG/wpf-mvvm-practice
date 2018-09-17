using System;
using System.Windows.Input;

namespace MVVMCommsDemo
{
    public class RelayCommand : ICommand
    {
        private readonly Action TargetExecuteMethod;
        private readonly Func<bool> TargetCanExecuteMethod;

        public RelayCommand(Action targetExecuteMethod, Func<bool> targetCanExecuteMethod = null)
        {
            this.TargetExecuteMethod = targetExecuteMethod ?? throw new ArgumentNullException(nameof(targetExecuteMethod));
            this.TargetCanExecuteMethod = targetCanExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.TargetCanExecuteMethod != null ? this.TargetCanExecuteMethod() : true;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects
        // that get hooked up to command. Prism commands solve this in their implementation.
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            this.TargetExecuteMethod();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> TargetExecuteMethod;
        private readonly Func<T, bool> TargetCanExecuteMethod;

        public RelayCommand(Action<T> targetExecuteMethod, Func<T, bool> targetCanExecuteMethod = null)
        {
            this.TargetExecuteMethod = targetExecuteMethod ?? throw new ArgumentNullException(nameof(targetExecuteMethod));
            this.TargetCanExecuteMethod = targetCanExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.TargetCanExecuteMethod != null ? this.TargetCanExecuteMethod((T)parameter) : true;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects
        // that get hooked up to command. Prism commands solve this in their implementation.
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            this.TargetExecuteMethod((T)parameter);
        }
    }
}
