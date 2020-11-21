using Microsoft.EntityFrameworkCore;
using TesteEzconet.Domain.Models;

namespace TesteEzconet.Persistence
{
    public class TesteEzconetContext : DbContext
    {
        public TesteEzconetContext(DbContextOptions<TesteEzconetContext> options) : base(options)
        {

        }

        public TesteEzconetContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=RAPHAEL-DESKTOP; Initial Catalog=TesteEzconet; Integrated Security=True");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(t => t.UsuarioId);

            modelBuilder.Entity<Sexo>()
                .HasKey(t => t.SexoId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.SexoUsuario)
                .WithOne(u => u.User)
                .HasForeignKey<Sexo>(s => s.SexoId);

            modelBuilder.Entity<Usuario>()
                .Property(t => t.Nome)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.Senha)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.DataNascimento)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.Ativo)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(t => t.SexoId)
                .IsRequired();

            modelBuilder.Entity<Sexo>()
                .Property(t => t.Descricao)
                .HasMaxLength(15);



        }

    }
}
