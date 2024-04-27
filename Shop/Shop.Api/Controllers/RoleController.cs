using Common.Asp.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Domain.Entities.RoleAgg.Repository;
using Shop.Presentation.Facade.Roles;
using Shop.Query.Roles.DTOs;

namespace Shop.Api.Controllers
{
   
    public class RoleController : ApiController
    {
        private readonly IRoleFacad _roleFacad;

        public RoleController(IRoleFacad roleFacad)
        {
            _roleFacad = roleFacad;
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoles()
        {
            var result= await _roleFacad.GetRoles();
            return QueryResult(result);
        }

        [HttpGet("{roleId}")]
        public async Task<ApiResult<RoleDto?>> GetRolesById(long roleId)
        {
            var result = await _roleFacad.GetRoleById(roleId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result= await _roleFacad.CreateRole(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacad.EditRole(command);
            return CommandResult(result);
        }



    }
}
