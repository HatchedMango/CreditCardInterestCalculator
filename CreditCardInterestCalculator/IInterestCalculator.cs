using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardInterestCalculator
{
    public interface IInterestCalculator
    {
        decimal CalculateInterest(decimal principal, decimal rate, int numMonths);
    }
}
