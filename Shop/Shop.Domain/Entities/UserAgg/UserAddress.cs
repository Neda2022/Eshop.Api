

using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.UserAgg;

public class UserAddress : BaseEntity
{
    private UserAddress(bool activeAddress)
    {
        ActiveAddress = activeAddress;
    }

    public UserAddress(string shir,
        string city,
        string postalCode,
        string postalAddress,
        string name, string family,
        string nationalCode, bool activeAddress)
    {
        Guard(shir, city, postalCode,
            postalAddress, name, family,
            nationalCode);
        Shir = shir;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        ActiveAddress = false;
    }



    public long UserId { get; internal set; }

    public string Shir { get; private set; }
           
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; } 
    public void Edit(string shir, string city,
        string postalCode, string postalAddress, string name, string family,
         string nationalCode)
    {
        Guard(shir,city,postalCode,postalAddress,name,family,nationalCode);
        Shir = shir;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void Guard(string shir, string city, string postalCode, 
        string postalAddress, string name, string family,
         string nationalCode)
    {
        NullOrEmtyDomainDataException.CheckString(shir, nameof(shir));
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

