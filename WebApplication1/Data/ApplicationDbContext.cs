using DataToAdvertisementTransformer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataToAdvertisementTransformer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Keyword> Keywords{ get; set; }
        public DbSet<KeywordLocation> KeywordLocations{ get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<KeywordLocation>()
                .HasOne(k => k.Keyword)
                .WithMany(k => k.KeywordLocations)
                .HasForeignKey(k => k.KeywordId);
        }
    }
}