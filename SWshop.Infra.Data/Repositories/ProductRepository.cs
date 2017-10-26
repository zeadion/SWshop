using System.Collections.Generic;
using SWshop.Domain.Entities;
using System.Linq;
using SWshop.Domain.Interfaces.Repositories;

namespace SWshop.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> FindByName(string name)
        {
            return Db.Products.Where(p => p.Name.Contains(name));
        }
    }
}
