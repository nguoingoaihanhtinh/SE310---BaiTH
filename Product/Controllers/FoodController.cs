using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Controllers
{
    [Route("Food")]
    public class FoodController : Controller
    {
        private readonly FoodDbContext _context;

        public FoodController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: Food
        public IActionResult Index()
        {
            var foods = _context.Foods.ToList();
            return View(foods);
        }

        // GET: Food/Detail/{id}
        [HttpGet("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var food = _context.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food); // Return the view with the food details
        }

        // GET: Food/Edit/{id}
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var food = _context.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food); // Return the view with the food item to edit
        }

        // POST: Food/Edit/{id}
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Food updatedFood)
        {
            if (id != updatedFood.Id) // Ensure the ID matches
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

                return RedirectToAction("Index");
            }
            return View(updatedFood); // Return the view with errors if model is invalid
        }



        // POST: Food/Delete/{id}
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirect back to Index after deletion
        }

        // GET: Food/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Renders the create form
        }

        // POST: Food/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Food food)
        {
            if (!ModelState.IsValid)
            {
                return View(food); // Returns form with validation errors if any
            }

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirects to the index page after creation
        }
    }
}
