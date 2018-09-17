using MVVMCommsDemo.Customers;
using System;
using System.ComponentModel;
using System.Timers;

namespace MVVMCommsDemo
{
    internal sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly Timer timer = new Timer(5000);
        private string notificationMessage;

        public MainWindowViewModel()
        {
            this.CurrentViewModel = new CustomerListViewModel();

            this.timer.Elapsed += (sender, e) =>
            {
                this.NotificationMessage = $"Time: {DateTime.UtcNow}";
            };

            this.timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public CustomerListViewModel CurrentViewModel { get; }

        public string NotificationMessage
        {
            get => this.notificationMessage;
            set
            {
                if (this.notificationMessage != value)
                {
                    this.notificationMessage = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.NotificationMessage)));
                }
            }
        }
    }
}
