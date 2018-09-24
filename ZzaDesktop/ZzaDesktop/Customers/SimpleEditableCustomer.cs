using System;
using Zza.Data;

namespace ZzaDesktop
{
    internal sealed class SimpleEditableCustomer : BindableBase
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;

        public SimpleEditableCustomer(Customer customer, bool editMode)
        {
            this.Id = customer.Id;

            if (editMode)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
            }
        }

        public Guid Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.SetProperty(ref this.firstName, value);
        }

        public string LastName
        {
            get => this.lastName;
            set => this.SetProperty(ref this.lastName, value);
        }

        public string Email
        {
            get => this.email;
            set => this.SetProperty(ref this.email, value);
        }

        public string Phone
        {
            get => this.phone;
            set => this.SetProperty(ref this.phone, value);
        }
    }
}
