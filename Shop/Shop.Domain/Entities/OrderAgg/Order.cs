﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Entities.OrderAgg.Enums;
using Shop.Domain.Entities.OrderAgg.ValueObjects;

namespace Shop.Domain.Entities.OrderAgg;

public class Order:AggregateRoot
    
    {
    public Order(long userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        Items=new List<OrderItem>();
    }

    private Order()
    {
            
    }
    public long UserId { get; private set; }
    public OrderStatus Status { get; private set;}
    public OrderDisCount? Discount { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public OrderAddress? Address { get; private set; }
    public ShippingMethod ShippingMethod { get; private set; }

    public DateTime? LastUpdate { get; private set; }

    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(f => f.TotalPrice);
            if(ShippingMethod!=null)
                totalPrice = ShippingMethod.ShippingCost;

            if (Discount != null)
                totalPrice = Discount.DiscountAmount;
            return totalPrice;
        }
    }
    public int ItemCount => Items.Count; 

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
        if(currentItem!= null)
        {
            Items.Remove(currentItem);
        }
        
    }
    public void ChangeCountItem(long itemId, int newCount)
    {
        var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmtyDomainDataException();
        currentItem.ChangeCount(newCount);
    }
    public void ChangeStatus(OrderStatus status)
    {
       Status=status;
        LastUpdate=DateTime.Now;    
    }
    public void CheckOut(OrderAddress orderAddress)//   سبد خرید و آدر و نحوه ارسال انتخاب کردیم و نوبت پرداخت است
    {

        Address = orderAddress;
        //نحوه ارسال آدرس
        
    }
} 
