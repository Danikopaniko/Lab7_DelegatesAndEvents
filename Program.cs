using System;
using System.Collections.Generic;

namespace Lab7_DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Action<int> printAction = num => Console.Write(num + " ");

            numbers.ForEach(printAction);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}