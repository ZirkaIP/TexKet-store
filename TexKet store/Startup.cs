using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Common.Interfaces;
using Common.Users.Models;
using DAL.DataContext;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TexKet_store.Settings;
using Swashbuckle.AspNetCore.Swagger;
using TexKet_store.Extensions;

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
			services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
			var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(
					Configuration["ConnectionStrings:DefaultConnection"]));
			services.AddIdentity<AppUser, AppRole>(options =>
				{
					options.Password.RequiredLength = 8;
					options.Password.RequireNonAlphanumeric = true;
					options.Password.RequireUppercase = true;
					options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
				})
				.AddEntityFrameworkStores<DatabaseContext>()
				.AddDefaultTokenProviders();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "TexKet store", Version = "v1" });

				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT containing userid claim",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
				});

				var security =
					new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Id = "Bearer",
									Type = ReferenceType.SecurityScheme
								},
								UnresolvedReference = true
							},
							new List<string>()
						}
					};
				options.AddSecurityRequirement(security);
			});
			services.AddAutoMapper(typeof(Startup));
			services.AddMvc();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IShopCartService, ShopCartService>();
			services.AddSession();
			services.AddAuth(jwtSettings);
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
			app.UseRouting();
			app.UseAuth();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					"default",
					"{controller=Home}/{action=Index}/{id?}");
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.RoutePrefix = "swagger";
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "TexKet Store");
			});

			
		}

	}
}
