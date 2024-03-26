


using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;

namespace Shop.Presentation.Facade.Categories;

public interface ICategoryFacade
    {
    Task<OperationResult> AddChild(AddChidCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult> Create(CreateCategoryCommand command);
    Task<OperationResult> Remove(long id);



    Task<CategoryDto> GetCategoryByIdQuery (long id);
    Task<List<ChildCategoryDto>> GetCategoryByParantIdQuery(long parentId);
    Task<List<CategoryDto>> GetCategories();




}
