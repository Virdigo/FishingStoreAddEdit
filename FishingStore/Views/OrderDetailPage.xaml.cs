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
    /// Логика взаимодействия для OrderDetailPage.xaml
    /// </summary>
    public partial class OrderDetailPage : Page
    {
        private OrderViewModel _viewModel;
        private Orders _order;

        internal OrderDetailPage(OrderViewModel viewModel, Orders order = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _order = order ?? new Orders();

            if (_order != null)
            {
                UserIdTextBox.Text = _order.UserId.ToString();
                OrderDateTextBox.Text = _order.OrderDate.ToString("yyyy-MM-dd");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _order.UserId = int.Parse(UserIdTextBox.Text);
            _order.OrderDate = DateTime.Parse(OrderDateTextBox.Text);

            if (_order.Id == 0)
            {
                _viewModel.Orders.Add(_order);
                _viewModel._orderService.AddOrder(_order);
            }
            else
            {
                _viewModel._orderService.EditOrder(_order);
            }

            NavigationService.GoBack();
        }
    }
}
