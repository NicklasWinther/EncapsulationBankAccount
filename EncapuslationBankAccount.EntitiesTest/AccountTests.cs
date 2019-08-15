using EncapsulationBankAccount.Entities;
using System;
using Xunit;

namespace EncapuslationBankAccount.EntitiesTest
{
    public class AccountTests
    {
        [Fact]
        public void WithdrawCorrectAmountShouldWithdrawThatAmount()
        {
            //Arrange
            decimal balance = 100;
            decimal balanceToWithdraw = 10;
            Account account = new Account(1, balance, DateTime.Today);

            //Act
            account.Withdraw(balanceToWithdraw);

            //Assert
            Assert.Equal(balance - balanceToWithdraw, account.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(25001)]
        public void WithdrawIncorrectAmountThrowsException(decimal balanceToWithdraw)
        {
            //Arrange
            decimal balance = 100;
            Account account = new Account(1, balance, DateTime.Today);

            //Act
            Action act = () => account.Withdraw(balanceToWithdraw);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void DepositCorrectAmountShouldWithdrawThatAmount()
        {
            //Arrange
            decimal balance = 100;
            decimal balanceToDeposit = 10;
            Account account = new Account(1, balance, DateTime.Today);

            //Act
            account.Deposit(balanceToDeposit);

            //Assert
            Assert.Equal(balance + balanceToDeposit, account.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(25001)]
        public void DepositIncorrectAmountThrowsException(decimal balanceToDeposit)
        {
            //Arrange
            decimal balance = 100;
            Account account = new Account(1, balance, DateTime.Today);

            //Act
            Action act = () => account.Deposit(balanceToDeposit);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void NewAccountShouldHaveIdZero()
        {
            //Arrange
            Account account = new Account(10000);

            //Act

            //Assert
            Assert.Equal(0, account.Id);
        }

        [Fact]
        public void AccountWithIdZeroThrowsException()
        {
            //Arrange
            Account account = new Account(10000);

            //Act
            Action act = () => account.Id = 0;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void AccountWithIdLessThatOneThrowsException()
        {
            //Arrange
            Action act = () => new Account(0, 100, DateTime.Today);

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
        [Theory]
        [InlineData(1_000_000_000)]
        [InlineData(-1_000_000_000)]
        public void BalanceThrowsException(decimal newBalance)
        {
            //Arrange
            Account account = new Account(1, 100, DateTime.Today);

            //Act
            Action act = () => account.Balance = newBalance;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
