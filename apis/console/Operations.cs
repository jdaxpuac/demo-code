using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public class Operations
    {
        List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        public Operations() {
            ShowMenu();  
        } 

        public void ShowMenu () {
            string op;
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("select operation:");
            Console.WriteLine("1 - create account");
            Console.WriteLine("2 - display account details");
            Console.WriteLine("3 - deposit");
            Console.WriteLine("4 - withdraw");
            Console.WriteLine("5 - apply interest");
            Console.WriteLine("6 - save accounts");
            op = Console.ReadLine();

            string nmbr,amnt;
            switch (op)
            {
                case "1": CreateNewAccount(); break;
                case "2":
                    Console.WriteLine("Please input account number");
                    DisplayAccountDetails(int.Parse(Console.ReadLine()));
                    break;
                case "3":
                    Console.WriteLine("Please input account number");
                    nmbr = Console.ReadLine();
                    Console.WriteLine("Please input amount to deposit");
                    amnt = Console.ReadLine();
                    Deposit(int.Parse(nmbr), decimal.Parse(amnt));
                    break;
                case "4":
                    Console.WriteLine("Please input account number");
                    nmbr = Console.ReadLine();
                    Console.WriteLine("Please input amount to withdraw");
                    amnt = Console.ReadLine();
                    Withdraw(int.Parse(nmbr), decimal.Parse(amnt)); 
                    break;
                case "5":
                    Console.WriteLine("Please input account number");
                    nmbr = Console.ReadLine();
                    Console.WriteLine("Please input interest rate");
                    amnt = Console.ReadLine();
                    SetInterest(int.Parse(nmbr), decimal.Parse(amnt));
                    break;
                case "6":
                    SaveAccountsToFile();
                    break;
                default: Console.WriteLine("Select a valid option"); ShowMenu(); break;
            }
        }

        public void CreateNewAccount()
        {
            string hold,bal,interest;
            int number;
            Console.WriteLine("Holders name");
            hold = Console.ReadLine();

            Console.WriteLine("Account Balance");
            bal = Console.ReadLine();

            Console.WriteLine("Interest Rate");
            interest = Console.ReadLine();

            number = savingsAccounts.Count;

            savingsAccounts.Add(
                new SavingsAccount(
                    decimal.Parse(interest), 
                    number + 1, 
                    hold, 
                    decimal.Parse(bal))); ;

            Console.WriteLine("Account created");
            ShowMenu();
        }

        public void DisplayAccountDetails(int accNum)
        {
            SavingsAccount accnt = null;
            accnt = savingsAccounts.FirstOrDefault(n => n.AccountNumber == accNum);
            if (accnt != null)
            {
                Console.WriteLine(accnt.GetInfo());
            }
            else
            {
                Console.WriteLine("Account not found");
                
            }
            ShowMenu();
        }

        public void Deposit(int accNum, decimal amount) 
        {
            SavingsAccount accnt = null;
            accnt = savingsAccounts.FirstOrDefault(n => n.AccountNumber == accNum);
            if (accnt != null)
            {
                accnt.Deposit(amount);
                Console.WriteLine("Deposit Done");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
            ShowMenu();
        }

        public void Withdraw(int accNum, decimal amount)
        {
            SavingsAccount accnt = null;
            accnt = savingsAccounts.FirstOrDefault(n => n.AccountNumber == accNum);
            if (accnt != null)
            {
                accnt.Withdraw(amount);
                Console.WriteLine("Withdraw done");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
            ShowMenu();
        }


        public void SetInterest(int accNum, decimal interest)
        {
            SavingsAccount accnt = null;
            accnt = savingsAccounts.FirstOrDefault(n => n.AccountNumber == accNum);
            if (accnt != null)
            {
                accnt.InterestRate = interest;
                Console.WriteLine("interest Rate updated");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
            ShowMenu();
        }

        public void SaveAccountsToFile()
        {
            var logPath = @"C:\TMP\savedAccounts.txt";
            var logFile = System.IO.File.Create(logPath);
            var logWriter = new System.IO.StreamWriter(logFile);
            foreach(SavingsAccount acc in savingsAccounts)
            {
                logWriter.WriteLine(acc.GetInfo());
            }
            logWriter.Dispose();
            Console.WriteLine("file saved");
            ShowMenu();
        }

    }
}
