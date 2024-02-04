using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Entities.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SellerAgg;

public class Seller:AggregateRoot
    {
    private Seller()
    {
        
    }
    public Seller(long userId, string shopName,
        string nationalCode, ISellerDomainService domainService)
    {
        Guard(shopName, nationalCode);
        
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
        Inventories = new List<SellerInventory>();
        if (domainService.CheckSellerInfo(this) == false)
            throw new InvalidDomainDataException("اطلاعات نامعتبر است");
        

    }

    public long UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
    public SellerStatus Status { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }
    public DateTime? LastUpdate { get; private set; }
   
    public void Edit(string shopName,SellerStatus status ,string nationalCode
        , ISellerDomainService domainService)
    {
        Guard(shopName,nationalCode);
        if (domainService.IsNationalCodeExistInDatabase(nationalCode))
            throw new InvalidDomainDataException("کد ملی متعلق به شخص دیگری است");
        ShopName = shopName;
        NationalCode = nationalCode;
        Status = status;

    }
    public void AddInventory(SellerInventory inventory)
    {
        if (Inventories.Any(f => f.ProductId == inventory.ProductId))
            throw new InvalidDomainDataException("این محصول قبلا ثبت شده است!");
        Inventories.Add(inventory);
    }
    public void EditInventory(long inventoryId, int count , int price , int? percentageCount)
    {
        var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);

        if (currentInventory == null)
            throw new InvalidDomainDataException("محصول یافت نشد!");

        currentInventory.Edit(count, price, percentageCount);

    }
   
    public void Guard(string shopName, string nationalCode)
    {

        NullOrEmtyDomainDataException.CheckString(shopName, nameof(shopName));
        NullOrEmtyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
        {
            throw new InvalidDomainDataException("کد ملی نامعتبر است!");
        }

    }
}
