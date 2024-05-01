﻿
using Common.Query;
using Shop.Domain.Entities.UserAgg.Enums;
using Shop.Domain.Entities.UserAgg;
using Common.Domain.ValueObjects;

namespace Shop.Query.Users.DTOs;

public class UserDto:BaseDto
    {
    public string Name { get;  set; }
    public string Family { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string Avatar { get;  set; }
    public string Password { get;  set; }
    public bool IsActive { get; set; }
    public Gender Gender { get;  set; }
    public List<UserRoleDto> Roles { get;  set; }
}
