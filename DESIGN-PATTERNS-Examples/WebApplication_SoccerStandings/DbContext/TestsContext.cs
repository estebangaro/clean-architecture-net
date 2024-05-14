using Microsoft.EntityFrameworkCore;

namespace WebApplication_SoccerStandings.DbContext;

public partial class TestsContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TestsContext()
    {
    }

    public TestsContext(DbContextOptions<TestsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SoccerTeam> SoccerTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-HB4DGG3T\\SQLEXPRESS;Initial Catalog=Tests;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SoccerTeam>(entity =>
        {
            entity.ToTable("Soccer_Teams");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Stadium)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
