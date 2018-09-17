﻿using MVVMCommsDemo.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    internal sealed class CustomerListViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public RelayCommand DeleteCommand { get; private set; }

        public Customer SelectedCustomer {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                this.selectedCustomer = value;
                this.DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private readonly ICustomersRepository repository = new CustomersRepository();
        private Customer selectedCustomer;

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            this.Customers = new ObservableCollection<Customer>(this.repository.GetCustomersAsync().Result);
            this.DeleteCommand = new RelayCommand(this.OnDelete, this.CanDelete);
        }

        private void OnDelete()
        {
            this.Customers.Remove(this.SelectedCustomer);
        }

        private bool CanDelete()
        {
            return this.SelectedCustomer != null;
        }
    }
}
