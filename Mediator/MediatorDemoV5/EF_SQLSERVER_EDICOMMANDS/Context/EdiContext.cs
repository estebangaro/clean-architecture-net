using EF_SQLSERVER_EDI_COMMANDS.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLSERVER_EDI_COMMANDS.Context;

public partial class EdiContext : DbContext
{
    public EdiContext()
    {
    }

    public EdiContext(DbContextOptions<EdiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EdiTransactionsCatalog> EdiTransactionsCatalogs { get; set; }

    public virtual DbSet<EdiTransactionsLog> EdiTransactionsLogs { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Pruebas;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EdiTransactionsCatalog>(entity =>
        {
            entity.ToTable("EdiTransactionsCatalog");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(155);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<EdiTransactionsLog>(entity =>
        {
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity.ToTable("Table1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
