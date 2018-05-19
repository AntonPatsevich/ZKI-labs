using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

namespace _8
{
    static public class ClassProst
    {
        private static readonly Random ran = new Random();
        public static int GetP()
        {
            Random r = new Random();
            int chislo = r.Next(1, 1000);
            while (!Proverka(chislo))
                unchecked
                {
                    chislo++;
                }

            return chislo;
        }

        private static bool Proverka(int number) 
        {
            if ((number & 1) == 0)
                return (number == 2);

            var limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
                if ((number % i) == 0)
                    return false;

            return true;
        }

        public static long? GetG(long p) 
        {
            for (long i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return null;
        }

        static bool IsPRoot(long p, long a) 
        {
            if (a == 0 || a == 1) 
                return false;

            long pos = 1;
            var set = new HashSet<long>(); 

            for (long i = 0; i < p - 1; i++) 
            {
                pos = (pos * a) % p;
                if (set.Contains(pos))
                    return false;
                set.Add(pos);
            }
            return true;
        }
    }

    class EG
    {
        int Rand()
        {
            Random random = new Random();
            return random.Next();
        }

        string crypt(int p, int g, int x, string strIn)
        {
            string Text = "";
            BigInteger y = BigInteger.ModPow(g, x, p);

            Console.WriteLine("Открытый ключ:");
            Console.WriteLine("  p = " + p);
            Console.WriteLine("  g = " + g);
            Console.WriteLine("  y = " + y);

            Console.WriteLine("");
            Console.WriteLine("Закрытый ключ:");
            Console.WriteLine("x = " + x);

            if (strIn.Length > 0)
            {
                char[] temp = new char[strIn.Length - 1];
                temp = strIn.ToCharArray();
                for (int i = 0; i <= strIn.Length - 1; i++)
                {
                    BigInteger m = temp[i];
                    if (m >= p)
                        Console.WriteLine(String.Format
                          ("Ошибка ввода = {0} сообщение(М) должно быть меньше числа p= {1}!", m, p));

                    if (m > 0)
                    {
                        int k = Rand() % (p - 2) + 1;  
                        BigInteger a = BigInteger.ModPow(g, k, p); 
                        BigInteger l = BigInteger.Pow(y, k);
                        BigInteger b = BigInteger.ModPow(m * l, 1, p);
                        Text += a + " "  + b + " ";
                    }
                }
            }
            return Text;
        }

        string decrypt(int p, int x, string strIn)
        {
            string Text = "";

            if (strIn.Length > 0)
            {
                string[] strA = strIn.Trim().Split(' ');
                var temp = strA.GetEnumerator();

                while (temp.MoveNext())
                {
                    BigInteger ai = BigInteger.Parse((string)temp.Current);
                    temp.MoveNext();
                    BigInteger bi = BigInteger.Parse((string)temp.Current);
                    BigInteger x1 = BigInteger.Pow(ai, p - 1 - x);
                    BigInteger x2 = bi * x1;
                    BigInteger ans = BigInteger.ModPow(x2, 1, p);

                    Text += (char)(int)ans;
                }
            }
            return Text;
        }

        int p, g, x;

        public EG(int p, int g, int x)
        {
            this.p = p;
            this.g = g;
            this.x = x;
        }

        public string cryptText(string T)
        {
            return crypt(p, g, x, T);
        }

        public string decryptText(string T)
        {
            return decrypt(p, x, T);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int p, g, x;

            Random random = new Random();

            p = ClassProst.GetP();
            g = (int)ClassProst.GetG(p).Value;
            x = random.Next(2, p);
            EG m = new EG(p, g, x);

            Console.WriteLine("Эль-Гамаля.");
            Console.WriteLine("");
            Console.WriteLine("Введите текст для шифрования:");
            string shifrovka = Console.ReadLine();

            Console.WriteLine("");
            string deshifrovka = m.cryptText(shifrovka);

            Console.WriteLine(deshifrovka);
            Console.WriteLine("");
            Console.WriteLine("Расшифрованный текст");
            Console.WriteLine(m.decryptText(deshifrovka));

            Console.ReadLine();
        }
    }
}







