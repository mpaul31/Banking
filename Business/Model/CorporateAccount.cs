using System;

namespace Banking.Business.Model
{
    public class CorporateAccount : InvestmentAccount
    {
        public CorporateAccount(Person owner) : base(owner) { }

        protected override decimal? WithdrawLimit
        {
            get
            {
                return null;
            }
        }
    }
}
