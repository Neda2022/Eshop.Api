using Common.Domain;

namespace Shop.Domain.Entities.OrderAgg.ValueObjects;

public class OrderDisCount : ValueObject
{
    public OrderDisCount(string discountTitle, int discountAmount)
    {
        DiscountTitle = discountTitle;
        DiscountAmount = discountAmount;
    }

    public string DiscountTitle { get; private set; }
    public int DiscountAmount { get; private set; }

}

