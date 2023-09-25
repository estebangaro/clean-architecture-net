using Microsoft.EntityFrameworkCore;

namespace Notifications.Models.EFCore;

public partial class EjemploContext : DbContext
{
    public EjemploContext()
    {
    }

    public EjemploContext(DbContextOptions<EjemploContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emisor> Emisors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    { if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=localhost;Database=ejemplo;Integrated Security=True;TrustServerCertificate=True;"); }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emisor>(entity =>
        {
            entity.ToTable("Emisor");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Capital)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("capital");
            entity.Property(e => e.FechaOperacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaOperacion");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
