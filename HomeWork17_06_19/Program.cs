using System;
using System.Threading;

namespace HomeWork17_06_19
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            BankAccoutCashChange(bankAccount);

            Console.ReadLine();
            (bankAccount as BankAccount).Show();
            Console.ReadLine();
        }

        static void BankAccoutCashChange(BankAccount bankAccount)
        {
            var threads = new Thread[100];

            for (int i = 0; i < 50; i++)
            {
                threads[i] = new Thread(bankAccount.AddMoney);
            }

            for (int i = 50; i < 100; i++)
            {
                threads[i] = new Thread(bankAccount.RemoveMoney);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}
