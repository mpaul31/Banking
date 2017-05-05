using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Banking.Business.Model
{
    public class Bank
    {
        private readonly IList<Account> accounts;

        public Bank(string name)
        {
            this.Name = name;
            this.accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            if (this.accounts.Contains(account)) return;

            this.accounts.Add(account);
        }

        public string Name
        {
            get;
            set;
        }

        public IReadOnlyCollection<Account> Accounts
        {
            get { return new ReadOnlyCollection<Account>(this.accounts); }
        }
    }
}
