using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate;
        
        public SavingsAccount(decimal interest, int num, string hold, decimal bal) 
            : base(num, hold, bal)
        {
            InterestRate = interest;
        }

        public void ApplyInterest(decimal intrs)
        {
            this.Balance += Balance * intrs;
        }

        public string GetInfo()
        {
            return $"Number:{this.AccountNumber},Holder:{this.AccountHolder},Balance:{this.Balance},InterestRate:{InterestRate};";
        }
    }
}
