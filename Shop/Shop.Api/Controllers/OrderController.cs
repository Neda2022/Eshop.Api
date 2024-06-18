using Common.Asp.NetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DeacreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Domain.Entities.RoleAgg.Enums;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderFacad _orderFacad;

        public OrderController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        [PermissionChecker(Permission.Order_Managment)]
        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery]OrderFilterParam filterParams)
        {
            var result= await _orderFacad.GetOrdersByFilter(filterParams);
            return QueryResult(result);

        }
        [HttpGet("{orderId}")]
        public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
        {
            var result = await _orderFacad.GetOrderById(orderId);
            return QueryResult(result);

        }

        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddItemOrderCommand command)
        {
            
            var result = await _orderFacad.AddOrderItem(command);
            return CommandResult(result);

        }

        [HttpPost("Checkout")]
        public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
        {

            var result = await _orderFacad.OrderCheckOut(command);
            return CommandResult(result);

        }

        [HttpPut("OrderItem/IncreaseCount")]
        public async Task<ApiResult> IncreaseOrderCount(IncreaseOrderItemCountCommand command)
        {

            var result = await _orderFacad.IncreaseItemCount(command);
            return CommandResult(result);

        }

        [HttpPut("OrderItem/DecreaseCount")]
        public async Task<ApiResult> IncreaseOrderCount(DecreaseOrderItemCountCommand command)
        {

            var result = await _orderFacad.DecreaseItemCount(command);
            return CommandResult(result);

        }
        [HttpDelete("OrderItem")]
        public async Task<ApiResult> DeletOrderItem(RemoveOrderItemCommand command)
        {

            var result = await _orderFacad.RemoveOrderItem(command);
            return CommandResult(result);

        }
    }
}
