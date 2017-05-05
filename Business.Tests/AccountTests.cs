using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banking.Business.Model;

namespace Banking.Business.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Can_Deposit_Funds()
        {
            Account account = new CheckingAccount(new Person("John", "Doe"));

            account.Deposit(5000);

            Assert.AreEqual(5000, account.Balance);
        }

        [TestMethod]
        public void Can_Withdraw_Funds()
        {
            Account account = new CheckingAccount(new Person("John", "Doe"));

            account.Deposit(5000);

            account.Withdraw(1000);

            Assert.AreEqual(4000, account.Balance);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_Throws_When_Exceeds_Limit()
        {
            Account account = new IndividualAccount(new Person("John", "Doe"), 500);

            account.Deposit(25000);

            account.Withdraw(501);
        }

        [TestMethod]
        public void Can_Transfer_Funds()
        {
            Person owner = new Person("John", "Doe");

            Account checking = new CheckingAccount(owner);

            Account individual = new IndividualAccount(owner);

            checking.Deposit(5000);

            checking.Transfer(individual, 2500);

            Assert.AreEqual(2500, checking.Balance);

            Assert.AreEqual(2500, individual.Balance);
        }
    }
}
