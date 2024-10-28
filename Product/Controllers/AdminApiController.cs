using Microsoft.AspNetCore.Mvc;
using Product.Data;
using Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminApiController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public AdminApiController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/admin/dashboard
        [HttpGet("dashboard")]
        public async Task<ActionResult<AdminDashboardViewModel>> GetDashboardData()
        {
            var foods = await _context.Foods.AsNoTracking().ToListAsync();
            var users = await _context.Users.AsNoTracking().ToListAsync();
            var dashboardData = new AdminDashboardViewModel
            {
                FoodCount = foods.Count,
                UserCount = users.Count,
                Users = users,
                Foods = foods,
                FoodNames = foods.Select(f => f.Name).ToArray(),
                Prices = foods.Select(f => f.Price).ToArray()
            };

            return Ok(dashboardData);
        }
    }
}
