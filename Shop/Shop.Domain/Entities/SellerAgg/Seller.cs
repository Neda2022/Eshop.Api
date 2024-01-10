﻿using Common.Domain;
using Common.Domain.Exceptions;
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
    public Seller(long userId, string shopName, string nationalCode)
    {
        Guard(shopName, nationalCode);

        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
        Inventories = new List<SellerInventory>();
    }

    public long UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
    public SellerStatus Status { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }
    public DateTime? LastUpdate { get; private set; }
    public void ChangeStatus(SellerStatus status)
    {
        Status = status;
        LastUpdate=DateTime.Now;
    }
    public void Edit(string shopName, string nationalCode)
    {
        Guard(shopName,nationalCode);
        ShopName = shopName;
        NationalCode = nationalCode;
    }
    public void AddInventory(SellerInventory inventory)
    {
        if (Inventories.Any(f => f.ProductId == inventory.ProductId))
            throw new InvalidDomainDataException("این محصول قبلا ثبت شده است!");
        Inventories.Add(inventory);
    }
    public void EditInventory(SellerInventory newInventory)
    {
        var currentInventory = Inventories.FirstOrDefault(f => f.Id == newInventory.Id);

        if (currentInventory == null)
            return;
        Inventories.Remove(currentInventory);
        Inventories.Add(currentInventory);

    }
    public void DeletInventory(long inventoryId)
    {
        var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);

        if (currentInventory == null)
            throw new NullOrEmtyDomainDataException("محصول یافت نشد!");
        Inventories.Remove(currentInventory);

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
