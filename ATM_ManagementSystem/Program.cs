using System;

namespace atm
{
    class Program
    {

        private const string CARD_NUMBER_1 = "1234567890";
        private const string PIN_NUMBER_1 = "1234";
        private const string USER_NAME_1 = "Payal Thakur";

        private const string CARD_NUMBER_2 = "0987654321";
        private const string PIN_NUMBER_2 = "5678";
        private const string USER_NAME_2 = "Aniket Kumar";

        private const string CARD_NUMBER_3 = "5555555555";
        private const string PIN_NUMBER_3 = "9012";
        private const string USER_NAME_3 = "Aman Sharma";


        private static decimal depositAmount = 0;
        private static string currentUser = string.Empty;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM Console!");

            string cardNumber;
            string pinNumber;

            bool validCredentials;
            do
            {
                Console.Write("Enter your debit card number: ");
                cardNumber = Console.ReadLine();

                Console.Write("Enter your PIN number: ");
                pinNumber = Console.ReadLine();

                validCredentials = ValidateCredentials(cardNumber, pinNumber);

                if (!validCredentials)
                {
                    Console.WriteLine("Invalid card number or PIN. Please try again.");
                }
            } while (!validCredentials);

            bool continueTransaction = true;
            while (continueTransaction)
            {
                Console.WriteLine($"\nWelcome, {currentUser}!");
                Console.WriteLine('Hello World');
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Withdraw();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        continueTransaction = false;
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.ReadLine();
        }

        static bool ValidateCredentials(string cardNumber, string pinNumber)
        {
            if (cardNumber == CARD_NUMBER_1 && pinNumber == PIN_NUMBER_1)
            {
                currentUser = USER_NAME_1;
                return true;
            }


            else if (cardNumber == CARD_NUMBER_2 && pinNumber == PIN_NUMBER_2)
            {
                currentUser = USER_NAME_2;
                return true;
            }
            else if (cardNumber == CARD_NUMBER_3 && pinNumber == PIN_NUMBER_3)
            {
                currentUser = USER_NAME_3;
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter the amount to withdraw: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

            if (withdrawAmount > depositAmount)
            {
                Console.WriteLine("Insufficient funds. Cannot withdraw more than the deposited amount.");
            }
            else
            {
                depositAmount -= withdrawAmount;
                Console.WriteLine($"Withdrawal successful. Your new balance is: {depositAmount}");
            }
        }

        static void Deposit()
        {
            Console.Write("Enter the amount to deposit: ");
            decimal depositAmountInput = decimal.Parse(Console.ReadLine());

            depositAmount += depositAmountInput;
            Console.WriteLine($"Deposit successful. Your new balance is: {depositAmount}");
        }
    }
}