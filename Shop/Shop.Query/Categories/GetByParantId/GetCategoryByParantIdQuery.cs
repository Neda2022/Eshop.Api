
using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParantId;

public record GetCategoryByParantIdQuery(long ParantId):IQuery<List<ChildCategoryDto>>;
