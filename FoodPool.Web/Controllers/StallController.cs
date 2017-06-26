using System;
using Microsoft.AspNetCore.Mvc;
using FoodPool.Core.Data.Services;
using System.Threading.Tasks;
using FoodPool.Core;
using Microsoft.AspNetCore.Authorization;

namespace FoodPool.Web.Controllers
{
    [Route("api/[controller]")]
    public class StallController : Controller
    {
        private readonly IStallManager _stallManager;

        public StallController(IStallManager stallManager)
        {
            _stallManager = stallManager;
        }

       // [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stalls = await _stallManager.FindAllAsync();
            return Ok(stalls);
        }
            
        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllAsync(string name)
		{
            var stalls = await _stallManager.FindByNameAsync(name);
			return Ok(stalls);
		}

        [HttpGet("{id}", Name = "FindStallById")]
        public async Task<IActionResult> FindByIdAsync(string id)
        {
            var stall = await _stallManager.FindByIdAsync(id);
            if (stall == null)
                return NotFound($"Stall with id: {id} not found");

            return Ok(stall);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody]Stall updatedStall)
        {
            if (updatedStall == null || updatedStall.Id != id)
                return BadRequest();

            var stall = await _stallManager.FindByIdAsync(id);

            if (stall == null)
                return NotFound();

            await _stallManager.SaveAsync(updatedStall);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Stall stall)
        {
            if (stall == null)
                return BadRequest();

            await _stallManager.SaveAsync(stall);
            return CreatedAtRoute("FindStallById", new { id = stall.Id }, stall);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var stall = await _stallManager.FindByIdAsync(id);
            if (stall == null)
                return NotFound();

            await _stallManager.DeleteAsync(stall);
            return NoContent();
        }
    }
}
