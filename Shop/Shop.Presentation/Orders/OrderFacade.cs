

using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DeacreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;

namespace Shop.Presentation.Facade.Orders;

internal class OrderFacade : IOrderFacad
{
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddOrderItem(AddItemOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

       

        public async Task<OrderDto?> GetOrderById(long orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }



    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParam filterParams)
    {
        return await _mediator.Send(new GetOrderByFilterQuery(filterParams));
    }




}