using TechFayre.Gql.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TechFayre.Gql.Data
{
    public class CarvedRockDbContext: DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
