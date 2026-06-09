using System;

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

            BankTerminal terminal = new BankTerminal();
            terminal.OnMoneyWithdraw += amount => Console.WriteLine($"[SMS] -{amount}");

            terminal.Withdraw(500);

            // terminal.OnMoneyWithdraw = null; 
            // terminal.OnMoneyWithdraw.Invoke(999999); 

            Console.ReadLine();
        }
    }
}