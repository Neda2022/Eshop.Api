
using Common.Query;
using Shop.Domain.Entities.UserAgg.Enums;

namespace Shop.Query.Users.DTOs;

public class UserFilterData:BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Avatar { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }

}
