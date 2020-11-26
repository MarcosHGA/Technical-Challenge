using System;

namespace Infra.Util
{
    public static class Util
    {
        public static bool CheckPrime(int number)
        {
            if (number <= 1) 
                return false;
            
            if (number == 2) 
                return true;
            
            if (number % 2 == 0) 
                return false;

            double boundary = Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static bool CheckDivisor(int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}
