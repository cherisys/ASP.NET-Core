using SportsStoreNew.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreNew.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        PagedList<Product> GetProducts(QueryOptions options, long category = 0);
        Product GetProduct(long key);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
