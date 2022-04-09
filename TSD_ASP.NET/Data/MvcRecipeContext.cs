using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcRecipeContext : DbContext
    {
        public MvcRecipeContext(DbContextOptions<MvcRecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> CookBook { get; set; }
    }
}
