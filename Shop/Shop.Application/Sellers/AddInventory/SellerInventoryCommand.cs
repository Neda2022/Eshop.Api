

using Common.Application;
using FluentValidation;

namespace Shop.Application.Sellers.AddInventory;

public record SellerInventoryCommand(long SellerId, long ProductId,
        int Count, int Price, int? PercentageDiscount) :IBaseCommand;

