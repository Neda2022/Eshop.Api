﻿using Common.Domain;

namespace Shop.Domain.Entities.OrderAgg;

public class OrderAddress:BaseEntity
{
    public OrderAddress(
        string shir,
        string city,
        string postalCode,
        string postalAddress,
        string name,
        string family,
        string nationalCode
,
        string phoneNumber)
    {
       
        Shir = shir;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        PhoneNumber = phoneNumber;
    }

    public long OrderId { get; internal set; }
    public string Shir { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
   public string PhoneNumber { get; private set; }

    public Order Order { get;  set; }
}