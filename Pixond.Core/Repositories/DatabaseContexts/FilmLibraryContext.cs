using Pixond.Model;
using Microsoft.EntityFrameworkCore;
using Pixond.Model.Entitites;
using Pixond.Model.Entities;

namespace Pixond.Data
{
    public class FilmLibraryContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        public FilmLibraryContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public FilmLibraryContext(DbContextOptions<FilmLibraryContext> options) : base(options)
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Films)
                .UsingEntity<FilmGenre>(
                    x => x.HasOne(x => x.Genre)
                    .WithMany().HasForeignKey(x => x.GenreId),
                    x => x.HasOne(x => x.Film)
                    .WithMany().HasForeignKey(x => x.FilmId));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
