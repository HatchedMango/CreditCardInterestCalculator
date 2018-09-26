using CreditCardInterestCalculator.models;

namespace CreditCardInterestCalculator
{
    public class CardInterestCalculator
    {
        private readonly IInterestCalculator interestCalculator;

        public CardInterestCalculator(IInterestCalculator interestCalculator)
        {
            this.interestCalculator = interestCalculator;
        }

        public decimal CalculateInterest(Card card, int numMonths)
        {
            return interestCalculator.CalculateInterest(card.Balance, card.InterestRate, numMonths);
        }
    }
}
