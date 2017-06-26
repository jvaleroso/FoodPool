using FoodPool.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.Data
{
    public class FoodPoolContext: IdentityDbContext<AppUser>
    {
        public FoodPoolContext(DbContextOptions<FoodPoolContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Stall> Stalls { get; set; }
    }
}
