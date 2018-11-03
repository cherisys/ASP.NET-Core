using System.ComponentModel.DataAnnotations;

namespace App.Mvc.Models
{
    public class Employee
    {
        public long Id { get; set; }
        [Required(ErrorMessage="Please enter your name.")]
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
