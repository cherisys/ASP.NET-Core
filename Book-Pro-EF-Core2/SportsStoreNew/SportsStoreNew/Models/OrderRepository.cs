using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsStoreNew.Models
{
    public class OrderRepository:IOrderRepository
    {
        private DataContext context;
        public OrderRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(p => p.Product);

        public Order GetOrder(long key) => context.Orders.Include(o => o.Lines).First(o => o.Id == key);
        

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
    }
}
