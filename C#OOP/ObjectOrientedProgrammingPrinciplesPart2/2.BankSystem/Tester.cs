using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    class Tester
    {
        static void Main(string[] args)
        {
            Account[] accounts = 
            {
                new LoanAccount(CustomerType.Company, 4329.43m, 0.33m,  10),
                new LoanAccount(CustomerType.Individual, 4329.43m, 0.33m, 10),

                new DepositAccount(CustomerType.Company, 1000m, 0.13m, 8),
                new DepositAccount(CustomerType.Individual, 1000m, 0.13m, 8),
                
                new MortgageAccount(CustomerType.Company, 5000.34m, 0.68m, 3),
                new MortgageAccount(CustomerType.Individual, 5000.34m, 0.68m, 3)
            };

            DepositAccount depositAccount = new DepositAccount(CustomerType.Company, 4324.5m, 0.1m, 3);

            depositAccount.Deposit(3000m);
            depositAccount.WithDraw(5000m);
            Console.WriteLine(depositAccount.Balance);
          

            foreach(var account in accounts)
            {
                Console.WriteLine(account.CalculateInterest());
            }
        }
    }
}
