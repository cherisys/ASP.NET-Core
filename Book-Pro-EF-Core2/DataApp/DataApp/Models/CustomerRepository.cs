using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class CustomerRepository:ICustomerRepository
    {
        private EFCustomerContext context;
        public CustomerRepository(EFCustomerContext ctx) => context = ctx;

        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers;
        }
    }
}
