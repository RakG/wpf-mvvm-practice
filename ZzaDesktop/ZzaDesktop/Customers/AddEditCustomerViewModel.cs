using System;
using System.ComponentModel;
using Zza.Data;

namespace ZzaDesktop
{
    public sealed class AddEditCustomerViewModel : BindableBase
    {
        private readonly ICustomersRepository customersRepository;

        private bool editMode;
        private Customer customer;
        private SimpleEditableCustomer editableCustomer;

        public AddEditCustomerViewModel(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;

            this.CancelCommand = new RelayCommand(this.OnCancel);
            this.SaveCommand = new RelayCommand(this.OnSave, this.CanSave);
        }

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

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        public void SetCustomer(Customer customer)
        {
            this.customer = customer;

            if (this.EditableCustomer != null)
            {
                this.EditableCustomer.ErrorsChanged -= this.RaiseOnErrorsChanged;
            }

            this.EditableCustomer = new SimpleEditableCustomer(customer, this.EditMode);
            this.EditableCustomer.ErrorsChanged += this.RaiseOnErrorsChanged;
        }

        private void RaiseOnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            this.SaveCommand.RaiseCanExecuteChanged();
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            this.EditableCustomer.Update(this.customer);

            if (this.EditMode)
            {
                await this.customersRepository.UpdateCustomerAsync(this.customer);
            }
            else
            {
                await this.customersRepository.AddCustomerAsync(this.customer);
            }

            Done();
        }

        private bool CanSave()
        {
            return !this.EditableCustomer.HasErrors;
        }
    }
}
