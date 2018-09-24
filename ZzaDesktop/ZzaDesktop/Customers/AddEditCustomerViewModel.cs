using Zza.Data;

namespace ZzaDesktop
{
    internal sealed class AddEditCustomerViewModel : BindableBase
    {
        private bool editMode;
        private Customer customer;
        private SimpleEditableCustomer editableCustomer;

        public bool EditMode
        {
            get => this.editMode;
            set => this.SetProperty(ref this.editMode, value);
        }

        public SimpleEditableCustomer EditableCustomer
        {
            get => this.editableCustomer;
            set => this.SetProperty(ref this.editableCustomer, value);
        }

        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
            this.EditableCustomer = new SimpleEditableCustomer(customer, this.editMode);
        }
    }
}
