using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
	class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.HasKey(l => l.ProductId);

			builder
				.Property(l => l.ProductId)
				.ValueGeneratedOnAdd();

			builder
				.Property(l => l.Brand)
				.IsRequired()
				.HasMaxLength(30);

			builder
				.Property(l => l.Model)
				.IsRequired()
				.HasMaxLength(50);

			builder
				.Property(l => l.AmountAvailable)
				.IsRequired();

			builder
				.Property(l => l.Price)
				.IsRequired();
		}
	}
}
