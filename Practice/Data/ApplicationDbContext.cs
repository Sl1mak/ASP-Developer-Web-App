using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practice;

namespace Practice.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> // Заменили DbContext на IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; } // Таблица для игр

    }
}
