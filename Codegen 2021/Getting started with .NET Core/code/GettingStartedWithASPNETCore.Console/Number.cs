using System;
using System.Collections.Generic;
using System.Text;

namespace GettingStartedWithASPNETCore.ConsoleApp
{
    public static class Number
    {
        public static bool IsPrime(int number)
        {
            int primeI;
            bool primeFlag;
            primeFlag = true;
            for (primeI = 2; primeI <= number/2; primeI++)
            {
                if (number % primeI == 0)
                {
                    return false;
                }
            }
            return primeFlag;
        }
    }
}