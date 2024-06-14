﻿using Common.Application;
using Common.Asp.NetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;
using System.Net;

namespace Shop.Api.Controllers
{
   
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _categoryFacade.GetCategories();
            return QueryResult(result);
        }
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryByIdQuery(id);
            return QueryResult(result);
        }

        [HttpGet("GetChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
        {
            var result = await _categoryFacade.GetCategoryByParantIdQuery(parentId);
            return QueryResult(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);

            return CommandResult(result,HttpStatusCode.Created,url);
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> CreateCategory(AddChidCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id =result.Data},Request.Scheme);
            return CommandResult(result,HttpStatusCode.Created,url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<ApiResult> RemoveCategory(long categoryId)
        {
            var result = await _categoryFacade.Remove(categoryId);
            return CommandResult(result);
        }

    }
}
