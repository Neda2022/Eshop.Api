using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.CategoryAgg;
using Shop.Domain.Entities.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await _context.Categories.Include(c=>c.Childs).ThenInclude(c=>c.Childs).FirstOrDefaultAsync(f => f.Id == categoryId);
            if (category == null) { return false; }
            var isExistProduct = await _context.products.AnyAsync(f => 
              f.CategoryId == category.Id
            || f.SubCategoryId == categoryId 
            ||f.SeconderyCategoryId == categoryId);
            if (isExistProduct) { return false; }

            //child
            if(category.Childs.Any(c=>c.Childs.Any()))
            {
                _context.RemoveRange(category.Childs.SelectMany(s=>s.Childs));
            }
            //child سطح دوم
            _context.RemoveRange(category.Childs);
            // خود category
            _context.RemoveRange(category);
            return true;
        }
    }
}
