using System;

namespace PrimeFactors
{
    class Program
    {
        static void Main()
        {
            var n = 125;
            for (var i = 2; i < n; )
            {
                if (n%i == 0)
                {
                    Console.WriteLine(i);
                    n = n/i;
                }
                else
                {
                    i += 1;
                }
            }
            Console.WriteLine(n);
            Console.Read();
        }
    }
}

