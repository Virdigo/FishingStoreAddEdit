using FishingStore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingStore.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        public ProductService _productService;
        public ObservableCollection<Products> Products { get; set; }

        public ProductViewModel()
        {
            _productService = new ProductService();
            Products = new ObservableCollection<Products>();
            LoadProducts();
        }

        public void LoadProducts()
        {
            Products.Clear();
            var products = _productService.GetProducts();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

       
    }
}