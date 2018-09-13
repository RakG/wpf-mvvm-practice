using MVVMCommsDemo.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    internal sealed class CustomerListViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private readonly ICustomersRepository repository = new CustomersRepository();

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            this.Customers = new ObservableCollection<Customer>(this.repository.GetCustomersAsync().Result);
        }
    }
}
