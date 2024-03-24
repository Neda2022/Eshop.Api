

using Common.Application;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Productes.AddImage;
using Shop.Application.Productes.Create;
using Shop.Application.Productes.Edit;
using Shop.Application.Productes.RemoveImage;
using Shop.Query.Products.DTOs;

namespace Shop.Presentation.Facade.Products;

public interface IProductFacad
    {
    Task<OperationResult> CreateProduct(CreateProductCommand command);
    Task<OperationResult> EditProduct(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductDto?> GetProductById(long productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams);
}

