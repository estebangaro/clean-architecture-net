namespace NorthWind.EFCore.Repositories.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => new { od.OrderId, od.ProductId });
            builder.Property(od => od.UnitPrice)
                .HasPrecision(8, 2);
        }
    }
}