using Common.Domain;
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
        ChangeOrderGuard();
        // اگر سفارش درخواستی در سبد خرید از قبل وجود داشت دیگه نباید بزاریم  
        var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
        if(oldItem!= null)
        {
            oldItem.ChangeCount(item.Count + oldItem.Count);
            return;
        }

        Items.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
        if(currentItem!= null)
        {
            Items.Remove(currentItem);
        }
        
    }
    public void ChangeCountItem(long itemId, int newCount)
    {
        ChangeOrderGuard();
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
        ChangeOrderGuard();
        Address = orderAddress;
        //نحوه ارسال آدرس
        
    }
    //در چه صورتی امکان تغییر سفارش وجود دارد
    public void ChangeOrderGuard()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidDomainDataException("امکان ثبت محصول در این سفارش وجود ندارد");
    }
} 
