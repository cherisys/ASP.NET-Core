using App.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Global
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){}

        public DbSet<Employee> Employees { get; set; }
    }
}
