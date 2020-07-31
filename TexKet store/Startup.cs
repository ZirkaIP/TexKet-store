using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using Common.Users.Models;
using DAL.DataContext;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Common.Interfaces;

namespace TexKet_store
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public Startup(IConfiguration configuration) =>
			Configuration = configuration;
		public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(
					Configuration["ConnectionStrings:DefaultConnection"]));
			services.AddIdentity<AppUser, AppRole>()
				.AddEntityFrameworkStores<DatabaseContext>()
				.AddDefaultTokenProviders();
			services.AddMvc();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddSession();
			var loggingConfiguration = new ConfigurationBuilder().AddJsonFile("logging.settings.json").Build();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSession();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();
			app.UseStatusCodePages();
			app.UseAuthentication();
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}"
				);
			});
		}
	}
}
