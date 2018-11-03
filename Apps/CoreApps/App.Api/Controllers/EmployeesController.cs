using App.Api.Global;
using App.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRepository<Employee> Repo;

        public EmployeesController(IRepository<Employee> _repo)
        {
            Repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Repo.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await Repo.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee item)
        {
            if (item == null) return BadRequest();
            await Repo.Create(item);
            return CreatedAtRoute("GetItem", new { Controller = "Employees", id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee item)
        {
            if (item == null) return BadRequest();
            await Repo.Update(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await Repo.GetById(id);
            if (item == null) return NotFound();
            await Repo.Delete(id);
            return Ok();
        }
    }
}