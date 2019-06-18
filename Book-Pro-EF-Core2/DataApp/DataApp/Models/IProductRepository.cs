using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IProductRepository
    {
        //IQueryable<Product> Products { get; }
        //IEnumerable<Product> GetProductsByPrice(decimal minPrice);

        Product GetProduct(long Id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetFilteredProducts(string category=null, decimal? price=null, bool includeRelated=true);
        void CreateProduct(Product product);
        void UpdateProduct(Product product,Product original=null);
        void DeleteProduct(Product product);
    }
}
