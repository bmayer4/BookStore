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
        public DbSet<Review> Reviews { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

            builder.Entity<Review>(review => {
                 review.HasKey(r => new {  r.BookId, r.UserId });
                 review.HasOne(r => r.Book).WithMany(b => b.Reviews).HasForeignKey(r => r.BookId).OnDelete(DeleteBehavior.Restrict);
                 review.HasOne(r => r.User).WithMany(b => b.Reviews).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}