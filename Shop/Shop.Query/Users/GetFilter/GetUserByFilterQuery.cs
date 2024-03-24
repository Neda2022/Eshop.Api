

using Common.Query;
using Common.Query.Filter;
using Shop.Query.Users.DTOs;
using System.Linq;

namespace Shop.Query.Users.GetFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}



