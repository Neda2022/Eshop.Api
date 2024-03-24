

using Common.Application;
using MediatR;
using Shop.Application.Productes.AddImage;
using Shop.Application.Productes.Create;
using Shop.Application.Productes.Edit;
using Shop.Application.Productes.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;

namespace Shop.Presentation.Facade.Products;

public class ProductFacad : IProductFacad
{
    private readonly IMediator _mediator;

    public ProductFacad(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateProduct(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditProduct(EditProductCommand command)
    {
        
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
        {
            var product = await GetProductById(command.ProductId);
           

        }
        return result;

    }
    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
        {
            var product = await GetProductById(command.ProductId);

        }
        return result;
    }
        public async Task<ProductDto?> GetProductById(long productId)
    {
        return await _mediator.Send(new GetProductByIdQuery(productId));
    }

  
    public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams)
    {
        return await _mediator.Send(new GetProductByFilterQuery(filterParams));
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
       
            return await _mediator.Send(new GetProductBySlugQuery(slug));
       
    }


}

