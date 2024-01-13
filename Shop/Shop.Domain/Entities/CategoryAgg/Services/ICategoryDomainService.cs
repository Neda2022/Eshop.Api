using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        public bool IsSlugExsit(string slug);
    }
}
