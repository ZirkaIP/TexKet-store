using System;
using Common.Entities;
using Common.Models;
using Common.Users.Models;
using DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
	public class DatabaseContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			//ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShopCartItem> ShopCartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrdersDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			base.OnModelCreating(builder);

			builder
				.ApplyConfiguration(new ProductConfiguration());

			builder
				.ApplyConfiguration(new OrderConfiguration());

		}
	}

}
