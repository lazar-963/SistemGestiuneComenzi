using System.Collections.Generic;

namespace ComenziApp.Core
{
    // Definim statusurile aici ca sa fie gasite de clasa Order
    public enum OrderStatus
    {
        New,
        Processing,
        Shipped,
        Cancelled
    }

    public class Order
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        private OrderStatus _status;
        private readonly IDiscountStrategy _discountStrategy;
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                NotifyObservers();
            }
        }

        public Order(int id, decimal amount, IDiscountStrategy discountStrategy)
        {
            Id = id;
            Amount = amount;
            _discountStrategy = discountStrategy;
            _status = OrderStatus.New;
        }

        public void Attach(IOrderObserver observer) => _observers.Add(observer);

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public decimal GetFinalPrice() => _discountStrategy.ApplyDiscount(Amount);
    }
}