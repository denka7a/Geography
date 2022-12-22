using Geography.Data.Data.Models;
using Geography.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Data
{
    public class GeographyDbContext : IdentityDbContext<GeographyUser>
    {
        public GeographyDbContext(DbContextOptions<GeographyDbContext> options)
            : base(options)
        { }

        public DbSet<GeographyUser> GeographyUsers { get; set; }
        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<UserSouvenir> UserSouvenirs { get; set; }
        public DbSet<NatureType> NatureTypes { get; set; }
        public DbSet<NatureObject> NatureObjects { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Hotel> Hotels { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserSouvenir>().HasOne(x => x.GeographyUser)
                .WithMany(y => y.UserSouvenirs)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserSouvenir>().HasOne(x => x.Souvenir)
                .WithMany(y => y.UserSouvenirs)
                .HasForeignKey(g => g.SouvenirId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserSouvenir>().HasKey(x => x.Id);
            builder.Entity<UserSouvenir>().Property(x => x.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}
