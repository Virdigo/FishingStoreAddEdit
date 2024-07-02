using FishingStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FishingStore.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private OrderViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();
            _viewModel = new OrderViewModel();
            DataContext = _viewModel;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Code to add a new order
            var newOrder = new Orders { UserId = 1, OrderDate = DateTime.Now };
            _viewModel.Orders.Add(newOrder);
            _viewModel._orderService.AddOrder(newOrder);
        }

        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Code to edit an order
            if (OrderListView.SelectedItem is Orders selectedOrder)
            {
                selectedOrder.OrderDate = DateTime.Now;
                _viewModel._orderService.EditOrder(selectedOrder);
            }
        }
    }
}