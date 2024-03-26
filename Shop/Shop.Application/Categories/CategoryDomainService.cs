using Shop.Domain.Entities.CategoryAgg.Repository;
using Shop.Domain.Entities.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories
{
    public class CategoryDomainService : ICategoryDomainService
    {
       private readonly ICategoryRepository _repository;

        public CategoryDomainService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool IsSlugExsit(string slug)
        {
            return _repository.Exists(s => s.Slug == slug);
        }
    }
}
