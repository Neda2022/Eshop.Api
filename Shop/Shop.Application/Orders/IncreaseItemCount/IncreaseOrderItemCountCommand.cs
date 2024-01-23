
using Common.Application;

namespace Shop.Application.Orders.ChangeCount;

public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count):IBaseCommand;//--UserId  استفاده می کنیم درغیر اینصورت   --orderId-- اگر قرار نباشه سمت ادمین تغییری باشه همون   
