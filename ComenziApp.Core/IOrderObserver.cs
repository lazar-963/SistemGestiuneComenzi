namespace ComenziApp.Core
{
    // Interfața pentru toți cei care vor să asculte schimbările comenzii
    public interface IOrderObserver
    {
        void Update(Order order);
    }
}