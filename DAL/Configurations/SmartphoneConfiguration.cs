using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
	class SmartphoneConfiguration : IEntityTypeConfiguration<Smartphone>
	{
	public void Configure(EntityTypeBuilder<Smartphone> builder)
	{
		builder
			.HasKey(s => s.Id);
		builder
			.Property(s => s.Id)
			.UseIdentityColumn();
		builder
			.Property(s => s.Brand)
			.IsRequired()
			.HasMaxLength(30);

		builder
			.Property(s => s.Model)
			.IsRequired()
			.HasMaxLength(50);

		builder
			.Property(s => s.AvailableQuantity)
			.IsRequired();

		builder
			.Property(s => s.Price)
			.IsRequired();

	}
	}
}
