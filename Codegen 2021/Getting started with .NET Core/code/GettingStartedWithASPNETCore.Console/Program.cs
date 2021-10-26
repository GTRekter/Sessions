using VisualBasicLibrary = GettingStartedWithASPNETCore.VisualBasic;
using System;

namespace GettingStartedWithASPNETCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number;
            string input;
            do
            {
                Console.WriteLine("enter number of conversations");
                input = Console.ReadLine();
            } while (int.TryParse(input, out number) == false);

            var isPrime = VisualBasicLibrary.Number.IsPrime(number);
            Console.WriteLine(isPrime);

            isPrime = Number.IsPrime(number);
            Console.WriteLine(isPrime);
        }
    }
}
