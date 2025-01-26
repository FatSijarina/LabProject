using CaseTrackingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Configurations
{
    public class CaseDbContext : DbContext
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) 
        {

        }

        public DbSet<DCase> Cases { get; set; } = null!;
        public DbSet<DTask> Tasks { get; set; } = null!;
        public DbSet<DFile> Files { get; set; } = null!;
        public DbSet<PNG> PNGs { get; set; } = null!;
        public DbSet<PDF> PDFs { get; set; } = null!;
    }
}