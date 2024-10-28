using Microsoft.EntityFrameworkCore;
using Product.Models; // Make sure to include your model namespace
using System;


namespace Product.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Food> Foods { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
