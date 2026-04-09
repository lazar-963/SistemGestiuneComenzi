using ComenziApp.Core;
using NUnit.Framework;

namespace ComenziApp.UnitTests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void GetFinalPrice_VipCustomer_Applies20PercentDiscount()
        {
            // Arrange (Pregătirea testului conform Curs 8-9)
            var strategy = new VipCustomerStrategy();
            var order = new Order(1, 100m, strategy);

            // Act (Execuția)
            var finalPrice = order.GetFinalPrice();

            // Assert (Verificarea)
            Assert.That(finalPrice, Is.EqualTo(80m));
        }
        [Test]
        public void StatusChange_NotifiesObservers()
        {
            // Arrange
            var order = new Order(1, 100m, new RegularCustomerStrategy());
            var observerWasNotified = false;

            // Creăm un observator ad-hoc pentru test
            var testObserver = new TestObserver(() => observerWasNotified = true);
            order.Attach(testObserver);

            // Act
            order.Status = OrderStatus.Processing;

            // Assert
            Assert.That(observerWasNotified, Is.True, "Observatorul ar fi trebuit sa fie notificat la schimbarea statusului.");
        }

        // Clasă ajutătoare pentru test
        private class TestObserver : IOrderObserver
        {
            private readonly Action _onUpdate;
            public TestObserver(Action onUpdate) => _onUpdate = onUpdate;
            public void Update(Order order) => _onUpdate();
        }
    }
}