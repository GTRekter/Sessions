using GettingStartedWithASPNETCore.VisualBasic;
using System;

namespace GettingStartedWithASPNETCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 0: References with other projects
            Console.Write("Enter a number: ");
            int number;
            string input;
            do
            {
                Console.WriteLine("enter number of conversations");
                input = Console.ReadLine();
            } while (int.TryParse(input, out number) == false);
            var isPrime = Number.IsPrime(number);
            Console.WriteLine(isPrime);
        }
    }
}
