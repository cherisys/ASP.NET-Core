using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;
        public DataRepository(DataContext ctx) => context = ctx;
       
        public IEnumerable<Product> Products => context.Products.ToArray();
        public Product GetProduct(long key) => context.Products.Find(key);
        public void AddProduct(Product product)
        {
            //this.data.Add(product);
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            //Do not do change Tracking
            //context.Products.Update(product);

            //Do change tracking and create update query only for changed fields
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;

            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);

            //Change tracking in bulk updates
            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach(Product databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }

            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
