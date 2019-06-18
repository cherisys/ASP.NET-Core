using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository repository;
        private IGenericRepository<ContactDetails> detRepository;
        private IGenericRepository<ContactLocation> locRepository;
        public RelatedDataController(ISupplierRepository repo, IGenericRepository<ContactDetails> detRepo, IGenericRepository<ContactLocation> locRepo)
        {
            repository = repo;
            detRepository = detRepo;
            locRepository = locRepo;
        }

        public IActionResult Index() => View(repository.GetSuppliers());

        public IActionResult Contacts() => View(detRepository.GetAll());
        public IActionResult Locations() => View(locRepository.GetAll());
    }
}