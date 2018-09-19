using System;

namespace ZzaDesktop
{
    internal sealed class MainWindowViewModel : BindableBase
    {
        private readonly CustomerListViewModel customerListViewModel = new CustomerListViewModel();
        private readonly OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private readonly OrderViewModel orderViewModel = new OrderViewModel();

        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            this.NavigationCommand = new RelayCommand<string>(this.OnNavigation);
            this.customerListViewModel.PlaceOrderRequested += this.NavigateToOrder;
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

        private void NavigateToOrder(Guid customerId)
        {
            this.orderViewModel.CustomerId = customerId;
            this.CurrentViewModel = this.orderViewModel;
        }
    }
}
