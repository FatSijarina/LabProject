using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Configurations
{
    public class CaseDbContext : DbContext
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) 
        {

        }
    }
}