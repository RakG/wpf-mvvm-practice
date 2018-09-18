namespace ZzaDesktop
{
    internal sealed class MainWindowViewModel : BindableBase
    {
        private readonly CustomerListViewModel customerViewModel = new CustomerListViewModel();
        private readonly OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private readonly OrderViewModel orderViewModel = new OrderViewModel();

        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get => this.currentViewModel;
            set => this.SetProperty(ref this.currentViewModel, value);
        }
    }
}
