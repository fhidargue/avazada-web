using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Entities
{
    public partial class gimnasioContext : DbContext //IdentityDbContext
    {
        public gimnasioContext()
        {
            /*var optionsBuilder = new DbContextOptionsBuilder<gimnasioContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);*/
        }

        public gimnasioContext(DbContextOptions<gimnasioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Ejercicio> Ejercicios { get; set; }
        public virtual DbSet<Gimnasio> Gimnasios { get; set; }
        public virtual DbSet<Medida> Medidas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Rutina> Rutinas { get; set; }
        public virtual DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
        public virtual DbSet<Subscripcion> Subscripcions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);*/

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RSUBIIC;Database=gimnasio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);*/

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PK__bitacora__7E4268B06C55C20F");

                entity.ToTable("bitacora");

                entity.Property(e => e.IdBitacora).HasColumnName("id_bitacora");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modulo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__bitacora__id_usu__33D4B598");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio)
                    .HasName("PK__ejercici__7BB4D9DB88499822");

                entity.ToTable("ejercicio");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Equipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("equipo");

                entity.Property(e => e.Intensidad)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("intensidad");
            });

            modelBuilder.Entity<Gimnasio>(entity =>
            {
                entity.HasKey(e => e.IdGimnasio)
                    .HasName("PK__gimnasio__94E00E8593225F40");

                entity.ToTable("gimnasio");

                entity.Property(e => e.IdGimnasio).HasColumnName("id_gimnasio");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contacto");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.HasKey(e => e.IdMedida)
                    .HasName("PK__medidas__E038E090A3585940");

                entity.ToTable("medidas");

                entity.Property(e => e.IdMedida).HasColumnName("id_medida");

                entity.Property(e => e.Altural)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("altural");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Peso)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("peso");

                entity.Property(e => e.PorcentajeGrasa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("porcentaje_grasa");

                entity.Property(e => e.PorcentajeMasa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("porcentaje_masa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medida)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__medidas__id_usua__30F848ED");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__rol__6ABCB5E004527136");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK__rutina__A284966751EF2903");

                entity.ToTable("rutina");

                entity.Property(e => e.IdRutina).HasColumnName("id_rutina");

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_asignacion");

                entity.Property(e => e.IdUsuarioCliente).HasColumnName("id_usuario_cliente");

                entity.Property(e => e.IdUsuarioEntrenador).HasColumnName("id_usuario_entrenador");

                entity.HasOne(d => d.IdUsuarioClienteNavigation)
                    .WithMany(p => p.RutinaIdUsuarioClienteNavigations)
                    .HasForeignKey(d => d.IdUsuarioCliente)
                    .HasConstraintName("FK__rutina__id_usuar__36B12243");

                entity.HasOne(d => d.IdUsuarioEntrenadorNavigation)
                    .WithMany(p => p.RutinaIdUsuarioEntrenadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioEntrenador)
                    .HasConstraintName("FK__rutina__id_usuar__37A5467C");
            });

            modelBuilder.Entity<RutinaEjercicio>(entity =>
            {
                entity.HasKey(e => e.IdRutinasEjercicio)
                    .HasName("PK__rutina_e__818067030E0E57CE");

                entity.ToTable("rutina_ejercicio");

                entity.Property(e => e.IdRutinasEjercicio).HasColumnName("id_rutinas_ejercicio");

                entity.Property(e => e.Dia)
                    .HasColumnType("date")
                    .HasColumnName("dia");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.IdRutina).HasColumnName("id_rutina");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nivel");

                entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");

                entity.Property(e => e.Series).HasColumnName("series");

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.RutinaEjercicios)
                    .HasForeignKey(d => d.IdEjercicio)
                    .HasConstraintName("FK__rutina_ej__id_ej__3B75D760");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.RutinaEjercicios)
                    .HasForeignKey(d => d.IdRutina)
                    .HasConstraintName("FK__rutina_ej__id_ru__3A81B327");
            });

            modelBuilder.Entity<Subscripcion>(entity =>
            {
                entity.HasKey(e => e.IdSubscripcion)
                    .HasName("PK__subscrip__473260419B6C79A4");

                entity.ToTable("subscripcion");

                entity.Property(e => e.IdSubscripcion).HasColumnName("id_subscripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("metodo_pago");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Subscripcions)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__subscripc__id_us__2E1BDC42");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04AD31C2F2F3");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdGimnasio).HasColumnName("id_gimnasio");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdGimnasioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGimnasio)
                    .HasConstraintName("FK__usuario__id_gimn__2B3F6F97");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__usuario__id_rol__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
