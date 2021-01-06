using ImotiWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ImotiWebsite.Database
{
    public interface IRealEstateContext
    {
        public DbSet<Ad> Ads { get; set; }
    }
    public class RealEstateContext : DbContext, IRealEstateContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {

        }
        public DbSet<Ad> Ads { get; set; }
    }
}