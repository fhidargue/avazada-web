using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Entities
{
    public partial class GimnasioContext : DbContext
    {
        public GimnasioContext()
        {
        }

        public GimnasioContext(DbContextOptions<GimnasioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Ejercicio> Ejercicios { get; set; }
        public virtual DbSet<Medida> Medidas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Rutina> Rutinas { get; set; }
        public virtual DbSet<RutinaXejercicio> RutinaXejercicios { get; set; }
        public virtual DbSet<Subscripcion> Subscripcions { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=25.14.47.22;Database=Gimnasio;Uid=PGAW;Pwd=HolaMundo123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PK__Bitacora__896F993D7DDCCF05");

                entity.ToTable("Bitacora");

                entity.Property(e => e.IdBitacora).HasColumnName("Id_Bitacora");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Bitacora__Fecha__6383C8BA");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio)
                    .HasName("PK__Ejercici__D213A07FF0CC13EB");

                entity.ToTable("Ejercicio");

                entity.Property(e => e.IdEjercicio).HasColumnName("Id_Ejercicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Equipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intensidad)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.HasKey(e => e.IdMedida)
                    .HasName("PK__Medidas__7BA5D03F8AD4506C");

                entity.Property(e => e.IdMedida).HasColumnName("Id_Medida");

                entity.Property(e => e.Altura).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Peso).HasColumnType("decimal(3, 3)");

                entity.Property(e => e.PorcentajeGrasa).HasColumnName("Porcentaje_Grasa");

                entity.Property(e => e.PorcentajeMasa).HasColumnName("Porcentaje_Masa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medida)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medidas__Id_Usua__5165187F");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__55932E86FDD6D848");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK__Rutina__7C95EE403CD9CC2A");

                entity.ToTable("Rutina");

                entity.Property(e => e.IdRutina).HasColumnName("Id_Rutina");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Asignacion");

                entity.Property(e => e.IdUsuarioCliente).HasColumnName("Id_Usuario_Cliente");

                entity.Property(e => e.IdUsuarioEntrenador).HasColumnName("Id_Usuario_Entrenador");

                entity.HasOne(d => d.IdUsuarioClienteNavigation)
                    .WithMany(p => p.RutinaIdUsuarioClienteNavigations)
                    .HasForeignKey(d => d.IdUsuarioCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rutina__Id_Usuar__29221CFB");

                entity.HasOne(d => d.IdUsuarioEntrenadorNavigation)
                    .WithMany(p => p.RutinaIdUsuarioEntrenadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioEntrenador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rutina__Id_Usuar__2A164134");
            });

            modelBuilder.Entity<RutinaXejercicio>(entity =>
            {
                entity.HasKey(e => e.IdRutinaEjercicio)
                    .HasName("PK__RutinaXE__A31F6EC38F760897");

                entity.ToTable("RutinaXEjercicio");

                entity.Property(e => e.IdRutinaEjercicio).HasColumnName("ID_Rutina_Ejercicio");

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEjercicio).HasColumnName("Id_Ejercicio");

                entity.Property(e => e.IdRutina).HasColumnName("Id_Rutina");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.RutinaXejercicios)
                    .HasForeignKey(d => d.IdEjercicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RutinaXEj__Id_Ej__2DE6D218");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.RutinaXejercicios)
                    .HasForeignKey(d => d.IdRutina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RutinaXEj__Id_Ru__2CF2ADDF");
            });

            modelBuilder.Entity<Subscripcion>(entity =>
            {
                entity.HasKey(e => e.IdSubscripcion)
                    .HasName("PK__Subscrip__63FF9A24BE7DB825");

                entity.ToTable("Subscripcion");

                entity.Property(e => e.IdSubscripcion).HasColumnName("Id_Subscripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Vencimiento");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Metodo_Pago");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Subscripcions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscripc__Id_Us__5FB337D6");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__Sucursal__34DDD635388A9769");

                entity.ToTable("Sucursal");

                entity.Property(e => e.IdSucursal).HasColumnName("Id_Sucursal");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE245E8D5D0");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Cedula, "UQ__Usuario__B4ADFE3891C8C22A")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.IdSucursal).HasColumnName("Id_Sucursal");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__Id_Rol__4D94879B");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__Id_Sucu__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
