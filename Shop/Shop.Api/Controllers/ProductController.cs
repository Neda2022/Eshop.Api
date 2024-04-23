using Common.Asp.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Productes.AddImage;
using Shop.Application.Productes.Create;
using Shop.Application.Productes.Edit;
using Shop.Application.Productes.RemoveImage;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs;

namespace Shop.Api.Controllers
{
   
    public class ProductController : ApiController
    {
        private readonly IProductFacad _productFacad;

        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter ([FromQuery]ProductFilterParam filterParam)
        {

            return QueryResult( await _productFacad.GetProductsByFilter(filterParam));
        }

        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> GetProductByFilter(long productId)
        {

            var product = await _productFacad.GetProductById(productId);
            return QueryResult(product);
        }

        [HttpGet("{slug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
        {

            var product = await _productFacad.GetProductBySlug(slug);
            return QueryResult(product);
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm]CreateProductCommand command)
        {

            var result = await _productFacad.CreateProduct(command);
            return CommandResult(result);
        }

        [HttpPost("{images}")]
        public async Task<ApiResult> AddImage([FromForm] AddProductImageCommand command)
        {

            var result = await _productFacad.AddImage(command);
            return CommandResult(result);
        }

        [HttpDelete("{images}")]
        public async Task<ApiResult> RemoveImage( RemoveProductImageCommand command)
        {

            var result = await _productFacad.RemoveImage(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct( EditProductCommand command)
        {

            var result = await _productFacad.EditProduct(command);
            return CommandResult(result);
        }



    }
}
