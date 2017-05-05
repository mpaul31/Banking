using System;

namespace Banking.Business.Model
{
    public class IndividualAccount : InvestmentAccount
    {
        private readonly decimal? withdrawLimit;

        public IndividualAccount(Person owner, decimal? withdrawLimit = null) : base(owner)
        {
            this.withdrawLimit = withdrawLimit;
        }

        protected override decimal? WithdrawLimit
        {
            get { return this.withdrawLimit; }
        }
    }
}
