﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Interface;
using BankApplication.Abstraction;

namespace BankApplication.Implementation
{
    public class CorporateInvestmentAccount : Account
    {
        public CorporateInvestmentAccount(decimal balance, string accountnumber) : base(balance, accountnumber)
        {
        }

        override public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Invalid Amount Deposited.");
            _balance += amount;
        }
        override public void Withdrawal(decimal amount)
        {
            if (amount > _balance)
                throw new Exception("Insufficient funds.");
            _balance -= amount;
        }

        override public void Transfer(decimal amount, IAccount destinationAccount)
        {
            this.Withdrawal(amount);
            destinationAccount.Deposit(amount);
        }

        override public decimal GetBalance()
        {
            return _balance;
        }
    }
}
