using MVVMHookupDemo.Customers;

namespace MVVMHookupDemo
{
    internal sealed class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.CurrentViewModel = new CustomerListViewModel();
        }

        public CustomerListViewModel CurrentViewModel { get; }
    }
}
