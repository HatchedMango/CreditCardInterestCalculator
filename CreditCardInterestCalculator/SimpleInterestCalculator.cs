
namespace CreditCardInterestCalculator
{
    public class SimpleInterestCalculator : IInterestCalculator
    {
        public decimal CalculateInterest(decimal principal, decimal rate, int numMonths)
        {
            return principal * rate * numMonths;
        }
    }
}
