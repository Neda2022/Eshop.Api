

using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.SiteEntity;

namespace Shop.Application.SiteEntities.Banners.Edit;

public record EditBannerCommand(long Id,string Link, IFormFile? ImageFile, BannerPosition Position) : IBaseCommand;
