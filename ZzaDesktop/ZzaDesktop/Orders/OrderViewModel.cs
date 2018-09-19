using System;

namespace ZzaDesktop
{
    internal sealed class OrderViewModel : BindableBase
    {
        private Guid customerId;

        public Guid CustomerId
        {
            get => this.customerId;
            set => this.SetProperty<Guid>(ref this.customerId, value);
        }
    }
}
