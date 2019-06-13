using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreNew.Models;
using SportsStoreNew.Models.Pages;

namespace SportsStoreNew.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository repository;
        public CategoriesController(ICategoryRepository _repository) => repository = _repository;

        public IActionResult Index(QueryOptions options) => View(repository.GetCategories(options));

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            repository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult EditCategory(long key)
        {
            ViewBag.EditId = key;
            return View(nameof(Index), repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            repository.DeleteCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}