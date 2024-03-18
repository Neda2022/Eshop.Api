using Common.Query.Filter;

namespace Shop.Query.Sellers.DTOs;

public class SellerFilterParam:BaseFilterParam
{
    public string ShopName { get;  set; }
    public string NationalCode { get;  set; }
}