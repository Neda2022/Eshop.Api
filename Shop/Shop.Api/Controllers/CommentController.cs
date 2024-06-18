using Common.Asp.NetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Domain.Entities.RoleAgg.Enums;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTos;

namespace Shop.Api.Controllers
{

    public class CommentController : ApiController
    {

        private readonly ICommentFacad _commentFacad;

        public CommentController(ICommentFacad commentFacad)
        {
            _commentFacad = commentFacad;
        }

        [PermissionChecker(Permission.Comment_Managment)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filter)
        {
          
            var result = await _commentFacad.GetCommentByFilter(filter);
            return QueryResult(result);
        }

        [PermissionChecker(Permission.Comment_Managment)]
        [HttpGet("{commentId}")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {

            var result = await _commentFacad.GetCommentnById(commentId);
            return QueryResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {

            var result = await _commentFacad.CreateComment(command);
            return CommandResult(result);
        }


        [HttpPut]
        [Authorize]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {

            var result = await _commentFacad.EditComment(command);
            return CommandResult(result);
        }

        [HttpPut("ChangeStatus")]
        [PermissionChecker(Permission.Comment_Managment)]

        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {

            var result = await _commentFacad.ChangeStatus(command);
            return CommandResult(result);
        }


    }
}
