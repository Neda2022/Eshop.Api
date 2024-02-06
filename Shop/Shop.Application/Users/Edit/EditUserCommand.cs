
using Common.Application;
using Common.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.UserAgg.Enums;

namespace Shop.Application.Users.Edit;

public record EditUserCommand(long Id,string Name, string Family,
        string PhoneNumber, string Email,
         Gender Gender, IFormFile? Avatar, string Password) :IBaseCommand;

