using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App.Mvc.Global;
using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            HttpResponseMessage msg = GlobalVariables.ApiClient.GetAsync("Employees").Result;
            string empData = msg.Content.ReadAsStringAsync().Result;
            IEnumerable<Employee> empList = JsonConvert.DeserializeObject<List<Employee>>(empData);
            return View(empList);
        }

        public IActionResult AddOrEdit(int Id = 0)
        {
            if (Id == 0)
                return View(new Employee());
            else
            {
                HttpResponseMessage msg = GlobalVariables.ApiClient.GetAsync("Employees/" + Id.ToString()).Result;
                string empData = msg.Content.ReadAsStringAsync().Result;
                Employee employee = JsonConvert.DeserializeObject<Employee>(empData);
                return View(employee);
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    HttpResponseMessage msg = GlobalVariables.ApiClient.PostAsJsonAsync("Employees", employee).Result;
                    TempData["AlertifyMsg"] = "Saved Successfully!";
                }
                else
                {
                    HttpResponseMessage msg = GlobalVariables.ApiClient.PutAsJsonAsync("Employees", employee).Result;
                    TempData["AlertifyMsg"] = "Updated Successfully!";
                }
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            HttpResponseMessage msg = GlobalVariables.ApiClient.DeleteAsync("Employees/" + id).Result;
            TempData["AlertifyMsg"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }

    }
}