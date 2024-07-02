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
    /// Логика взаимодействия для ProductDetailPage.xaml
    /// </summary>
    public partial class ProductDetailPage : Page
    {
        private ProductViewModel _viewModel;
        public Products _product;

        internal ProductDetailPage(ProductViewModel viewModel, Products product = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _product = product ?? new Products();

            if (_product != null)
            {
                NameTextBox.Text = _product.Name;
                DescriptionTextBox.Text = _product.Description;
                PriceTextBox.Text = _product.Price.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _product.Name = NameTextBox.Text;
            _product.Description = DescriptionTextBox.Text;
            _product.Price = decimal.Parse(PriceTextBox.Text);

            if (_product.Id == 0)
            {
                _viewModel.Products.Add(_product);
                _viewModel._productService.AddProduct(_product);
            }
            else
            {
                _viewModel._productService.EditProduct(_product);
            }

            NavigationService.GoBack();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

