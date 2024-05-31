using BibliotecaAuth.Models;
using BibliotecaF1.Models;
using BibliotecaGuiaJuegos.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyectos_WebApi.NETCore8.Connection
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AuthPerfilModel> AuthPerfil { get; set; }
        public DbSet<AuthUsuarioModel> AuthUsuario { get; set; }

        public DbSet<F1CarreraModel> F1Carreras { get; set; }   
        public DbSet<F1CircuitoModel> F1Circuitos { get; set; }
        public DbSet<F1EscuderiaModel> F1Escuderias { get; set; }
        public DbSet<F1PaisModel> F1Paises { get; set; }
        public DbSet<F1PilotoModel> F1Pilotos { get; set; } 

        public DbSet<GJJuegoModel> GJJuegos { get; set; }
        public DbSet<GJPersonajeModel> GJPersonajes { get; set; }
        public DbSet<GJFuenteModel> GJFuentes { get; set; }
        public DbSet<GJFondoImgModel> GJFondosImg { get; set; }
        public DbSet<GJGuiaModel> GJGuias { get; set; }
        public DbSet<GJGuiaUsuarioModel> GJGuiasUsuario { get; set; }
        public DbSet<GJAventuraModel> GJAventuras { get; set; }
        public DbSet<GJAventuraUsuarioModel> GJAventurasUsuario { get; set; }
        public DbSet<GJAventuraImgModel> GJAventurasImg { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthPerfilModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<AuthUsuarioModel>(t =>
            {
                t.HasKey(c => c.Id);    
                t.Property(c => c.Id).HasColumnType("VARCHAR(450)");
                t.Property(c => c.Email).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Usuario).HasColumnType("VARCHAR(50)");
                t.Property(c => c.AuthHash).HasColumnType("VARCHAR(256)");
                t.Property(c => c.AuthSalt).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.AuthPerfil)
                    .WithMany(tr => tr.AuthUsuarios)
                    .HasForeignKey(c => c.IdPerfil)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<F1CarreraModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Clima).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.F1Circuito)
                    .WithMany(tr => tr.F1Carreras)
                    .HasForeignKey(c => c.IdCircuito)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<F1CircuitoModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(256)");
            });

            modelBuilder.Entity<F1EscuderiaModel>(t => {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.UrlAuto).HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<F1PaisModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.UrlBandera).HasColumnType("VARCHAR(50)");
            });
            
            modelBuilder.Entity<F1PilotoModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(100)");
                t.Property(c => c.UrlPerfil).HasColumnType("VARCHAR(50)");
                t.HasOne(tr => tr.F1Escuderia)
                    .WithMany(tr => tr.F1Piloto)
                    .HasForeignKey(c => c.IdEscuderia)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJJuegoModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Descripcion).HasColumnType("VARCHAR(256)");
                t.Property(c => c.Img).HasColumnType("VARCHAR(256)");
            });

            modelBuilder.Entity<GJPersonajeModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Descripcion).HasColumnType("VARCHAR(256)");
                t.Property(c => c.Img).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.GJJuego)
                    .WithMany(tr => tr.GJPersonajes)
                    .HasForeignKey(c => c.Id_Juego)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJFuenteModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(50)");
                t.Property(c => c.Img).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.GJJuego)
                    .WithMany(tr => tr.GJFuentes)
                    .HasForeignKey(c => c.Id_Juego)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJFondoImgModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Img).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.GJJuego)
                    .WithMany(tr => tr.GJFondosImg)
                    .HasForeignKey(c => c.Id_Juego)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJGuiaModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Nombre).HasColumnType("VARCHAR(100)");
                t.HasOne(tr => tr.GJJuego)
                    .WithMany(tr => tr.GJGuias)
                    .HasForeignKey(c => c.Id_Juego)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJGuiaUsuarioModel>(t =>
            {
                t.HasKey(c => new { c.Id_Guia, c.Id_Usuario });
                t.Property(c => c.Id_Usuario).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.GJGuia)
                    .WithMany(tr => tr.GJGuiaUsuario)
                    .HasForeignKey(c => c.Id_Guia)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJAventuraModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Descripcion).HasColumnType("VARCHAR(800)");
                t.HasOne(tr => tr.GJGuia)
                    .WithMany(tr => tr.GJAventura)
                    .HasForeignKey(c => c.Id_Guia)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJAventuraUsuarioModel>(t =>
            {
                t.HasKey(c => new { c.Id_Aventura, c.Id_Usuario });
                t.HasOne(tr => tr.GJAventura)
                    .WithMany(tr => tr.GJAventuraUsuario)
                    .HasForeignKey(c => c.Id_Aventura)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GJAventuraImgModel>(t =>
            {
                t.HasKey(c => c.Id);
                t.Property(c => c.Img).HasColumnType("VARCHAR(256)");
                t.HasOne(tr => tr.GJAventura)
                    .WithMany(tr => tr.GJAventuraImg)
                    .HasForeignKey(c => c.Id_Aventura)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
