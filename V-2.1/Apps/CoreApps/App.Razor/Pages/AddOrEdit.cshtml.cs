using App.Razor.Global;
using App.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;

namespace App.Razor.Pages
{
    public class AddOrEditModel : PageModel
    {
        [BindProperty]
        public Employee Emp { get; set; }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                HttpResponseMessage msg = GlobalVariables.ApiClient.GetAsync("Employees/" + id).Result;
                string empData = msg.Content.ReadAsStringAsync().Result;
                Emp = JsonConvert.DeserializeObject<Employee>(empData);
            }
        }

        public IActionResult OnPost()
        {
            if (Emp.Id != 0)
            {
                HttpResponseMessage msg = GlobalVariables.ApiClient.PutAsJsonAsync("Employees", Emp).Result;
                TempData["AlertifyMsg"] = "Updated Successfully!";
            }
            else
            {
                HttpResponseMessage msg = GlobalVariables.ApiClient.PostAsJsonAsync("Employees", Emp).Result;
                TempData["AlertifyMsg"] = "Added Successfully!";
            }
            return RedirectToPage("./Index");
        }

    }
}