using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDB.Models.Scaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExistingDB.Controllers
{
    public class HomeController : Controller
    {
        private ScaffoldContext context;
        public HomeController(ScaffoldContext ctx) => context = ctx;
        
        public IActionResult Index()
        {
            return View(
                    context.Shoes
                    .Include(s => s.Color)
                    .Include(s => s.SalesCampaigns)
                    .Include(s => s.ShoeCategoryJunction)
                        .ThenInclude(scj => scj.Category)
                    .Include(s=>s.Fitting)
                );
        }
    }
}