

using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users;

    public static class UserMapper
    {
      public static UserDto Map(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Family = user.Family,
            Avatar = user.Avatar,
            CreationDate = user.CreateDate,
            Email = user.Email,
            Gender = user.Gender,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            Roles = user.Roles.Select(r => new UserRoleDto
            {
                RoleId= r.RoleId,
                Title="",
            }).ToList(),
        };
    }

    public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
    {
        var roleIds = userDto.Roles.Select(r => r.RoleId);
        var result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        var roles = new List<UserRoleDto>();
        foreach (var role in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = role.Id,
                Title = role.Title
            });
        }

        userDto.Roles = roles;
        return userDto;
    }




    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData
        {
            Id = user.Id,
            Name = user.Name,
            Family = user.Family,
            Avatar = user.Avatar,
            CreationDate = user.CreateDate,
            Email = user.Email,
            Gender = user.Gender,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
        };
    }

      
}

