using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsyncGenericRepository.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var owners = await _repository.Owner.GetAllOwnersAsync();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in GetAllOwners Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerByIdAsync(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id} has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in GetOwnerById Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerWithDetailsAsync(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Details of owner with id: {id} has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Details of owner with id: {id} returned.");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in GetOwnerWithDetails Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody]Owner owner)
        {
            try
            {
                if(owner.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                await _repository.Owner.CreateOwnerAsync(owner);
                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in CreateOwner Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody]Owner owner)
        {
            try
            {
                if (owner.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var dbOwner = await _repository.Owner.GetOwnerByIdAsync(id);
                if (dbOwner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id} has not been found in db.");
                    return NotFound();
                }

                await _repository.Owner.UpdateOwnerAsync(dbOwner,owner);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in UpdateOwner Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerByIdAsync(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id} has not been found in db.");
                    return NotFound();
                }

                await _repository.Owner.DeleteOwnerAsync(owner);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error in DeleteOwner Method: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}