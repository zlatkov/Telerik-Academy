using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    public class LoanAccount : Account, IDepositable
    {
        private int loanPeriod;

        public LoanAccount(CustomerType customer, decimal balance, decimal interestRate, int loanPeriod)
            : base(customer, balance, interestRate)
        {
            this.LoanPeriod = loanPeriod;
        }

        public int LoanPeriod
        {
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The loan period must be non-negative.");
                }
                else
                {
                    this.loanPeriod = value;
                }
            }
            get
            {
                return this.loanPeriod;
            }
        }

        public void Deposit(decimal money)
        {
            if (money < 0m)
            {
                throw new ArgumentOutOfRangeException("Your can't deposit negative ammount of money.");
            }
            else
            {
                this.Balance += money;
            }
        }

        public override decimal CalculateInterest()
        {
            if (this.Customer == CustomerType.Individual && this.LoanPeriod <= 3)
            {
                return 0m;
            }
            else if (this.Customer == CustomerType.Company && this.LoanPeriod <= 2)
            {
                return 0m;
            }
            else
            {
                return this.LoanPeriod * this.InterestRate;
            }
        }
    }
}
