

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Sliders.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetByList;

public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    private readonly ShopContext _context;

    public GetSliderListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Slider.OrderByDescending(d => d.Id)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreateDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
    }
}
