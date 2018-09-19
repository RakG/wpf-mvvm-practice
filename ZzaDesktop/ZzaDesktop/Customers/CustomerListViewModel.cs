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
             this.PlaceOrderCommand = new RelayCommand<Customer>(this.OnPlaceOrder);
        }

        public ObservableCollection<Customer> Customers
        {
            get => this.customers;
            set => this.SetProperty(ref this.customers, value);
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }

        public async void LoadCustomers()
        {
            this.Customers = new ObservableCollection<Customer>(await this.customersRepository.GetCustomersAsync());
        }

        private void OnPlaceOrder(Customer customer)
        {
        }
    }
}
