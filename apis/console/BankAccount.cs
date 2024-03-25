using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public class BankAccount
    {
        public int AccountNumber { get; set; } 
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public BankAccount(int accntNum, string accntHold, decimal balance) { 
            this.AccountNumber = accntNum;
            this.AccountHolder = accntHold;
            this.Balance = balance;
        }


        public bool Deposit(decimal amount) {
            try {
                this.Balance += amount;
                return true;
            }
            catch { return false; }
            
        }

        public bool Withdraw(decimal amount)
        {
            try
            {
                if( (this.Balance - amount) < 0)
                    return false;
                else
                    this.Balance -= amount;
                return true;
            }
            catch { return false; }

        }

        public BankAccount DisplayAccountDetails()
        {
            return new BankAccount(this.AccountNumber, this.AccountHolder, this.Balance);   
        }
    }
}
