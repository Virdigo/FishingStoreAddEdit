using FishingStore.Views;
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

namespace FishingStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        public void NavigateToHomePage(Users user)
        {
            if (user.Role == "Customer")
            {
                MainFrame.Navigate(new HomePage());
            }
            else if (user.Role == "Manager")
            {
                MainFrame.Navigate(new ProductsPage());
            }
            else if (user.Role == "Admin")
            {
                MainFrame.Navigate(new ProductsPage()); // Navigate to Admin page if needed
            }
        }
    }
}
