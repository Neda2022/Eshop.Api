

using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.Drawing;

namespace Shop.Domain.Entities.UserAgg;

public class UserAddress : BaseEntity
{
    private UserAddress(bool activeAddress)
    {
        ActiveAddress = activeAddress;
    }

    public UserAddress(string shire,
        string city,
        string postalCode,
        string postalAddress,
        string name, string family,
        string nationalCode, PhoneNumber phoneNumber)
    {
        Guard(shire, city, postalCode, postalAddress,
               phoneNumber, name, family, nationalCode);

        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }



    public long UserId { get; internal set; }

    public string Shire { get; private set; }
           
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; } 


    public void Edit(string shire, string city,
        string postalCode, string postalAddress, string name, string family,
         string nationalCode, PhoneNumber phoneNumber)
    {
        Guard(shire, city, postalCode, postalAddress,
               phoneNumber, name, family, nationalCode);

        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void Guard(string shire, string city, string postalCode, string postalAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        if (phoneNumber == null)
            throw new NullOrEmtyDomainDataException();

        NullOrEmtyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmtyDomainDataException.CheckString(city, nameof(city));
        NullOrEmtyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmtyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmtyDomainDataException.CheckString(name, nameof(name));
        NullOrEmtyDomainDataException.CheckString(family, nameof(family));
        NullOrEmtyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("کد ملی نامتبر است!");






    }

}

