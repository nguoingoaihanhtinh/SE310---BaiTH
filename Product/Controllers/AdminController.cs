using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;
using System.Linq;
using System.Xml.Linq;

namespace Product.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly FoodDbContext _context;

        public AdminController(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var foods = await _context.Foods.AsNoTracking().ToListAsync();
            var users = await _context.Users.AsNoTracking().ToListAsync();
            var dashboardData = new AdminDashboardViewModel
            {
                UserCount = users.Count,
                FoodCount = foods.Count,
                Foods = foods,
                Users = users,
                FoodNames = foods.Select(f => f.Name).ToArray(),
                Prices = foods.Select(f => f.Price).ToArray()
            };

            ViewBag.FoodCount = dashboardData.FoodCount;
            ViewBag.FoodNames = dashboardData.FoodNames;
            ViewBag.Prices = dashboardData.Prices;
            ViewBag.UserCount = dashboardData.UserCount;
            return View(dashboardData);
        }
    }
}

//[HttpGet]
//    public IActionResult EditUser(int id)
//    {
//        var user = dbHelper.GetUserById(id); 
//        if (user == null)
//        {
//            return NotFound(); 
//        }
//        return View(user); 
//    }

//    [HttpPost]
//    public IActionResult EditUser(User user)
//    {
//        if (ModelState.IsValid)
//        {
//            dbHelper.UpdateUser(user);
//            return RedirectToAction("Index");
//        }

//        return View(user);
//    }
//    [HttpPost]
//    public IActionResult DeleteUser(int id)
//    {
//        dbHelper.DeleteUser(id);
//        return RedirectToAction("Index");
//    }
//    public IActionResult AddUser()
//    {
//        // Render the AddUser view.
//        return View();
//    }

//    [HttpPost]
//    public IActionResult AddUser(User user)
//    {
//        if (ModelState.IsValid)
//        {
//            dbHelper.AddUser(user);
//            return RedirectToAction("Index");
//        }

//        // If validation fails, return the form view with errors.
//        return View(user);
//    }
//}

