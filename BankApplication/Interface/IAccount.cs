using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Interface
{
    public interface IAccount
    {
        string AccountNumber { get; }
        void Deposit(decimal amount);
        void Withdrawal(decimal amount);
        void Transfer(decimal amount, IAccount DestinationAccount);
        decimal GetBalance();
    }
}
