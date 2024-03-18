using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Sliders.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto?>
{
    private readonly ShopContext _context;

    public GetSliderByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SliderDto?> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Slider.FirstOrDefaultAsync(s => s.Id == request.SliderId);
        if (slider == null) { return null; }
        return new SliderDto()
        {
            ImageName=slider.ImageName,
            Link=slider.Link,
            Title=slider.Title,
        };



    }
}



