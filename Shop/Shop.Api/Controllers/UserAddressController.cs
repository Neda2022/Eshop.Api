using AutoMapper;
using Common.Asp.NetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.User;
using Shop.Application.Users.AddAdress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddress;
        private readonly IMapper _mapper;

        public UserAddressController(IUserAddressFacade userAddress, IMapper mapper)
        {
            _userAddress = userAddress;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetList()
        {
            var result = await _userAddress.GetList(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<AddressDto?>> GetById(long id)
        {
            var result = await _userAddress.GetById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddAddress(AddAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddress.AddAddress(command);

            return CommandResult(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<ApiResult> Delete(long addressId)
        {
            var userId = 1;
            var result = await _userAddress.DeleteAddress(
                new DeleteUserAddressCommand (addressId, userId));
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> Edit(EditAddressViewModel viewModel)
        {

            var command=  _mapper.Map<EditAddressCommand>(viewModel);
            command.UserId = User.GetUserId();

            var result = await _userAddress.EditAddress(command);
            return CommandResult(result);
        }

    }
}
