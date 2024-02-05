

using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.SiteEntity;

namespace Shop.Application.SiteEntities.Banners.Create;

public record CreateBannerCommand(string Link, IFormFile ImageFile, BannerPosition Position) :IBaseCommand;
