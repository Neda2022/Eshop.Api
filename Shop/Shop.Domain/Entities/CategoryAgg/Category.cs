using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.Entities.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Common.Utils;

namespace Shop.Domain.Entities.CategoryAgg;

    public class Category:AggregateRoot
    {
    private Category()
    {
        Childs = new List<Category>();
    }
    public Category(string title, string slug, SeoData seoData, 
        ICategoryDomainService domainService)
    {
        Guard(title, slug, domainService);
        slug = slug?.ToSlug();
        Title = title;
        Slug = slug;
        SeoData = seoData;
        Childs = new List<Category>();
    }

    

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParantId { get; private set; }
    public List<Category> Childs { get; private set; }

    public void Edit(string title, string slug, SeoData seoDatas, ICategoryDomainService domainService)
    {
        Guard(title, slug, domainService);

        slug = slug?.ToSlug();
    }
    public void AddChild(string title, string slug, SeoData seoDatas,ICategoryDomainService domainService)
    {
        Childs.Add(new Category(title, slug,seoDatas, domainService)
        {
            ParantId=Id
        });
    }
    public void Guard(string title, string slug,ICategoryDomainService domainService)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));
        NullOrEmtyDomainDataException.CheckString(slug, nameof(slug));
        if (slug != Slug)
            if (domainService.IsSlugExsit(slug.ToSlug()))
                throw new SlugIsDuplicatedException();
    }
}

