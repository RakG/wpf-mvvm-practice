﻿using System;
using Zza.Data;

namespace ZzaDesktop
{
    internal sealed class AddEditCustomerViewModel : BindableBase
    {
        private bool editMode;
        private Customer customer;
        private SimpleEditableCustomer editableCustomer;

        public AddEditCustomerViewModel()
        {
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
            this.EditableCustomer = new SimpleEditableCustomer(customer, this.editMode);
        }

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            Done();
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
