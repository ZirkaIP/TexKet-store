using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
	public class DatabaseContext : DbContext
	{

		public class OptionsBuild
		{
			public OptionsBuild()
			{
				Settings = new AppConfiguration(); 
				OpsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
				OpsBuilder.UseSqlServer(Settings.SqlConnectionString);
				DbOptions = OpsBuilder.Options;
			}

			public DbContextOptionsBuilder<DatabaseContext> OpsBuilder { get; set; }
			public DbContextOptions<DatabaseContext> DbOptions { get; set; }
			private AppConfiguration Settings { get; set; }
		}

		public static  OptionsBuild Options = new OptionsBuild();

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<Laptop> Laptops { get; set; }
		public DbSet<Camera> Cameras { get; set; }
		public DbSet<Smartphone> SmartPhones{ get; set; }
		public DbSet<User> Users { get; set; }
	}
}
