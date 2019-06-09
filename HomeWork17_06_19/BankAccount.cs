using System;
using System.Threading;

namespace HomeWork17_06_19
{
    public class BankAccount
    {
        public int _cash { get; set; } = 0;
        private object lockObject = new object();

        public void AddMoney()
        {
            lock (lockObject)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5* new Random().Next(100));
                _cash += 20;
                Show();
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine();
            }
        }

        public void RemoveMoney()
        {
            lock (lockObject)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5 * new Random().Next(100));
                _cash -= 20;
                Show();
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine();
            }
        }

        public void Show()
        {
            Console.WriteLine(_cash);
        }
    }
}
