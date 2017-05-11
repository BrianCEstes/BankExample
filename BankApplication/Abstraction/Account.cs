using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Interface;

namespace BankApplication.Abstraction
{
    abstract public class Account : IAccount
    {
        internal decimal _balance;
        public string AccountNumber { get; }

        public Account(decimal balance, string accountnumber)
        {
            _balance = balance;
            AccountNumber = accountnumber;
        }

        abstract public void Deposit(decimal amount);
        abstract public void Withdrawal(decimal amount);
        abstract public void Transfer(decimal amount, IAccount destinationAccount);
        abstract public decimal GetBalance();
    }
}
