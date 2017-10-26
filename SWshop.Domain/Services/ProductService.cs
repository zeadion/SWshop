using System.Collections.Generic;
using SWshop.Domain.Entities;
using SWshop.Domain.Interfaces.Repositories;
using SWshop.Domain.Interfaces.Services;

namespace SWshop.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return _productRepository.FindByName(name);
        }
    }
}
