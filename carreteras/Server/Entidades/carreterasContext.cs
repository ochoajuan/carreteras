using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class carreterasContext : DbContext
    {
        public carreterasContext()
        {
        }

        public carreterasContext(DbContextOptions<carreterasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carretera> Carreteras { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Comuna> Comunas { get; set; }
        public virtual DbSet<Confluencia> Confluencias { get; set; }
        public virtual DbSet<Tramo> Tramos { get; set; }
        public virtual DbSet<Tramoscomuna> Tramoscomunas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ASUSPORTATIL;Database=carreteras; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Carretera>(entity =>
            {
                entity.ToTable("carreteras");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Carreteras)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_carreteras_categorias");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(150)
                    .HasColumnName("nombre_categoria");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.ToTable("comunas");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Confluencia>(entity =>
            {
                entity.ToTable("confluencias");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CarreteraId).HasColumnName("carretera_id");

                entity.Property(e => e.TramocomunaId).HasColumnName("tramocomuna_id");

                entity.HasOne(d => d.Carretera)
                    .WithMany(p => p.Confluencia)
                    .HasForeignKey(d => d.CarreteraId)
                    .HasConstraintName("FK_confluencias_carreteras");

                entity.HasOne(d => d.Tramocomuna)
                    .WithMany(p => p.Confluencia)
                    .HasForeignKey(d => d.TramocomunaId)
                    .HasConstraintName("FK_confluencias_tramoscomunas");
            });

            modelBuilder.Entity<Tramo>(entity =>
            {
                entity.ToTable("tramos");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CarreteraId).HasColumnName("carretera_id");

                entity.Property(e => e.ConfluyeId).HasColumnName("confluye_id");

                entity.Property(e => e.FinalCarretera).HasColumnName("final_carretera");

                entity.Property(e => e.PrincipioCarretera).HasColumnName("principio_carretera");

                entity.HasOne(d => d.Carretera)
                    .WithMany(p => p.Tramos)
                    .HasForeignKey(d => d.CarreteraId)
                    .HasConstraintName("FK_tramos_carreteras");

                entity.HasOne(d => d.Confluye)
                    .WithMany(p => p.Tramos)
                    .HasForeignKey(d => d.ConfluyeId)
                    .HasConstraintName("FK_tramos_confluencias");
            });

            modelBuilder.Entity<Tramoscomuna>(entity =>
            {
                entity.ToTable("tramoscomunas");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ComunaId).HasColumnName("comuna_id");

                entity.Property(e => e.Kmubicacion).HasColumnName("kmubicacion");

                entity.Property(e => e.TramoId).HasColumnName("tramo_id");

                entity.HasOne(d => d.Comuna)
                    .WithMany(p => p.Tramoscomunas)
                    .HasForeignKey(d => d.ComunaId)
                    .HasConstraintName("FK_tramoscomunas_comunas");

                entity.HasOne(d => d.Tramo)
                    .WithMany(p => p.Tramoscomunas)
                    .HasForeignKey(d => d.TramoId)
                    .HasConstraintName("FK_tramoscomunas_tramos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
