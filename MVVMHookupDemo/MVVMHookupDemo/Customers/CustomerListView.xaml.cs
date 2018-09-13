using System.Windows.Controls;

namespace MVVMHookupDemo.Customers
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl
    {
        public CustomerListView()
        {
            InitializeComponent();
            this.DataContext = new CustomerListViewModel();
        }
    }
}
