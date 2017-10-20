using System.Collections;
using System.Collections.Generic;
using SWshop.Domain.Entities;

namespace SWshop.Application.Interface
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> FindByName(string name);
    }
}
