using FishingStore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FishingStore.ViewModels
{
    internal class OrderViewModel : BaseViewModel
    {
        public OrderService _orderService;
        public ObservableCollection<Orders> Orders { get; set; }

        public OrderViewModel()
        {
            _orderService = new OrderService();
            Orders = new ObservableCollection<Orders>(_orderService.GetOrders());
        }

        // Implement other necessary methods like AddOrder, EditOrder, etc.
    }
}
