using System;
using System.Collections.Generic;

namespace Diobank
{
    class Program
    {
        static List<Account> accountsList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        AddAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption();
            }

            Console.WriteLine("Thank you for using our services.");
        }

        private static int checkAccountNumber(int accountNumber)
        {
            while (accountNumber < 0 || accountNumber >= accountsList.Count)
            {
                Console.WriteLine("Type a valid account number, please");
                accountNumber = int.Parse(Console.ReadLine());
            }
            return accountNumber;
        }

        private static double checkValue(double value)
        {
            while (value < 0)
            {
                Console.WriteLine("Type a valid value, please");
                value = double.Parse(Console.ReadLine());
            }
            return value;
        }
        private static void Deposit()
        {
            Console.Write("Type the account's number: ");
            int accountIndex = int.Parse(Console.ReadLine());
            accountIndex = checkAccountNumber(accountIndex);

            Console.Write("Type the deposit value: ");
            double depositValue = double.Parse(Console.ReadLine());
            depositValue = checkValue(depositValue);

            accountsList[accountIndex].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.Write("Type the account's number: ");
            int accountIndex = int.Parse(Console.ReadLine());
            accountIndex = checkAccountNumber(accountIndex);

            Console.Write("Type the withdraw value: ");
            double withdrawValue = double.Parse(Console.ReadLine());
            withdrawValue = checkValue(withdrawValue);

            accountsList[accountIndex].Withdraw(withdrawValue);
        }

        private static void Transfer()
        {
            Console.Write("Type the source account number: ");
            int sourceAccountIndex = int.Parse(Console.ReadLine());
            sourceAccountIndex = checkAccountNumber(sourceAccountIndex);

            Console.Write("Type the destination account number: ");
            int destinationAccountIndex = int.Parse(Console.ReadLine());
            destinationAccountIndex = checkAccountNumber(destinationAccountIndex);

            Console.Write("Type the value you want to transfer: ");
            double transferValue = double.Parse(Console.ReadLine());
            transferValue = checkValue(transferValue);

            accountsList[sourceAccountIndex].Transfer(transferValue, accountsList[destinationAccountIndex]);
        }

        private static void AddAccount()
        {
            Console.WriteLine("Add a new account");

            Console.Write("Type 1 for Natural Account or 2 for Legal Account: ");
            int inputAccountType = int.Parse(Console.ReadLine());

            Console.Write("Type the customer name: ");
            string inputName = Console.ReadLine();

            Console.Write("Type the opening balance: ");
            double inputBalance = double.Parse(Console.ReadLine());

            Console.Write("Type the opening credit: ");
            double inputCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)inputAccountType,
                                        balance: inputBalance,
                                        credit: inputCredit,
                                        name: inputName);

            accountsList.Add(newAccount);
        }

        private static void ListAccounts()
        {
            Console.WriteLine("List accounts");

            if (accountsList.Count == 0)
            {
                Console.WriteLine("There is no registered account.");
                return;
            }

            for (int i = 0; i < accountsList.Count; i++)
            {
                Account account = accountsList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Diobank at your disposure!!!");
            Console.WriteLine("Inform desired option:");

            Console.WriteLine("1- List accounts");
            Console.WriteLine("2- Add a new account");
            Console.WriteLine("3- Transfer");
            Console.WriteLine("4- Withdraw");
            Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Clean screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
