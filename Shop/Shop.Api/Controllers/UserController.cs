using AutoMapper;
using Common.Asp.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
  
    public class UserController : ApiController
    {
        private readonly IUserFacad _userFacad;
        private readonly IMapper _mapper;

        public UserController(IUserFacad userFacad, IMapper mapper)
        {
            _userFacad = userFacad;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
        {
            var result = await _userFacad.GetUserByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetById(long userId)
        {
            var result = await _userFacad.GetUserById(userId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateUserCommand command)
        {
            var result = await _userFacad.CreateUser(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
        {
            var result = await _userFacad.EditUser(command);
            return CommandResult(result);
        }


    }
}
