using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Domain.Repositories;
using DatabaseScaffoldApplication.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Infrastructure.Repositories
{
    public class ProductRepository : EFCoreRepository<Product>, IProductRepository
    {
        public ProductRepository(NORTHWNDContext dbContext) : base(dbContext)
        {
        }
    }
}
