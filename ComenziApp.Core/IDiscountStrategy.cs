namespace ComenziApp.Core
{
    // Interfața definește "familia de algoritmi" (Curs 13)
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal amount);
    }
}