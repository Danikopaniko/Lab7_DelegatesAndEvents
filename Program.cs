using System;
using System.Collections.Generic;

namespace Lab7_DelegatesAndEvents
{
    public class BankTerminal
    {
        public event Action<int> OnMoneyWithdraw;

        public void Withdraw(int amount)
        {
            Console.WriteLine($"[Terminal] Withdraw: {amount}");
            OnMoneyWithdraw?.Invoke(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Action<int> printAction = num => Console.Write(num + " ");
            numbers.ForEach(printAction);
            Console.WriteLine("\n");

            BankTerminal terminal = new BankTerminal();
            terminal.OnMoneyWithdraw += amount => Console.WriteLine($"[SMS] -{amount}");
            terminal.Withdraw(500);
            Console.WriteLine();

            double startPrice = 1000;
            Func<double, double> discount5 = price => price * 0.95;
            Func<double, double> discount10 = price => price * 0.90;
            Func<double, double> discount100Uah = price => price - 100;

            Func<double, double> multicastDiscount = discount5;
            multicastDiscount += discount10;
            multicastDiscount += discount100Uah;

            double wrongResult = multicastDiscount(startPrice);
            Console.WriteLine($"Multicast result: {wrongResult}");

            double currentPrice = startPrice;
            foreach (Func<double, double> singleDiscount in multicastDiscount.GetInvocationList())
            {
                currentPrice = singleDiscount(currentPrice);
            }
            Console.WriteLine($"Sequential result: {currentPrice}");

            Console.ReadLine();
        }
    }
}