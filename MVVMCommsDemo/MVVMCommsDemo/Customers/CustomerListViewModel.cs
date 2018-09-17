using MVVMCommsDemo.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    internal sealed class CustomerListViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public RelayCommand DeleteCommand { get; private set; }

        public Customer SelectedCustomer {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                this.selectedCustomer = value;
                this.DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private readonly ICustomersRepository repository = new CustomersRepository();
        private Customer selectedCustomer;

        public CustomerListViewModel()
        {
            this.DeleteCommand = new RelayCommand(this.OnDelete, this.CanDelete);
        }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            this.Customers = new ObservableCollection<Customer>(await this.repository.GetCustomersAsync());
        }

        private void OnDelete()
        {
            this.Customers?.Remove(this.SelectedCustomer);
        }

        private bool CanDelete()
        {
            return this.SelectedCustomer != null;
        }
    }
}
