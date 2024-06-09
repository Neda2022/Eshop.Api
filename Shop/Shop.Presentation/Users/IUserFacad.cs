

using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Rejester;
using Shop.Application.Users.RemoveToken;
using Shop.Domain.Entities.UserAgg;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users;

public interface IUserFacad
    {
    Task<OperationResult> RegisterUser(RegisterUserCommand command);
    Task<OperationResult> EditUser(EditUserCommand command);
    Task<OperationResult> CreateUser(CreateUserCommand command);
    Task<OperationResult> AddToken(AddUserTokenCommand command);
    Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);

    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetUserById(long userId);
    Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);

    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
}
