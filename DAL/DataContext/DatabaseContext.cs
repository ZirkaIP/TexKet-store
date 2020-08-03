using System;
using System.Collections.Generic;
using Common.Users.Models;
using Common.Entities;
using DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL.DataContext
{
	public class DatabaseContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public DbSet<Laptop> Laptops { get; set; }
		public DbSet<Camera> Cameras { get; set; }
		public DbSet<Smartphone> SmartPhones{ get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			base.OnModelCreating(builder);

			builder
				.ApplyConfiguration(new LaptopConfiguration());

			builder
				.ApplyConfiguration(new CameraConfiguration());

			builder
				.ApplyConfiguration(new SmartphoneConfiguration());
		}
	}

}
