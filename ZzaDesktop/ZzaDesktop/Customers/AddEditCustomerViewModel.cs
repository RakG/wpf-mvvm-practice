using Zza.Data;

namespace ZzaDesktop
{
    internal sealed class AddEditCustomerViewModel : BindableBase
    {
        private Customer customer;
        private bool editMode;

        public Customer Customer
        {
            get => this.customer;
            set => this.SetProperty(ref this.customer, value);
        }

        public bool EditMode
        {
            get => this.editMode;
            set => this.SetProperty(ref this.editMode, value);
        }
    }
}
