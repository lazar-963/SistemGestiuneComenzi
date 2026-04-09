namespace ComenziApp.Core
{
    using System;

    namespace ComenziApp.Core
    {
        public class EmailNotificationService : IOrderObserver
        {
            public void Update(Order order)
            {
                Console.WriteLine($"[EMAIL] Clientul a fost notificat: Comanda {order.Id} este acum {order.Status}.");
            }
        }

        public class SmsNotificationService : IOrderObserver
        {
            public void Update(Order order)
            {
                Console.WriteLine($"[SMS] Mesaj trimis: Starea comenzii {order.Id} s-a schimbat in {order.Status}.");
            }
        }
    }
}