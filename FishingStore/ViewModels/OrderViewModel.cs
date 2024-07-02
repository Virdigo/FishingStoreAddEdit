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
    public class OrderViewModel : BaseViewModel
    {
        public OrderService _orderService;
        public ObservableCollection<Orders> Orders { get; set; }

        public OrderViewModel()
        {
            _orderService = new OrderService();
            Orders = new ObservableCollection<Orders>();
            LoadOrders();
        }

        public void LoadOrders()
        {
            Orders.Clear();
            var orders = _orderService.GetOrders();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
    }
}
