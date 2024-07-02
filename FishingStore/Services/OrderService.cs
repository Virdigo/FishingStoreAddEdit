using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.Entity;
namespace FishingStore.Services
{
    public class OrderService
    {
        public List<Orders> GetOrders()
        {
            using (var context = new FishingStoreDBEntities())
            {
                return context.Orders.Include(o => o.OrderItems).ToList();
            }
        }

        public void AddOrder(Orders order)
        {
            using (var context = new FishingStoreDBEntities())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void EditOrder(Orders order)
        {
            using (var context = new FishingStoreDBEntities())
            {
                var existingOrder = context.Orders.Find(order.Id);
                if (existingOrder != null)
                {
                    existingOrder.UserId = order.UserId;
                    existingOrder.OrderDate = order.OrderDate;

                    context.OrderItems.RemoveRange(existingOrder.OrderItems);
                    existingOrder.OrderItems = order.OrderItems;
                    context.OrderItems.AddRange(order.OrderItems);

                    context.SaveChanges();
                }
            }
        }
    }
}
