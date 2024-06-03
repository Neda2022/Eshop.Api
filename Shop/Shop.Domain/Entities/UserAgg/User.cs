

using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Entities.UserAgg.Enums;
using Shop.Domain.Entities.UserAgg.Services;
using System.ComponentModel;

namespace Shop.Domain.Entities.UserAgg;

public class User : AggregateRoot
{
    private User()
    {
      
    }
    public User(string name, string family, string phoneNumber, string? email,
           string password, Gender gender, IDomainUserService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);

        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        Avatar = "avatar.png";
        IsActive = true;
        Roles = new();
        Wallets = new();
        Addresses = new();
        Tokens = new();
        
    }


    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string Avatar { get;  set; }
    public string Password { get; private set; }
    public bool IsActive { get;  set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get;  }
    public List<Wallet> Wallets { get;  }
    public List<UserAddress> Addresses { get; }
    public List<UserToken> Tokens { get; } 

    public void Edit(string name, string family,
        string phoneNumber, string? email,
         Gender gender, IDomainUserService domainService)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
        Guard(phoneNumber, email, domainService);
       
    }
    public static User RegisterUser(string phoneNumber,  string password, 
        IDomainUserService userDomainService)
    {
        
        return new User("", "", phoneNumber,null , password, Gender.None, userDomainService);
    }
    
    public void SetAvatar(string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
            imageName = "avatar.png";
        Avatar = imageName;
    }
    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }
    public void DeleteAddress(long addressId)
    {

        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null)
            throw new NullOrEmtyDomainDataException("آدرس پیدا نشد!");
        Addresses.Remove(oldAddress);

    }
    public void EditAddress(UserAddress address, long addressId)
    {

        var oldAddress= Addresses.FirstOrDefault(f=>f.Id==address.Id);
        if (oldAddress == null)
            throw new NullOrEmtyDomainDataException("آدرس پیدا نشد!");
        oldAddress.Edit(address.Shire, address.City, address.PostalCode,
           address.PostalAddress,  
               address.Name, address.Family, address.NationalCode,address.PhoneNumber);
    }
    
    public void ChargeWallet(Wallet wallet)
    {
        Wallets.Add(wallet);
    }

    public void SetRole(List<UserRole> roles)
    {
        roles.ForEach(f => f.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    public void AddToken(
        string hashJwtToken,
        string hashRefreshToken,
        DateTime tokenExpiredDate,
        DateTime refreshTokenExpiredDate,
        string device)
    {
        var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
        if (activeTokenCount == 3)
            throw new InvalidDomainDataException(" امکان استفاده از  4 دستگاه وجود ندارد! ");
        var token = new UserToken(
            hashJwtToken,
            hashRefreshToken, 
            tokenExpiredDate,
            refreshTokenExpiredDate, 
            device);
        token.UserId = Id;
        Tokens.Add(token);
    }
        
    

    public void Guard(string phoneNumber, string? email, IDomainUserService domainService)
    {
        NullOrEmtyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره تلفن وارد شده نامعتبر است!");
        if (phoneNumber != PhoneNumber)
            if (domainService.PhoneNumberIsExist(phoneNumber) == true)
                throw new InvalidDomainDataException("شماره تلفن وارد شده تکراری است!");

        if (email!=null)
            if (email.IsValidEmail()==false)
            throw new InvalidDomainDataException("ایمیل نامعتبر است!");

        if (email != Email)
            if (domainService.IsEmailExist(email) == true)
                throw new InvalidDomainDataException("ایمیل وارد شده تکراری است!"); 

       
       
        

    }

}



