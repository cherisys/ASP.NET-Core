using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository _repository) => repository = _repository;

        public IActionResult Index() => View(repository.Products);

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProduct(long key) => View(repository.GetProduct(key));

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            return View(nameof(Index),repository.Products);
        }

        [HttpPost]
        public IActionResult UpdateAll(Product[] products)
        {
            repository.UpdateAll(products);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            repository.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}