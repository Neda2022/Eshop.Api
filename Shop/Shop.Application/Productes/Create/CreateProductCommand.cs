

using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.ProductAgg;

namespace Shop.Application.Productes.Create;

public class CreateProductCommand:IBaseCommand
    {
    public CreateProductCommand(string title,
        IFormFile imageFile,
        string description, 
        long categoryId, 
        long subCategoryId,
        long seconderyCategoryId, 
        string slug,
        SeoData seoData,
        List<ProductImage> images, 
        Dictionary<string, string> specifications)
    {
        Title = title;
        ImageFile = imageFile;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SeconderyCategoryId = seconderyCategoryId;
        Slug = slug;
        SeoData = seoData;
        Images = images;
        Specifications = specifications;
    }

    public string Title { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public long SeconderyCategoryId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public Dictionary<string,string> Specifications { get; private set; }

}

