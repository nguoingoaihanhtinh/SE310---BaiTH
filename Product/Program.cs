using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Controllers;
using Product.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<AdminController>();
// Add services to the container
builder.Services.AddControllersWithViews();

// Register DatabaseHelper with connection string
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    var connectionString = "server=localhost;port=3306;database=food_db;user=root;password=123456;";
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set up the default route for MVC controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Set up the API route for FoodApi
app.MapControllerRoute(
    name: "api",
    pattern: "api/[controller]/[action]/{id?}",
    defaults: new { controller = "FoodApi", action = "GetAllFoods" });
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Food}/{action=Index}/{id?}");
// Run the application
app.Run();
