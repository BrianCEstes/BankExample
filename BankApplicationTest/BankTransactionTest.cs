using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApplication.Implementation;
using BankApplication.Interface;
namespace BankApplicationTest
{
    [TestClass]
    public class BankTransactionTest
    {
        [TestMethod]
        public void BankNameIsMyBank()
        {
            BankFromCode bank = new BankFromCode();
            Assert.AreEqual("MyBank", bank.BankName);
        }

        [TestMethod]
        public void SavingsAccountDeposit()
        {
            decimal startingBalance = (decimal)50.00;
            decimal depositAmount = (decimal)5.33;
            string accountNumber = "0007124";
            CheckingAccount account = new CheckingAccount(startingBalance, accountNumber);
            decimal expectedBalance = startingBalance + depositAmount;

            account.Deposit(depositAmount);

            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [TestMethod]
        public void NegativeSavingsAccountDeposit()
        {
            decimal startingBalance = (decimal)50.00;
            decimal depositAmount = (decimal)-5.33;
            string accountNumber = "0007124";
            CheckingAccount account = new CheckingAccount(startingBalance, accountNumber);
            decimal expectedBalance = startingBalance;
            string outputmessage = "";
            try
            {
                account.Deposit(depositAmount);
            }
            catch (Exception NegativeSavingsException)
            {
                outputmessage = NegativeSavingsException.Message;
            }
            Assert.AreEqual(expectedBalance, account.GetBalance());
            Assert.AreEqual(outputmessage, "Invalid Amount Deposited.");
        }

        [TestMethod]
        public void SavingsAccountWithdrawal()
        {
            decimal startingBalance = (decimal)50.00;
            decimal withdrawalAmount = (decimal)5.33;
            string accountNumber = "0007124";
            CheckingAccount account = new CheckingAccount(startingBalance, accountNumber);
            decimal expectedBalance = startingBalance - withdrawalAmount;

            account.Withdrawal(withdrawalAmount);

            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [TestMethod]
        public void InsufficientFundsSavingsAccountWithdrawal()
        {
            decimal startingBalance = (decimal)50.00;
            decimal withdrawalAmount = (decimal)55.33;
            string accountNumber = "0007124";
            CheckingAccount account = new CheckingAccount(startingBalance, accountNumber);
            decimal expectedBalance = startingBalance;
            string outputmessage = "";
            try
            {
                account.Withdrawal(withdrawalAmount);
            }
            catch (Exception InsufficientFundsException)
            {
                outputmessage = InsufficientFundsException.Message;
            }
            Assert.AreEqual(expectedBalance, account.GetBalance());
            Assert.AreEqual(outputmessage, "Insufficient funds.");
        }

        [TestMethod]
        public void IndividualInvestmentAccountWithdrawal()
        {
            decimal startingBalance = (decimal)5000.00;
            decimal withdrawalAmount = (decimal)550.33;
            decimal maxWithdrawalAmount = (decimal)500;
            string accountNumber = "0007124";

            IAccount account = new IndividualInvestmentAccount(startingBalance, "0007124", maxWithdrawalAmount);
            decimal expectedBalance = startingBalance;
            string outputmessage = "";
            try
            {
                account.Withdrawal(withdrawalAmount);
            }
            catch (Exception MaxWithdrawExceeded)
            {
                outputmessage = MaxWithdrawExceeded.Message;
            }
            Assert.AreEqual(expectedBalance, account.GetBalance());
            Assert.AreEqual(outputmessage, string.Format("Amount Exceeds Maximum Withdrawal of ${0}", maxWithdrawalAmount));
        }
    }
}
