using BibliotecaAuth.Models;
using BibliotecaF1.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyectos_WebApi.NETCore8.Connection
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AuthPerfilModel> AuthPerfil { get; set; }
        public DbSet<AuthUsuarioModel> AuthUsuario { get; set; }

        public DbSet<F1CarreraModel> F1Carreras { get; set; }   
        public DbSet<F1CircuitoModel> F1Circuitos { get; set; }
        public DbSet<F1EscuderiaModel> F1Escuderias { get; set; }
        public DbSet<F1PaisModel> F1Paises { get; set; }
        public DbSet<F1PilotoModel> F1Pilotos { get; set; } 

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
        }
    }
}
