using System;

namespace Banking.Business.Model
{
    public abstract class InvestmentAccount : Account
    {
        protected InvestmentAccount(Person owner) : base(owner) { }

        public override void Withdraw(decimal amount)
        {
            if (this.WithdrawLimit.HasValue)
            {
                if (amount > this.WithdrawLimit.Value)
                {
                    throw new InvalidOperationException(string.Format("Withdraw max not exceed {0} dollars.", this.WithdrawLimit.Value));
                }
            }

            base.Withdraw(amount);
        }

        protected abstract decimal? WithdrawLimit { get; }
    }
}
