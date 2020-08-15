using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
	 public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder
				.HasKey(o => o.OrderId);

			builder
				.Property(o => o.OrderId)
				.ValueGeneratedOnAdd();

			builder
				.Property(o => o.Amount)
				.IsRequired();

			builder
				.Property(o => o.Email)
				.IsRequired()
				.HasMaxLength(35);

			builder
				.Property(o => o.FirstName)
				.IsRequired()
				.HasMaxLength(20);

			builder
				.Property(o => o.LastName)
				.IsRequired()
				.HasMaxLength(20);

			builder
				.Property(o => o.PhoneNumber)
				.IsRequired()
				.HasMaxLength(12);

			builder
				.Property(o => o.UserAddress)
				.IsRequired()
				.HasMaxLength(150);
		}
	}
}
