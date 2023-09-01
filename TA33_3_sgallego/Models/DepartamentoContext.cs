using Microsoft.EntityFrameworkCore;

namespace TA33_1_sgallego.Models
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options): base(options) { }

        public DbSet<Almacen> Almacenes { get; set; }

        public DbSet<Caja> Cajas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.NumReferncia);

                entity.ToTable("Caja");

                entity.Property(e => e.NumReferncia)
                    .IsRequired();

                entity.Property(e => e.Contenido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Valor)
                   .IsRequired();

                entity.HasOne(e => e.Almacen)
                    .WithMany(e => e.Caja)
                    .HasForeignKey(e => e.AlmacenCodigo);
            });

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Almacen");

                entity.Property(e => e.Codigo)
                    .IsRequired();

                entity.Property(e => e.Lugar)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Capacidad).HasColumnType("decimal(8, 2)");

            });

        }
    }
}
