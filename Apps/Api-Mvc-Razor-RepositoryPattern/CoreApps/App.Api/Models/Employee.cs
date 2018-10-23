using App.Api.Global;

namespace App.Api.Models
{
    public class Employee : EntityBase
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
