using System.Collections.Generic;
using TechFayre.Gql.Data;
using TechFayre.Gql.Data.Entities;

namespace TechFayre.Gql.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }
    }
}
