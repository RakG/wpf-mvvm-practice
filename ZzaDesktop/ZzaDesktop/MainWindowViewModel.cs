using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop
{
    internal sealed class MainWindowViewModel
    {
        private readonly CustomerListViewModel customerViewModel = new CustomerListViewModel();
        private readonly OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private readonly OrderViewModel orderViewModel = new OrderViewModel();

        public object CurrentViewModel { get; set; }
    }
}
