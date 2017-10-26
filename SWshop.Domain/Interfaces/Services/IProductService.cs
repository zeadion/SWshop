using System.Collections.Generic;
using SWshop.Domain.Entities;

namespace SWshop.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> FindByName(string name);
    }
}
