using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private EFDatabaseContext context;
        public ProductRepository(EFDatabaseContext ctx) => context = ctx;

        public void CreateProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            context.Products.Remove(p);
            if(p.Supplier != null)
            {
                context.Remove<Supplier>(p.Supplier);
            }
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.Include(p => p.Supplier);
        }

        public IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null, bool includeRelated = true)
        {
            IQueryable<Product> data = context.Products;
            if (category != null) data = data.Where(p => p.Category == category);
            if (price != null) data = data.Where(p => p.Price >= price);
            if (includeRelated) data = data.Include(p => p.Supplier);
            return data;
        }

        public Product GetProduct(long Id)
        {
            return context.Products.Include(p => p.Supplier).ThenInclude(s=>s.Contact).ThenInclude(c=>c.Location).First(p => p.Id == Id);
        }

        public void UpdateProduct(Product product,Product original=null)
        {
            if(original == null)
            {
                original = context.Products.Find(product.Id);
            }
            else
            {
                context.Products.Attach(original);
            }

            original.Name = product.Name;
            original.Category = product.Category;
            original.Price = product.Price;
            original.Color = product.Color;
            original.InStock = product.InStock;
            original.Supplier.Name = product.Supplier.Name;
            original.Supplier.City = product.Supplier.City;
            original.Supplier.State = product.Supplier.State;

            //var ctxProduct = GetProduct(product.Id);
            //ctxProduct.Name = product.Name;
            //ctxProduct.Category = product.Category;
            //ctxProduct.Price = product.Price;

            //EntityEntry entry = context.Entry(ctxProduct);
            //Console.WriteLine($"Entity State: {entry.State}");
            //foreach (string p_name in new string[]
            //{ "Name", "Category", "Price" })
            //{
            //    Console.WriteLine($"{p_name} - Old: " +
            //    $"{entry.OriginalValues[p_name]}, " +
            //    $"New: {entry.CurrentValues[p_name]}");
            //}
            context.SaveChanges();

        }
        //public IQueryable<Product> Products => context.Products;
        //public IEnumerable<Product> GetProductsByPrice(decimal minPrice) => context.Products.Where(p => p.Price > minPrice).ToArray();
    }
}
