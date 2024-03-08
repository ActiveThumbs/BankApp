using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Bank
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; private set; }

        private List<Transaction> transactions = new List<Transaction>();

        public void BankAccount(string accountNumber, string owner, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            transactions.Add(new Transaction(amount, TransactionType.Deposit));
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (Balance < amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            transactions.Add(new Transaction(amount, TransactionType.Withdrawal));
            Console.WriteLine($"Withdrawn {amount:C}. New balance is {Balance:C}.");
        }

        public void Transfer(Bank destinationAccount, decimal amount)
        {
            if (destinationAccount == null)
            {
                Console.WriteLine("Invalid destination account.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive.");
                return;
            }

            if (Balance < amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            destinationAccount.Balance += amount;

            transactions.Add(new Transaction(amount, TransactionType.Transfer));
            Console.WriteLine($"Transferred {amount:C} to {destinationAccount.Owner}. New balance is {Balance:C}.");
        }

        public void PrintTransactions()
        {
            Console.WriteLine($"Transaction history for account {AccountNumber}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }

    enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public TransactionType Type { get; }

        public Transaction(decimal amount, TransactionType type)
        {
            Amount = amount;
            Date = DateTime.Now;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Date} - {Type}: {Amount:C}";
        }
    }

}
