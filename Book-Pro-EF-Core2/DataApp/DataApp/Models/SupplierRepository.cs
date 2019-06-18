using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(long Id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(long Id);
    }
    public class SupplierRepository:ISupplierRepository
    {
        private EFDatabaseContext context;
        public SupplierRepository(EFDatabaseContext ctx) => context = ctx;

        public void AddSupplier(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
        }

        public void DeleteSupplier(long Id)
        {
            context.Suppliers.Remove(new Supplier { Id = Id});
            context.SaveChanges();
        }

        public Supplier GetSupplier(long Id)
        {
            return context.Suppliers.Find(Id);
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            //Include method doesn't provide anything to filter related data
            return context.Suppliers.Include(s => s.Products);

            //Filtering related data using 'Explicit Loading' technique
            //IEnumerable<Supplier> data = context.Suppliers.ToArray();
            //foreach (Supplier s in data)
            //{
            //    context.Entry(s).Collection(e => e.Products)
            //    .Query()
            //    .Where(p => p.Price > 50)
            //    .Load();
            //}
            //return data;

            //Filtering related data using 'Fixing Up' technique
            //This caches related data and pass on cached data to subsequent query
            //context.Products.Where(p => p.Supplier != null && p.Price > 50).Load();
            //return context.Suppliers;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            context.SaveChanges();
        }
    }
}
