namespace ComenziApp.Core
{
    // Client obișnuit - nicio reducere
    public class RegularCustomerStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal amount) => amount;
    }

    // Client VIP - reducere 20%
    public class VipCustomerStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal amount) => amount * 0.8m;
    }
}