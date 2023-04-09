using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreMvc.Models.Domain;

namespace MovieStoreMVC.Models.Domain
{
    public class DatabaseContext: IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) 
        {

        }
        public DbSet<Genre> Genre_Table { get; set; } //creates the database of Genre model
                                                //having name Genre_Table
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}
