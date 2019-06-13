using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreNew.Models
{
    public class WebServiceRepository: IWebServiceRepository
    {
        private DataContext context;
        public WebServiceRepository(DataContext ctx) => context = ctx;

        public object GetProduct(long id)
        {
            //Include navigation property details, i.e. Category
            //And avoid circular references in related data.
            return context.Products.Include(p => p.Category).Select(p => new {
                p.Id,
                p.Name,
                p.PurchasePrice,
                p.Description,
                p.RetailPrice,
                p.CategoryId,
                Category = new
                {
                    p.Category.Id,
                    p.Category.Name,
                    p.Category.Description
                }
            })
            .FirstOrDefault(p => p.Id == id);
        }

        public object GetProducts(int skip, int take)
        {
            return context.Products.Include(p => p.Category)
                                      .OrderBy(p => p.Id)
                                      .Skip(skip)
                                      .Take(take)
                                      .Select(p => new {
                                          p.Id,
                                          p.Name,
                                          p.PurchasePrice,
                                          p.Description,
                                          p.RetailPrice,
                                          p.CategoryId,
                                          Category = new
                                          {
                                              p.Category.Id,
                                              p.Category.Name,
                                              p.Category.Description
                                          }
                                      });
        }

        public long StoreProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            context.Products.Remove(new Product() { Id = id });
            context.SaveChanges();
        }
    }
}
