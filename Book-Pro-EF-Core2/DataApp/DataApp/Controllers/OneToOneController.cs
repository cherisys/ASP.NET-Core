using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataApp.Controllers
{
    public class OneToOneController : Controller
    {
        private EFDatabaseContext context;
        public OneToOneController(EFDatabaseContext ctx) => context = ctx;
        public IActionResult Index()
        {
            return View(context.Set<ContactDetails>().Include(cd => cd.Supplier));
        }

        public IActionResult Create() => View("ContactEditor");
        public IActionResult Edit(long id)
        {
            ViewBag.Suppliers = context.Suppliers.Include(s => s.Contact);
            return View("ContactEditor",context.Set<ContactDetails>().Include(cd => cd.Supplier).First(cd => cd.Id == id));
        }

        [HttpPost]
        public IActionResult Update(ContactDetails details, long? targetSupplierId, long[] spares)
        {
            if (details.Id == 0)
            {
                context.Add<ContactDetails>(details);
            }
            else
            {
                if (details.SupplierId == null && targetSupplierId != null) details.Supplier = null;
                context.Update<ContactDetails>(details);
                if (targetSupplierId.HasValue)
                {
                    if (spares.Contains(targetSupplierId.Value))
                    {
                        details.SupplierId = targetSupplierId.Value;
                    }
                    else
                    {
                        ContactDetails targetDetails = context.Set<ContactDetails>().FirstOrDefault(cd => cd.SupplierId == targetSupplierId);

                        //if SupplierId is not nullable, do the swapping
                        //targetDetails.SupplierId = details.Supplier.Id;
                        //Supplier temp = new Supplier { Name = "temp" };
                        //details.Supplier = temp;
                        //context.SaveChanges();
                        //temp.Contact = null;
                        //details.SupplierId = targetSupplierId.Value;
                        //context.Suppliers.Remove(temp);

                        //if SupplierId is nullable
                        targetDetails.SupplierId = null;
                        details.SupplierId = targetSupplierId.Value;
                    }
                }
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}