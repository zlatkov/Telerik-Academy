using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    public class DepositAccount : Account, IDepositable, IWithDrawable
    {
        private int depositPeriod;

        public DepositAccount(CustomerType customer, decimal balance, decimal interestRate, int depositPeriod)
            : base(customer, balance, interestRate)
        {
            this.DepositPeriod = depositPeriod;
        }

        public int DepositPeriod
        {
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The deposit period must be non-negative.");
                }
                else
                {
                    this.depositPeriod = value;
                }
            }
            get
            {
                return this.depositPeriod;
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

        public void WithDraw(decimal money)
        {
            if (money < 0m)
            {
                throw new ArgumentOutOfRangeException("Your can't withdraw negative ammount of money.");
            }
            if (this.Balance < money)
            {
                throw new ArgumentOutOfRangeException("You are trying to withdraw more money than you have in your account");
            }
            else
            {
                this.Balance -= money;
            }
        }

        public override decimal CalculateInterest()
        {
            if (this.Balance < 1000m)
            {
                return 0m;
            }
            else
            {
                return this.DepositPeriod * this.InterestRate;
            }
        }
    }
}
