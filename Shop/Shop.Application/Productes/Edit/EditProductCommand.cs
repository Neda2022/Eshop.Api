

using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.ProductAgg;

namespace Shop.Application.Productes.Edit;

public class EditProductCommand:IBaseCommand
    {
    public long ProductId { get; private set; }
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

}



