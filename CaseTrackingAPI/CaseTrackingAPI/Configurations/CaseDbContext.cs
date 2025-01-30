using CaseTrackingAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Configurations
{
    public class CaseDbContext : IdentityDbContext<User>
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) 
        {

        }

        public DbSet<DCase> Cases { get; set; } = null!;
        public DbSet<DTask> Tasks { get; set; } = null!;
        public DbSet<DFile> Files { get; set; } = null!;
        public DbSet<PNG> PNGs { get; set; } = null!;
        public DbSet<PDF> PDFs { get; set; } = null!;
        public DbSet<Statement> Statements { get; set; } = null!;
        public DbSet<BiologicalTrace> BiologicalTraces { get; set; } = null!;
        public DbSet<Evidence> Evidences { get; set; } = null!;
        public DbSet<BiologicalEvidence> BiologicalEvidences { get; set; } = null!;
        public DbSet<PhysicalEvidence> PhysicalEvidences { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Witness> Witnesses { get; set; } = null!;
        public DbSet<Suspect> Suspects { get; set; } = null!;
        public DbSet<Victim> Victims { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Detektiv", NormalizedName = "DETEKTIV" },
                    new IdentityRole { Name = "Prokuror", NormalizedName = "PROKUROR" }
                );
        }
    }
}