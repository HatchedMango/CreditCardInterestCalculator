using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardInterestCalculator;
using CreditCardInterestCalculator.models;

namespace CreditCardInterestCalculatorTests
{
    [TestClass]
    public class CreditCardInterestCalculatorTest
    {
        private PersonalInterestCalculator personalInterestCalculator = new PersonalInterestCalculator(new SimpleInterestCalculator());
        private WalletInterestCalculator walletInterestCalculator = new WalletInterestCalculator(new SimpleInterestCalculator());
        private CardInterestCalculator cardInterestCalculator = new CardInterestCalculator(new SimpleInterestCalculator());

        private int numMonths = 1; 
        private Card visa = new Card
        {
            Holder = "Visa",
            Balance = 100m,
            InterestRate = 0.10m
        };
        private Card master = new Card
        {
            Holder = "Master",
            Balance = 100m,
            InterestRate = 0.05m
        };
        private Card discover = new Card
        {
            Holder = "Discover",
            Balance = 100m,
            InterestRate = 0.01m
        };

        [TestMethod]
        public void TestCase1()
        {
            var wallet = new Wallet
            {
                Cards = new List<Card> { visa, master, discover }
            };

            var person = new Person
            {
                Wallets = new List<Wallet> { wallet }
            };

            var personalInterest = personalInterestCalculator.CalculateInterest(person, numMonths);
            Assert.AreEqual(16, personalInterest);

            var visaInterest = cardInterestCalculator.CalculateInterest(visa, numMonths);
            Assert.AreEqual(10, visaInterest);

            var masterInterest = cardInterestCalculator.CalculateInterest(master, numMonths);
            Assert.AreEqual(5, masterInterest);

            var discoverInterest = cardInterestCalculator.CalculateInterest(discover, numMonths);
            Assert.AreEqual(1, discoverInterest);
        }

        [TestMethod]
        public void TestCase2()
        {
            var wallet1 = new Wallet
            {
                Cards = new List<Card> { visa, discover }
            };

            var wallet2 = new Wallet
            {
                Cards = new List<Card> { master }
            };

            var person = new Person
            {
                Wallets = new List<Wallet> { wallet1, wallet2 }
            };

            var personalInterest = personalInterestCalculator.CalculateInterest(person, numMonths);
            Assert.AreEqual(16, personalInterest);

            var wallet1Interest = walletInterestCalculator.CalculateInterest(wallet1, numMonths);
            Assert.AreEqual(11, wallet1Interest);

            var wallet2Interest = walletInterestCalculator.CalculateInterest(wallet2, numMonths);
            Assert.AreEqual(5, wallet2Interest);
        }

        [TestMethod]
        public void TestCase3()
        {
            var person1sWallet = new Wallet
            {
                Cards = new List<Card> { master, visa }
            };

            var person1 = new Person
            {
                Wallets = new List<Wallet> { person1sWallet }
            };

            var person2sWallet = new Wallet
            {
                Cards = new List<Card> { visa, master }
            };

            var person2 = new Person
            {
                Wallets = new List<Wallet> { person2sWallet }
            };

            var personalInterest1 = personalInterestCalculator.CalculateInterest(person1, numMonths);
            Assert.AreEqual(15, personalInterest1);

            var personalInterest2 = personalInterestCalculator.CalculateInterest(person2, numMonths);
            Assert.AreEqual(15, personalInterest2);

            var wallet1Interest = walletInterestCalculator.CalculateInterest(person1sWallet, numMonths);
            Assert.AreEqual(15, wallet1Interest);

            var wallet2Interest = walletInterestCalculator.CalculateInterest(person2sWallet, numMonths);
            Assert.AreEqual(15, wallet2Interest);
        }
    }
}
