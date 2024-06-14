

using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Rejester;
using Shop.Application.Users.RemoveToken;
using Shop.Infrastructure.Migrations;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;
using Shop.Query.Users.GetFilter;
using Shop.Query.Users.UserTokens;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Presentation.Facade.Users;

public class UserFacad : IUserFacad
{
    private readonly IMediator _mediator;
    public UserFacad(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }


    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<UserDto?> GetUserById(long userId)
    {
       
            return await _mediator.Send(new GetUserByIdQuery(userId));
        
    
   
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        var hashRefreshToken =  Sha256Hasher.Hash(refreshToken);
        return await _mediator.Send(new GetUserTokenByJwtToken(hashRefreshToken));

    }

    public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        var hashRefreshToken = Sha256Hasher.Hash(jwtToken);
        return await _mediator.Send(new GetUserTokenByJwtToken(hashRefreshToken));
    }
}
