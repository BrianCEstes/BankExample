using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Interface;

namespace BankApplication.Implementation
{
    public class ConsoleOutput : IOutput
    {
        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
