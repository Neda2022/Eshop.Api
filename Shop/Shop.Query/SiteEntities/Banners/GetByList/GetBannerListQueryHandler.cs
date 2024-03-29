﻿

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Banners.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetByList;

public class GetBannerListQueryHandler : IQueryHandler<GetBannerListQuery, List<BannerDto>>
{
    private readonly ShopContext _context;

    public GetBannerListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Banner.OrderByDescending(d => d.Id)
            .Select(banner => new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreateDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            }).ToListAsync(cancellationToken);
    }
}
