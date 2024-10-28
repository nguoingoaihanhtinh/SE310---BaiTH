using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodApiController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public FoodApiController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodApi
        [HttpGet]
        public async Task<ActionResult<List<Food>>> GetAllFoods()
        {
            return await _context.Foods.AsNoTracking().ToListAsync();
        }

        // GET: api/FoodApi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFoodById(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return food;
        }

        // POST: api/FoodApi
        [HttpPost] // Changed from HttpPut to HttpPost
        public async Task<ActionResult<Food>> AddFood([FromBody] Food newFood)
        {
            if (newFood == null)
            {
                return BadRequest("Food item cannot be null.");
            }

            // Validate the incoming data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the new food item
            _context.Foods.Add(newFood);
            await _context.SaveChangesAsync();

            // Return the created food item along with the 201 Created status
            return CreatedAtAction(nameof(GetFoodById), new { id = newFood.Id }, newFood);
        }



        // PUT: api/FoodApi/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditFood(int id, [FromBody] Food updatedFood)
        {
            if (id != updatedFood.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(updatedFood).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Foods.Any(f => f.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent(); // 204 No Content
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/FoodApi/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }
    }
}
