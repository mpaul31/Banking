using System;

namespace Banking.Business.Model
{
    public abstract class Account
    {
        protected Account(Person owner)
        {
            if (owner == null) throw new ArgumentNullException("owner");

            this.Owner = owner;
            this.Balance = 0;
        }

        public Person Owner
        {
            get;
            set;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public virtual void Deposit(decimal amount)
        {
            EnsureAmountGreaterThanZero(amount);

            this.Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            EnsureAmountGreaterThanZero(amount);

            this.Balance -= amount;
        }

        public virtual void Transfer(Account destination, decimal amount)
        {
            EnsureAmountGreaterThanZero(amount);

            if (this.Balance < amount)
            {
                throw new InvalidOperationException("Account does not have sufficient funds for the transfer.");
            }

            this.Withdraw(amount);

            destination.Deposit(amount);            
        }

        private static void EnsureAmountGreaterThanZero(decimal amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException("amount", "Amount must be greater than zero.");
        }
    }
}
