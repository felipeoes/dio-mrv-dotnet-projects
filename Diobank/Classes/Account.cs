using System;

namespace Diobank
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            // Validação de saldo suficiente
            if (this.Balance - withdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Insufficient balance!");
                return false;
            }
            this.Balance -= withdrawValue;

            Console.WriteLine("{0} account's current balance is {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {   
            this.Balance += depositValue;

            Console.WriteLine("{0} account's current balance is {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account destinyAccount)
        {
            if (this.Withdraw(transferValue))
            {
                destinyAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "AccountType: " + this.AccountType + " | ";
            retorno += "Name: " + this.Name + " | ";
            retorno += "Balance: " + this.Balance + " | ";
            retorno += "Credit: " + this.Credit;
            return retorno;
        }
    }
}