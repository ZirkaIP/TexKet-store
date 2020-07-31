using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
	class CameraConfiguration : IEntityTypeConfiguration<Camera>
	{
		public void Configure(EntityTypeBuilder<Camera> builder)
		{
			builder
				.HasKey(c => c.Id);
			builder
				.Property(c => c.Id)
				.UseIdentityColumn();
			builder
				.Property(c => c.Brand)
				.IsRequired()
				.HasMaxLength(30);

			builder
				.Property(c => c.Model)
				.IsRequired()
				.HasMaxLength(50);

			builder
				.Property(c => c.AvailableQuantity)
				.IsRequired();

			builder
				.Property(c => c.Price)
				.IsRequired();

		}
	}
}
	
