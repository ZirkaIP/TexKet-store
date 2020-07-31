using System;
using System.Collections.Generic;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
	class LaptopConfiguration : IEntityTypeConfiguration<Laptop>
	{
		public void Configure(EntityTypeBuilder<Laptop> builder)
		{
			builder
				.HasKey(l => l.Id);
			builder
				.Property(l => l.Id)
				.UseIdentityColumn();
			builder
				.Property(l => l.Brand)
				.IsRequired()
				.HasMaxLength(30);

			builder
				.Property(l => l.Model)
				.IsRequired()
				.HasMaxLength(50);

			builder
				.Property(l => l.AvailableQuantity)
				.IsRequired();

			builder
				.Property(l => l.Price)
				.IsRequired();

		}
	}
}
