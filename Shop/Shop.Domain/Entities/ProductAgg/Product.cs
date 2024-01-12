using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.Entities.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Common.Utils;

namespace Shop.Domain.Entities.ProductAgg;

public class Product:AggregateRoot
    {
    private Product()
    {
            
    }
   
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public long SeconderyCategoryId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    public Product(
       string title,
       string imageName,
       string description,
       long categoryId,
       long subCategoryId,
       long seconderyCategoryId,
       string slug,
       SeoData seoData,
       IProductDomainService domainService)
    {
        Guard(title, slug, imageName, description, domainService);

        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SeconderyCategoryId = seconderyCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void Edit(
      string title,
      string imageName,
      string description,
      long categoryId,
      long subCategoryId,
      long seconderyCategoryId,
      string slug,
      SeoData seoData,
      IProductDomainService domainService)
    {
        Guard(title,slug,imageName,description,domainService);
        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SeconderyCategoryId = seconderyCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

     public void AddImage(ProductImage image)
    {
        image.ProductId = Id;
        Images.Add(image);
    }
    public void RemoveImage(long id)
    {
        var image = Images.FirstOrDefault(f => f.Id == id);
        if (image == null)
            return;
        Images.Remove(image);

    }

    public void SetSpecification(List<ProductSpecification> specifications)
    {
        specifications.ForEach(s => s.ProductId = Id);
        Specifications= specifications; 
    }
    public void Guard(string title,string slug,string imageName, string description,IProductDomainService domainService)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));
        NullOrEmtyDomainDataException.CheckString(imageName, nameof(imageName));
        NullOrEmtyDomainDataException.CheckString(description, nameof(description));
        if(slug != Slug)
            if(domainService.SlugIsExist(slug.ToSlug()))
                throw new SlugIsDuplicatedException();
    }

}

