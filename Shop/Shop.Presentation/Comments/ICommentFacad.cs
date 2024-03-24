
using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTos;
namespace Shop.Presentation.Facade.Comments;

public interface ICommentFacad
    {
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command); 
    Task<OperationResult> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);


    Task<CommentDto?> GetCommentnById(long id);
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams);



}
