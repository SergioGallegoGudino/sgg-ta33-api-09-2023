using Microsoft.EntityFrameworkCore;

namespace TA33_1_sgallego.Models
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options): base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("Empleado");

                entity.Property(e => e.Dni)
                    .IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellidos)
                   .IsRequired()
                   .HasMaxLength(255);

                entity.HasOne(e => e.Departamentos)
                    .WithMany(e => e.Empleados)
                    .HasForeignKey(e => e.DepartamentoCodigo);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Departamento");

                entity.Property(e => e.Codigo)
                    .IsRequired();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Presupuesto).HasColumnType("decimal(8, 2)");

            });

        }
    }
}
