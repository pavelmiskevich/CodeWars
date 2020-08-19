using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(digitalRoot(456));
            Console.WriteLine(rowSumOddNumbers(42)); //2
            Console.ReadLine();
        }

        /// <summary>
        /// Digital root is the recursive sum of all the digits in a number.
        ///Given n, take the sum of the digits of n.If that value has more than one digit, continue reducing in this way until a single-digit
        /// number is produced.This is only applicable to the natural numbers.
        /// </summary>
        private static int digitalRoot(long n)
        {
            int ret = 0;
            string str = n.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                ret += int.Parse(str.Substring(i, 1));
            }

            if (ret.ToString().Length > 1)
                ret = digitalRoot(ret);

            return ret;
        }

        /// <summary>
        /// Given the triangle of consecutive odd numbers:
        /// Calculate the row sums of this triangle from the row index (starting at index 1) e.g.:
        /// Дан треугольник нечетных чисел, посчитать сумму чисел в строке
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long rowSumOddNumbers(long n)
        {
            //List используется только из-за указания в задаче
            //проще вычислять "на лету" без списка
            long ret = 0, rowCount = 0;
            int j = 0;
            List<List<long>> list = new List<List<long>> {new List<long>()};

            for (long i = 1; i < long.MaxValue; i += 2)
            {
                list[j].Add(i);
                rowCount++;

                if (rowCount == j + 1)
                {
                    rowCount = 0;
                    j++;
                    if (j == n)
                        break;
                    list.Add(new List<long>());
                }
            }

            List<long> l = list[(int)(n - 1)];
            foreach (long i in l)
            {
                ret += i;
            }

            return ret;
        }
    }
}
