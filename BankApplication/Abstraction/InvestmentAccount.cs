using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Interface;
using BankApplication.Abstraction;

namespace BankApplication.Abstraction
{
    abstract public class InvestmentAccount : Account
    {
        public InvestmentAccount(decimal balance, string accountnumber) : base(balance, accountnumber)
        {
        }
    }
}
