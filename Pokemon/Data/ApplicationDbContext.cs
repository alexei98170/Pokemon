using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
