﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.DataContext
{
	public class DatabaseContextFactory: IDesignTimeDbContextFactory<DatabaseContext>

	{
		public DatabaseContext CreateDbContext(string[] args)
		{
			AppConfiguration appConfig = new AppConfiguration();
			var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			optionsBuilder.UseSqlServer(appConfig.SqlConnectionString);
			return new DatabaseContext(optionsBuilder.Options);
		}
	}
}
