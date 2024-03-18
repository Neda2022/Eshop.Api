

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Banners.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById;

    public record GetBannerByIdQuery(long BannerId):IQuery<BannerDto?>;

public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto?>
{
    private readonly ShopContext _context;
    public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banner.FirstOrDefaultAsync(b => b.Id == request.BannerId, cancellationToken);
       if (banner == null) { return null; }
        return new BannerDto()
        {

            Id = banner.Id,
            CreationDate = banner.CreateDate,
            ImageName = banner.ImageName,
            Link = banner.Link,
            Position = banner.Position

        };
    }
}

