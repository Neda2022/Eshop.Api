using Shop.Domain.Entities.CategoryAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Productes
{
    public class ProduductDomainService : IProductDomainService
    {
        private readonly IProductRepository _repository;

        public ProduductDomainService(IProductRepository repository)
        {
            _repository = repository;
        }
        public bool SlugIsExist(string slug)
        {

            return _repository.Exists(s => s.Slug == slug);
        }
    }
}
