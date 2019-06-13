using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreNew.Models;
using SportsStoreNew.Models.Pages;

namespace SportsStoreNew.Controllers
{
    public class StoreController : Controller
    {
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        public StoreController(IProductRepository prepo, ICategoryRepository catRepo)
        {
            productRepository = prepo;
            categoryRepository = catRepo;
        }
        public IActionResult Index([FromQuery(Name = "options")]
            QueryOptions productOptions,
            QueryOptions catOptions,
        long category)
        {
            ViewBag.Categories = categoryRepository.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(productRepository.GetProducts(productOptions, category));
        }
    }
}