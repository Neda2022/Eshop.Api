


using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParantId;
using Shop.Query.Categories.GetList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;

    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddChild(AddChidCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryListQuery());
    }

    public async Task<CategoryDto> GetCategoryByIdQuery(long Id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(Id));
    }

    public async Task<List<ChildCategoryDto>> GetCategoryByParantIdQuery(long parentId)
    {
        return await _mediator.Send(new GetCategoryByParantIdQuery(parentId));

    }

    public async Task<OperationResult> Remove(long id)
    {
       return await _mediator.Send(new RemoveCategoryCommand(id));
    }
}
