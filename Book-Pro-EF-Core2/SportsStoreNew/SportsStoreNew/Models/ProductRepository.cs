using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStoreNew.Models.Pages;

namespace SportsStoreNew.Models
{
    public class ProductRepository : IProductRepository
    {
        private DataContext context { get; }
        public ProductRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Product> Products => context.Products.Include(p=>p.Category).ToArray();

        public PagedList<Product> GetProducts(QueryOptions options, long category = 0)
        {
            IQueryable<Product> query = context.Products.Include(p => p.Category);
            if (category != -0)
            {
                query = query.Where(p => p.CategoryId == category);
            }

            return new PagedList<Product>(query, options);
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProduct(long key) => context.Products.Include(p=>p.Category).First(p=>p.Id == key);

        public void UpdateProduct(Product product)
        {
            //Update with change detection
            Product ctxProduct = context.Products.Find(product.Id);
            ctxProduct.Name = product.Name;
            //ctxProduct.Category = product.Category;
            ctxProduct.PurchasePrice = product.PurchasePrice;
            ctxProduct.RetailPrice = product.RetailPrice;
            ctxProduct.CategoryId = product.CategoryId;

            context.SaveChanges();
        }
    }
}
