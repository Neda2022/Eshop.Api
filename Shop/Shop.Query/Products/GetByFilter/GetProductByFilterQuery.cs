

using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParam>
{
    public GetProductByFilterQuery(ProductFilterParam filterParams) : base(filterParams)
    {
    }
}

