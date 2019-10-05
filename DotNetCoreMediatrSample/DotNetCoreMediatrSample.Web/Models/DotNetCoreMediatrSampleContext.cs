using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMediatrSample.Web.Models
{
    public class DotNetCoreMediatrSampleContext : DbContext
    {
        public DotNetCoreMediatrSampleContext(DbContextOptions<DotNetCoreMediatrSampleContext> op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
