using Common.Domain;
using Common.Domain.Exceptions;
using System;

namespace Shop.Domain.Entities.SiteEntity;

public class Slider:BaseEntity
    {
    
    public string Title { get; private set; }
    public string Link { get; private set; }
    public string ImageName { get; private set; }

    private Slider()
    {

    }
    public Slider(string title, string link, string imageName)
    {
        Guard( title,  link,  imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
    }

   
    public void Edit(string title, string link, string imageName)
    {
        Guard(title, link, imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
    }
    public void Guard(string title,string link, string imageName)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));
        NullOrEmtyDomainDataException.CheckString(link, nameof(link));
        NullOrEmtyDomainDataException.CheckString(imageName, nameof(imageName));

    }

}

