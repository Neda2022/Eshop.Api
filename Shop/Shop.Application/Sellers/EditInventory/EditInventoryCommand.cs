

using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.Entities.SellerAgg;

namespace Shop.Application.Sellers.EditInventory;

public record EditInventoryCommand(long SellerId, long InventoryId,
        int Count, int Price, int? PercentageDiscount) : IBaseCommand;
