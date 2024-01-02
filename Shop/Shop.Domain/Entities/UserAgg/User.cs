

using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Entities.UserAgg.Enums;
using Shop.Domain.Entities.UserAgg.Services;

namespace Shop.Domain.Entities.UserAgg;

public class User : AggregateRoot
{
    private User()
    {
            
    }
    public User(string name, string family, 
        string phoneNumber, string email,
        string password, Gender gender, IDomainUserService domainService)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        Guard(phoneNumber, email, domainService);

    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public List<UserAddress> Addresses { get; private set; }

    public void Edit(string name, string family,
        string phoneNumber, string email,
         Gender gender, IDomainUserService domainService)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
        Guard(phoneNumber, email, domainService);
       
    }
    public static User RejisterUser(string email,string phoneNumber, string password, IDomainUserService domainService)
    {
        return new User("", "", email,phoneNumber, password, Gender.None, domainService);
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
    public void EditAddress(UserAddress address)
    {

        var oldAddress= Addresses.FirstOrDefault(f=>f.Id==address.Id);
        if (oldAddress == null)
            throw new NullOrEmtyDomainDataException("آدرس پیدا نشد!");
       
        Addresses.Remove(oldAddress);
        Addresses.Add(address);
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
    public void Guard(string phoneNumber, string email, IDomainUserService domainService)
    {
        NullOrEmtyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmtyDomainDataException.CheckString(email,nameof(email));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره تلفن وارد شده نامعتبر است!");

        if(email.IsValidEmail()==false)

            throw new InvalidDomainDataException("ایمیل نامعتبر است!");
        if(phoneNumber!= PhoneNumber)
            if(domainService.PhoneNumberExist(phoneNumber)==true)
                throw new InvalidDomainDataException("شماره تلفن وارد شده تکراری است!");

        if (email != Email)
            if (domainService.IsEmailExist(email) == true)
                throw new InvalidDomainDataException("ایمیل وارد شده تکراری است!");

    }

}



