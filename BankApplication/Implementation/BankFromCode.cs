using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Interface;

namespace BankApplication.Implementation
{
    public class BankFromCode : IBank
    {
        public string BankName { get; }

        public BankFromCode()
        {
            BankName = "MyBank";
        }
    }
}
