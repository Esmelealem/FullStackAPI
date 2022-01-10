using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Data
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Status> Statuses { get; set; }

        
    }
}
