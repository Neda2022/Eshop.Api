using Common.Application;
using Common.Application.SecurityUtil;
using Common.Asp.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Rejester;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers
{
   
    public class AuthController : ApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IUserFacad _userFacad;

        public AuthController(IUserFacad userFacad, IConfiguration configuration)
        {
            _userFacad = userFacad;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ApiResult<string?>> login(LoginViewModel loginViewModel)
        {
            var user = await _userFacad.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
            if (true)
            {
                var result= OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }
            if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
                return CommandResult(result);
            }
            
            if (user.IsActive==false)
            {
                var result = OperationResult<string>.Error("حساب کاربری شما غیر فعال است");
                return CommandResult(result);
            }
            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }

        [HttpPost("rejister")]
        public async Task<ApiResult> Rejister(RejisterViewModel rejister)
        {
            var command = new RegisterUserCommand
                (rejister.PhoneNumber,rejister.Password);
            var result = await _userFacad.RegisterUser(command);

            return CommandResult(result);
        }
    }

    
}
