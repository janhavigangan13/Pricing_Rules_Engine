using Microsoft.EntityFrameworkCore;
using PricingRulesApi.Models;

namespace PricingRulesApi.Data
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options)
        {
        }

       public DbSet<PricingRule> PricingRules { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
