using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreNew.Models;
using SportsStoreNew.Models.Pages;

namespace SportsStoreNew.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        private ICategoryRepository catrepository;
        public HomeController(IProductRepository repo, ICategoryRepository catrepo)
        {
            repository = repo;
            catrepository = catrepo;
        }
       
        public IActionResult Index(QueryOptions options) => View(repository.GetProducts(options));

        public IActionResult UpdateProduct(long key)
        {
            ViewBag.Categories = catrepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id == 0) repository.AddProduct(product);
            else repository.UpdateProduct(product);
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