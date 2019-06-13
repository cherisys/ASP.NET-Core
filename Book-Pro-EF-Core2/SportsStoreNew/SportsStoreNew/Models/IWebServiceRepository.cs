using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreNew.Models
{
    public interface IWebServiceRepository
    {
        object GetProduct(long id);
        object GetProducts(int skip, int take);
        long StoreProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long id);
    }
}
