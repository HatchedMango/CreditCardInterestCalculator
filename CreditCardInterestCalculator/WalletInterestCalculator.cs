using System.Linq;
using CreditCardInterestCalculator.models;

namespace CreditCardInterestCalculator
{
    public class WalletInterestCalculator
    {
        private readonly IInterestCalculator interestCalculator;

        public WalletInterestCalculator(IInterestCalculator interestCalculator)
        {
            this.interestCalculator = interestCalculator;
        }

        public decimal CalculateInterest(Wallet wallet, int numMonths)
        {
            return wallet.Cards.Sum(card =>
                interestCalculator.CalculateInterest(card.Balance, card.InterestRate, numMonths));
        }
    }
}
