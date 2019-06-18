using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository prodRepository;
        public HomeController(IProductRepository prodRepo) => prodRepository = prodRepo;
       
        public IActionResult Index(string category=null, decimal? price=null, bool includeRelated=true)
        {
            var products = prodRepository.GetFilteredProducts(category, price,includeRelated);
            ViewBag.category = category;
            ViewBag.price = price;
            ViewBag.includeRelated = includeRelated;
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }

        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", prodRepository.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            prodRepository.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Product product, Product original)
        {
            prodRepository.UpdateProduct(product,original);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            prodRepository.DeleteProduct(new Product {Id=id});
            return RedirectToAction(nameof(Index));
        }
    }
}