using Microsoft.EntityFrameworkCore;
using Product.Models;
using System.Collections.Generic;

namespace Product.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
