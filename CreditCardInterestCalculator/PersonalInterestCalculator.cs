using System.Linq;
using CreditCardInterestCalculator.models;

namespace CreditCardInterestCalculator
{
    public class PersonalInterestCalculator
    {
        private readonly IInterestCalculator interestCalculator;

        public PersonalInterestCalculator(IInterestCalculator interestCalculator)
        {
            this.interestCalculator = interestCalculator;
        }

        public decimal CalculateInterest(Person person, int numMonths)
        {
            return person.Wallets.Sum(wallet =>
                wallet.Cards.Sum(card => 
                    interestCalculator.CalculateInterest(card.Balance, card.InterestRate, numMonths)));
        }
    }
}
