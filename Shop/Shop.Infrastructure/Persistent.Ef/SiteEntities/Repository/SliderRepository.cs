using Shop.Domain.Entities.SiteEntity;
using Shop.Domain.Entities.SiteEntity.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repository
{
    internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Slider slider)
        {
            _context.Slider.Remove(slider);
        }
    }
}
