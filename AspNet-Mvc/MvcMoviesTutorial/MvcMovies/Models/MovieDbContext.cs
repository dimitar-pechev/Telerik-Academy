using MvcMovies.Migrations;
using System.Data.Entity;

namespace MvcMovies.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, Configuration>());
        }
    }
}