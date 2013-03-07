using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    public abstract class Account
    {
        private CustomerType customer;
        private decimal balance;
        private decimal interestRate;

        protected Account(CustomerType customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public CustomerType Customer 
        {
            protected set
            {
                this.customer = value;
            }
            get
            {
                return this.customer;
            }
        }

        public decimal Balance
        {
            protected set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("The Account balance must be non-negative.");
                }
                else
                {
                    this.balance = value;
                }
            }
            get
            {
                return this.balance;
            }
        }

        public decimal InterestRate
        {
            protected set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("The Account interest rage must be non-negative.");
                }
                else
                {
                    this.interestRate = value;
                }
            }
            get
            {
                return this.interestRate;
            }
        }

        public abstract decimal CalculateInterest();

    }
}
