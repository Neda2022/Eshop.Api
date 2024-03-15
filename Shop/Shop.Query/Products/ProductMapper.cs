
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products;

    public static class ProductMapper
    {
    public static ProductDto Map(this Product? product)
    {
        if (product == null) return null;
        return new ProductDto()
        {
            Id = product.Id,
            CreationDate = product.CreateDate,
            Description = product.Description,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title,
            SeoData = product.SeoData,
            Specifications = product.Specifications.Select(s => new ProductSpecificationDto
            {
                Value = s.Value,
                Key = s.Key,

            }).ToList(),
            Images = product.Images.Select(s => new ProductImageDto()
            {
                Id = s.Id,
                CreationDate = s.CreateDate,
                ImageName = s.ImageName,
                ProductId = s.ProductId,
                Sequence = s.Sequence

            }).ToList(),
            Category = new() { Id = product.CategoryId },
            SubCategory = new() { Id = product.SubCategoryId },
            SeconderyCategory = product.SeconderyCategoryId != null ? new()
            {
                Id=(long)product.SeconderyCategoryId

            }:null,


        };
    }

    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            CreationDate = product.CreateDate,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title,
            


        };
    }

    public static async Task SetCategories(this ProductDto product, ShopContext context)
    {
        var category = await context.Categories
            .Where(f => f.Id == product.Category.Id)
            .Select(s=>new ProductCategoryDto
            {
                Id=s.Id,
                Slug=s.Slug,
                ParantId=s.ParantId,
                SeoData=s.SeoData,
                Title=s.Title,
            })
            .FirstOrDefaultAsync();

        var subCategory = await context.Categories
            .Where(f => f.Id == product.SubCategory.Id)
            .Select(s => new ProductCategoryDto
            {
                Id = s.Id,
                Slug = s.Slug,
                ParantId = s.ParantId,
                SeoData = s.SeoData,
                Title = s.Title,
            })
            .FirstOrDefaultAsync();
        if (product.SeconderyCategory != null)
        {
            var secondaryCategory = await context.Categories
                        .Where(f => f.Id == product.SeconderyCategory.Id)
                        .Select(s => new ProductCategoryDto
                        {
                            Id = s.Id,
                            Slug = s.Slug,
                            ParantId = s.ParantId,
                            SeoData = s.SeoData,
                            Title = s.Title,
                        })
                        .FirstOrDefaultAsync();
            if (secondaryCategory != null)
                product.SeconderyCategory = secondaryCategory;
        }
        
        if (category != null)
            product.Category = category;

        if (subCategory != null)
            product.SubCategory = subCategory;

        


    }

}

