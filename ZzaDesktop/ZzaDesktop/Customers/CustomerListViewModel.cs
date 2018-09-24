using System;
using System.Collections.ObjectModel;
using Zza.Data;

namespace ZzaDesktop
{
    internal sealed class CustomerListViewModel : BindableBase
    {
        private readonly ICustomersRepository customersRepository = new CustomersRepository();

        private ObservableCollection<Customer> customers;

        public CustomerListViewModel()
        {
            this.AddCustomerCommand = new RelayCommand(this.OnAddCustomer);
            this.EditCustomerCommand = new RelayCommand<Customer>(this.OnEditCustomer);
            this.PlaceOrderCommand = new RelayCommand<Customer>(this.OnPlaceOrder);
        }

        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };
        public event Action<Guid> PlaceOrderRequested = delegate { };

        public ObservableCollection<Customer> Customers
        {
            get => this.customers;
            set => this.SetProperty(ref this.customers, value);
        }

        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }
        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }

        public async void LoadCustomers()
        {
            this.Customers = new ObservableCollection<Customer>(await this.customersRepository.GetCustomersAsync());
        }

        private void OnAddCustomer()
        {
            AddCustomerRequested(new Customer() { Id = Guid.NewGuid() });
        }

        private void OnEditCustomer(Customer customer)
        {
            EditCustomerRequested(customer);
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }
    }
}
