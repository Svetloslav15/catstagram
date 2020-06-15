namespace Catstagram.Server.Data
{
    using Catstagram.Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CatstagramDbContext : IdentityDbContext<User>
    {
        public DbSet<Cat> Cats { get; set; }
        
        public CatstagramDbContext(DbContextOptions<CatstagramDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Cat>()
                .HasOne(cat => cat.User)
                .WithMany(user => user.Cats)
                .HasForeignKey(cat => cat.UserId);

            base.OnModelCreating(builder);
        }
    }
}