

using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.SiteEntity;

public class Banner:BaseEntity
    {
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition Position { get; private set; }
    private Banner()
    {

    }
    public Banner(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }
    public void Edit(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }
    public void Guard(string link, string imageName)
    {
        NullOrEmtyDomainDataException.CheckString(link, nameof(link));
        NullOrEmtyDomainDataException.CheckString(imageName, nameof(imageName));

    }
}

