using AdvertisingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<PhotoUrl> PhotoUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhotoUrl>()
           .HasOne(a => a.Advertisement)
           .WithMany(c => c.PhotoUrls)
           .HasForeignKey(u => u.AdvertisementId);

            modelBuilder.Entity<Advertisement>().Property(t => t.Title).HasMaxLength(200);
            modelBuilder.Entity<Advertisement>().Property(d => d.Description).HasMaxLength(1000);
        }
    }
}
