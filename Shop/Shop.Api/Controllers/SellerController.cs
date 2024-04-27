using Common.Asp.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Domain.Entities.RoleAgg.Enums;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Query.Sellers.DTOs;

namespace Shop.Api.Controllers
{

    public class SellerController : ApiController
    {
        private readonly ISellerFacad _sellerFacad;
        private readonly ISellerInventoryFacad _inventoryFacad;

        public SellerController(ISellerFacad sellerFacad, ISellerInventoryFacad inventoryFacad)
        {
            _sellerFacad = sellerFacad;
            _inventoryFacad = inventoryFacad;
        }

        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSeller(SellerFilterParam filterParam)
        {
            var result = await _sellerFacad.GetSellersByFilter(filterParam);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto?>> GetSellerById(long sellerId)
        {
            var result = await _sellerFacad.GetSellerById(sellerId);
            return QueryResult(result);
        }


        [HttpPost]
        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            var result = await _sellerFacad.CreateSeller(command);
            return CommandResult(result);
        }

        [HttpPut]

        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacad.EditSeller(command);
            return CommandResult(result);
        }

        [HttpPost("Inventory")]
        public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
        {
            var result = await _inventoryFacad.AddInventory(command);
            return CommandResult(result);
        }

        [HttpPut("Inventory")]
        public async Task<ApiResult> EditInventory(EditInventoryCommand command)
        {
            var result = await _inventoryFacad.EditInventory(command);
            return CommandResult(result);
        }

        

    }
}
