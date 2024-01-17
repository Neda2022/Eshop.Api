

using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChild;

public record AddChidCategoryCommand(long ParantId,string Title, string Slug, SeoData SeoData) :IBaseCommand;

