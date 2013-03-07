using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    public class MortgageAccount : Account, IDepositable
    {
        private int mortgagePeriod;

        public MortgageAccount(CustomerType customer, decimal balance, decimal interestRate, int morgagePeriod)
            : base(customer, balance, interestRate)
        {
            this.MortgagePeriod = morgagePeriod;
        }

        public int MortgagePeriod
        {
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The mortgage period must be non-negative.");
                }
                else
                {
                    this.mortgagePeriod = value;
                }
            }
            get
            {
                return this.mortgagePeriod;
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
            if (this.MortgagePeriod <= 12 && this.Customer == CustomerType.Company)
            {
                return (this.MortgagePeriod * this.InterestRate) / 2m;
            }
            else if (this.MortgagePeriod <= 6 && this.Customer == CustomerType.Individual)
            {
                return 0m;
            }
            else
            {
                return this.MortgagePeriod * this.InterestRate;
            }
        }
    }
}
