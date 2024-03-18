

using Common.Query;
using Shop.Query.Sellers.DTOs;
using System.Linq;

namespace Shop.Query.Sellers.GetByFilter;

public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParam>
{
    public GetSellerByFilterQuery(SellerFilterParam filterParams) : base(filterParams)
    {
    }
}




