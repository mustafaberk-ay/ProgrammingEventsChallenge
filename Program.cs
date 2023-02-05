using System;

namespace ProgrammingEventsChallenge
{
    internal class Program
    {
        public delegate void myEventHandler(int balance);
        class PiggyBank
        {
            private int _balance;
            public event myEventHandler balanceChanged;

            public int Balance
            {
                set
                {
                    this._balance = value;
                    balanceChanged(_balance);
                }
                get 
                { 
                    return this._balance;
                }
            }

            public void PrintBalance(int balance)
            {
                Console.WriteLine("The balance amount is {0}", balance);
            }

            public void CheckBalance(int balance)
            {
                if(balance > 500)
                {
                    Console.WriteLine("Your have reached your savings goal! You have {0}", balance);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How much to deposit?");
            string userInput = Console.ReadLine();

            PiggyBank obj = new PiggyBank();
            obj.balanceChanged += new myEventHandler(obj.CheckBalance);
            obj.balanceChanged += new myEventHandler(obj.PrintBalance);

            while (userInput != "exit")
            {
                int depositAmount = Convert.ToInt32(userInput);
                obj.Balance += depositAmount;

                Console.WriteLine("How much to deposit?");
                userInput = Console.ReadLine();
            }
        }
    }
}
