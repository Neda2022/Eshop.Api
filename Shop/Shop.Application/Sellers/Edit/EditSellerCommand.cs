

using Common.Application;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommand:IBaseCommand
    {
    public EditSellerCommand(long id, string shopName, string nationalCode)
    {
        Id = id;
        ShopName = shopName;
        NationalCode = nationalCode;
    }

    public long Id { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
}
