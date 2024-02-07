

using Common.Application;
using Common.Application.Validation.FluentValidations;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.EditAddress;

public record EditAddressCommand(
       long Id,
         long UserId,
        string Shire,
        string City,
        string PostalCode,
        string PostalAddress,
        string Name,
        string Family,
        string NationalCode, 
        PhoneNumber PhoneNumber) :IBaseCommand;
