using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingStore.Services
{
    public class ProductService
    {
        public List<Products> GetProducts()
        {
            using (var context = new FishingStoreDBEntities())
            {
                return context.Products.ToList();
            }
        }

        public void AddProduct(Products product)
        {
            using (var context = new FishingStoreDBEntities())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void EditProduct(Products product)
        {
            using (var context = new FishingStoreDBEntities())
            {
                var existingProduct = context.Products.Find(product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var context = new FishingStoreDBEntities())
            {
                var product = context.Products.Find(productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
