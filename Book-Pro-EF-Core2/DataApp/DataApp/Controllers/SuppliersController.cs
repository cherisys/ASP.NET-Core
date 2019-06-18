using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataApp.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository suppRepository;
        private EFDatabaseContext context;

        public SuppliersController(ISupplierRepository suppRepo, EFDatabaseContext ctx)
        {
            suppRepository = suppRepo;
            context = ctx;
        }
        
        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];
            return View(suppRepository.GetSuppliers());
        }

        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            suppRepository.UpdateSupplier(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Change(long Id, Product[] products)
        {
            //IEnumerable<Product> changed = supplier.Products.Where(p => p.SupplierId != supplier.Id);
            //IEnumerable<long> targetSupplierIds = changed.Select(p => p.SupplierId).Distinct();
            //if (changed.Count() > 0)
            //{
            //    IEnumerable<Supplier> targetSuppliers = context.Suppliers
            //    .Where(s => targetSupplierIds.Contains(s.Id))
            //    .AsNoTracking().ToArray();
            //    foreach (Product p in changed)
            //    {
            //        Supplier newSupplier = targetSuppliers.First(s => s.Id == p.SupplierId);
            //        newSupplier.Products = newSupplier.Products == null ? new Product[] { p } : newSupplier.Products.Append(p).ToArray();
            //    }
            //    context.Suppliers.UpdateRange(targetSuppliers);
            //    context.SaveChanges();
            //}

            context.Products.UpdateRange(products.Where(p => p.SupplierId != Id));
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}