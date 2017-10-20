using SWshop.Domain.Entities;
using System.Collections.Generic;

namespace SWshop.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> FindByName(string name);
    }
}
