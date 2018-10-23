using App.Razor.Global;
using App.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace App.Razor.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Employee> EmpList { get; set; }
        public void OnGet()
        {
            HttpResponseMessage msg = GlobalVariables.ApiClient.GetAsync("Employees").Result;
            string empData = msg.Content.ReadAsStringAsync().Result;
            EmpList = JsonConvert.DeserializeObject<List<Employee>>(empData);
        }

        public IActionResult OnGetDelete(int? id)
        {
            HttpResponseMessage msg = GlobalVariables.ApiClient.DeleteAsync("Employees/" + id).Result;
            TempData["AlertifyMsg"] = "Deleted successfully!";
            return RedirectToPage("Index");
        }
    }
}
