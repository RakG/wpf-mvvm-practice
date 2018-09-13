using MVVMCommsDemo.Customers;

namespace MVVMCommsDemo
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
