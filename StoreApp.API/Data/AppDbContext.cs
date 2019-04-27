using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StoreApp.API.Models;

namespace StoreApp.API.Data
{
    public class AppDbContext: IdentityUserContext<User, int, IdentityUserClaim<int>, IdentityUserLogin<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");
        }
    }
}