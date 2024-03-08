using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank account1 = new Bank();
            Bank account2 = new Bank();
            account1.BankAccount("987654321", "Jane Smith", 500);
            account2.BankAccount("987654321", "Jane Smith", 500);

            // Perform some transactions
            account1.Deposit(500);
            account2.Withdraw(200);
            account1.Transfer(account2, 300);

            // Print transaction history
            account1.PrintTransactions();
            account2.PrintTransactions();

            Console.ReadLine();
        }
    }
}
