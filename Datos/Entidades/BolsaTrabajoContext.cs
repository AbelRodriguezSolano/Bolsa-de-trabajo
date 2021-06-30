using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



#nullable disable

namespace Datos.Entidades
{
    public partial class BolsaTrabajoContext : DbContext
    {
        public BolsaTrabajoContext()
        {
        }

        public BolsaTrabajoContext(DbContextOptions<BolsaTrabajoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vacante> Vacantes { get; set; }
        public virtual DbSet<Procedimientos.Ver_Vacantes> Ver_Vacantes { get; set; }    
        public virtual DbSet<Procedimientos.Ver_Vacantes_Categoria> Ver_Vacantes_Categoria { get; set; }
        public virtual DbSet<Procedimientos.Insert_Vacante> Inset_Vacantes { get; set; }
        public virtual DbSet<Procedimientos.Filtrar_Vacante> Filtrar_Vacantes { get; set; }
        public virtual DbSet<Procedimientos.Detalles_Vacante> Detalles_Vacantes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.; database=BolsaTrabajo; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Contrasena).IsUnicode(false);

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Rol).IsUnicode(false);
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.Property(e => e.Company).IsUnicode(false);

                entity.Property(e => e.CorreoAplicar).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.DireccionUrl).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Posicion).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK__Vacante__Categor__2D27B809");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK__Vacante__Usuario__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
