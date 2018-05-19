using System;
using System.Text;
using System.Collections.Generic;

namespace Diff
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            decimal g, p, a, b, A, B, K1, K2;
            p = 19;
            g = 3;

            // и тип g < p && g > 1 должно быть
            // g^(p-1) mod p = 1

            a = rand.Next(0, 10);
            b = rand.Next(5, 15);

            Console.WriteLine($" a - {a}, b - {b}");

            A = forgshecki(g, a, p);
            B = forgshecki(g, b, p);

            Console.WriteLine($" A - {A}, B - {B}");

            K1 = forgshecki(B, a, p); // g^ключек mod p
            K2 = forgshecki(A, b, p);

            Console.WriteLine("K" + "{K1} : {K2}");
            Console.ReadLine();
        }
        static decimal forgshecki(decimal g, decimal step, decimal p)
        {
            decimal t = g;
            for (int i = 0; i < step; i++)
                t *= g;
            return t % p;
        }
    }
}