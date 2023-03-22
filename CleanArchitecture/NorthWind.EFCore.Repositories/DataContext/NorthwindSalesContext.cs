namespace NorthWind.EFCore.Repositories.DataContext
{
    public class NorthwindSalesContext : DbContext
    {
        public NorthwindSalesContext(DbContextOptions<NorthwindSalesContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}