using System;
using Zza.Data;

namespace ZzaDesktop
{
    public sealed class MainWindowViewModel : BindableBase
    {
        private readonly AddEditCustomerViewModel addEditCustomerViewModel;
        private readonly CustomerListViewModel customerListViewModel;
        private readonly OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private readonly OrderViewModel orderViewModel = new OrderViewModel();

        private BindableBase currentViewModel;

        public MainWindowViewModel(AddEditCustomerViewModel addEditCustomerViewModel, CustomerListViewModel customerListViewModel)
        {
            this.addEditCustomerViewModel = addEditCustomerViewModel;
            this.customerListViewModel = customerListViewModel;

            this.NavigationCommand = new RelayCommand<string>(this.OnNavigation);
            this.customerListViewModel.AddCustomerRequested += this.NavigateToAddCustomer;
            this.customerListViewModel.EditCustomerRequested += this.NavigateToEditCustomer;
            this.customerListViewModel.PlaceOrderRequested += this.NavigateToOrder;
            this.addEditCustomerViewModel.Done += this.NavigateToCustomerList;
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get => this.currentViewModel;
            set => this.SetProperty(ref this.currentViewModel, value);
        }

        private void OnNavigation(string destination)
        {
            switch (destination)
            {
                case "OrderPrep":
                    this.CurrentViewModel = this.orderPrepViewModel;
                    break;
                case "Customers":
                    this.CurrentViewModel = this.customerListViewModel;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void NavigateToAddCustomer(Customer customer)
        {
            this.addEditCustomerViewModel.EditMode = false;
            this.addEditCustomerViewModel.SetCustomer(customer);
            this.CurrentViewModel = this.addEditCustomerViewModel;
        }

        private void NavigateToEditCustomer(Customer customer)
        {
            this.addEditCustomerViewModel.EditMode = true;
            this.addEditCustomerViewModel.SetCustomer(customer);
            this.CurrentViewModel = this.addEditCustomerViewModel;
        }

        private void NavigateToOrder(Guid customerId)
        {
            this.orderViewModel.CustomerId = customerId;
            this.CurrentViewModel = this.orderViewModel;
        }

        private void NavigateToCustomerList()
        {
            this.CurrentViewModel = this.customerListViewModel;
        }
    }
}
