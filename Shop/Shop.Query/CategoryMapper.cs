using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Domain.Entities.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query;

public static class CategoryMapper
{
    public static CategoryDto Map(this Category? category)
    {

        if (category == null)
            return null;
        return new CategoryDto()
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreationDate = category.CreateDate,
            Childs = category.Childs.MapChild(),
        };

    }
    public static List<CategoryDto> Map(this List<Category> categories)
    {
        var model = new List<CategoryDto>();

        categories.ForEach(category =>
        {
            model.Add(new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                Id = category.Id,
                SeoData = category.SeoData,
                CreationDate = category.CreateDate,
                Childs = category.Childs.MapChild()
            });
        });

        return model;
    }
    public static List<ChildCategoryDto> MapChild(this List<Category> children)
    {
        var model = new List<ChildCategoryDto>();
        children.ForEach(c =>
        {
            model.Add(new ChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreateDate,
                ParantId = (long)c.ParantId,
                Childs = c.Childs.MapSecondaryChild(),
            });



        });
        return model;


    }
    private static List<SecondaryChildCategoryDto> MapSecondaryChild
        (this List<Category> children)
    {
        var model = new List<SecondaryChildCategoryDto>();
        children.ForEach(c =>
        {
            model.Add(new SecondaryChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreateDate,
                ParantId = (long)c.ParantId,

            });



        });
        return model;


    }
   
}

