using System;
using System.Windows.Input;

namespace MVVMCommsDemo
{
    internal sealed class RelayCommand : ICommand
    {
        private readonly Action targetExecuteMethod;
        private readonly Func<bool> targetCanExecuteMethod;

        public RelayCommand(Action targetExecuteMethod, Func<bool> targetCanExecuteMethod = null)
        {
            this.targetExecuteMethod = targetExecuteMethod ?? throw new ArgumentNullException(nameof(targetExecuteMethod));
            this.targetCanExecuteMethod = targetCanExecuteMethod;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects
        // that get hooked up to command. Prism commands solve this in their implementation.
        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.targetCanExecuteMethod != null ? this.targetCanExecuteMethod() : true;
        }

        void ICommand.Execute(object parameter)
        {
            this.targetExecuteMethod();
        }
    }

    internal sealed class RelayCommand<T> : ICommand
    {
        private readonly Action<T> targetExecuteMethod;
        private readonly Func<T, bool> targetCanExecuteMethod;

        public RelayCommand(Action<T> targetExecuteMethod, Func<T, bool> targetCanExecuteMethod = null)
        {
            this.targetExecuteMethod = targetExecuteMethod ?? throw new ArgumentNullException(nameof(targetExecuteMethod));
            this.targetCanExecuteMethod = targetCanExecuteMethod;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects
        // that get hooked up to command. Prism commands solve this in their implementation.
        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.targetCanExecuteMethod != null ? this.targetCanExecuteMethod((T)parameter) : true;
        }

        void ICommand.Execute(object parameter)
        {
            this.targetExecuteMethod((T)parameter);
        }
    }
}
