using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWshop.Application.Interface;
using SWshop.Domain.Entities;
using SWshop.Domain.Interfaces.Services;

namespace SWshop.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return _productService.FindByName(name);
        }
    }
}
