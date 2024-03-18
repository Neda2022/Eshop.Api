using Common.Query;
using Shop.Domain.Entities.SiteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Banners.DTOs
{
    public class BannerDto:BaseDto
    {
        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }
}
