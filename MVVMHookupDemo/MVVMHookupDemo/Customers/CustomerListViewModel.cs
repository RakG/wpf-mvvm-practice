using MVVMHookupDemo.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
    internal sealed class CustomerListViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private readonly ICustomersRepository _repository = new CustomersRepository();

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            Customers = new ObservableCollection<Customer>(_repository.GetCustomersAsync().Result);
        }
    }
}
