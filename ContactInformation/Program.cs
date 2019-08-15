using EncapsulationBankAccount.Dal;
using EncapsulationBankAccount.Entities;
using System;
using System.Collections.Generic;

namespace ContactInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            for (int i = 1; i < 156611; i++)
            {
                    Random rnd = new Random();
                int balance;
                if (i<=13000)
                    balance = rnd.Next(-150_000, 1);
                else if (i>13000 && i<=13000+130000)
                    balance = rnd.Next(0, 1_000_001);
                else
                    balance = rnd.Next(1_000_000, 1_000_000_000);
                accounts.Add(new Account(balance));
                Console.WriteLine(balance);
            }
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.AddAccounts(accounts);
        }
    }
}
