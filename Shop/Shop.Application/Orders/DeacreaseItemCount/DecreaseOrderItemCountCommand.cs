

using Common.Application;

namespace Shop.Application.Orders.DeacreaseItemCount;

public record DecreaseOrderItemCountCommand(long UserId,long ItemId, int Count):IBaseCommand;


