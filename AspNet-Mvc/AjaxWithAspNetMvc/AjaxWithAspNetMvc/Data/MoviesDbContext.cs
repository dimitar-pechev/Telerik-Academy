using AjaxWithAspNetMvc.Models;
using System.Data.Entity;

namespace AjaxWithAspNetMvc.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Movie> Movies { get; set; }
    }
}