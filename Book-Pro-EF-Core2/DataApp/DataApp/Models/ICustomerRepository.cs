using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        void AddCustomer(Customer customer);
    }
}
