using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationZKI1
{
    class Program
    {
        static void Main(string[] args)
        {
            int raz = 0, n = 0, m = 0, z = 0, n1 = 0, i = 0, j = 0, k = 0, kaz = 0, m1=0, i1=0, j1=0, i2=0, m2=0, jo=0;
            string p1 = Convert.ToString(Console.ReadLine());
            char[] s = p1.ToCharArray();
            for (z = 1; z <= s.Length/2; z++)
            {
                if (s.Length % z == 0)
                {
                    m = s.Length / z;
                    n = z;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(m);
            char[,] mas = new char[n,m];
            for (j = 0; j < m; j++)
                for (i = 0; i < n; i++)            
                {
                    for (z = raz; z < s.Length; z+=s.Length)
                    {
                        mas[i, j] = s[z];
                    }
                    raz++;
                }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write("\t"+mas[i,j]);
                }
                Console.WriteLine("");
                }
            int[] key = new int[m2=m];
            for (k = 0; k < key.Length; k++)
            {
                key[k] = Convert.ToInt32(Console.ReadLine());
            }
            n1 = n;
            m1 = m;
            char[,] s2 = new char[n1,m1];         
                for (j = 0; j < mas.GetLength(1); j++)
                {
                    for (k = kaz; k < key.Length; k += key.Length)
                    {
                        if (j == k)
                        {
                            j1 = key[k];              
                            for (i = 0; i < mas.GetLength(0); i++)
                            {       
                                for (i1 = i2; i1 < s2.GetLength(0); i1+=s2.GetLength(0))
                                {
                                s2[i1, j1] = mas[i,j]; 
                                }
                            i2++;
                            i1 = 0;
                            }
                            i2 = 0;
                        }                      
                    }
                    kaz++;
                k = 0;
                }

                
            char[,] masZ = new char[];

            for (i1 = 0; i1 < s2.GetLength(0); i1++)
            {
                for (j1 = 0; j1 < s2.GetLength(1); j1++)
                {
                    Console.Write("\t"+s2[i1,j1]);
                }
                Console.WriteLine(" ");
            }
            Console.ReadKey();
        }
    }
}
