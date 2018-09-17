using MVVMCommsDemo.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    internal sealed class CustomerListViewModel : INotifyPropertyChanged
    {
        private readonly ICustomersRepository repository = new CustomersRepository();
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public CustomerListViewModel()
        {
            this.DeleteCommand = new RelayCommand(this.OnDelete, this.CanDelete);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public RelayCommand DeleteCommand { get; private set; }

        public ObservableCollection<Customer> Customers
        {
            get => this.customers;
            set
            {
                if (this.customers != value)
                {
                    this.customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Customers)));
                }
            }
        }

        public Customer SelectedCustomer
        {
            get => this.selectedCustomer;
            set
            {
                if (this.selectedCustomer != value)
                {
                    this.selectedCustomer = value;
                    this.DeleteCommand.RaiseCanExecuteChanged();
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.SelectedCustomer)));
                }
            }
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
