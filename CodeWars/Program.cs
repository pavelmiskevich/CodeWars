﻿using System;
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
            #region old task
            #region WriteLine
            //Console.WriteLine(digitalRoot(456));
            #endregion WriteLine
            #region rowSumOddNumbers
            //Console.WriteLine(rowSumOddNumbers(42)); //2
            #endregion rowSumOddNumbers
            #region IsTriangle
            //Console.WriteLine(IsTriangle(5, 7, 10)); //5, 7, 10
            #endregion IsTriangle
            #region ArrayDiff
            //int [] temp = ArrayDiff(new int[]{1,2,2}, new int[] {1}); //new int[]{1,2}, new int[] {1}
            //foreach (int i in temp)
            //{
            //    Console.Write($"{i} ");
            //}
            //Console.WriteLine(AlphabetPosition("The narwhal bacons at midnight.") + "|"); //The sunset sets at twelve o' clock.
            #endregion ArrayDiff
            #region OpenOrSenior
            //string[] temp = (string[]) OpenOrSenior(new[] { new[] { 59, 12 }, new[] { 45, 21 }, new[] { -12, -2 }, new[] { 12, 12 } }); //new[] { new[] { 3, 12 }, new[] { 55, 1 }, new[] { 91, -2 }, new[] { 54, 23 } })
            //foreach (string i in temp)
            //{
            //    Console.Write($"{i} ");
            //}
            #endregion OpenOrSenior
            #region GetReadableTime
            //Console.WriteLine(GetReadableTime(0)); //"00:00:00"
            //Console.WriteLine(GetReadableTime(5)); //"00:00:05"
            //Console.WriteLine(GetReadableTime(60)); //"00:01:00"
            //Console.WriteLine(GetReadableTime(86399)); //"23:59:59"
            //Console.WriteLine(GetReadableTime(359999)); //"99:59:59"
            #endregion GetReadableTime
            #endregion old task
            #region productFib
            ulong[] temp = productFib(4895); //new ulong[] { 55, 89, 1 };
            foreach (ulong i in temp)
            {
                Console.Write($"{i} ");
            }
            #endregion productFib
            Console.ReadLine();
        }

        /// <summary>
        /// Digital root is the recursive sum of all the digits in a number.
        /// Given n, take the sum of the digits of n.If that value has more than one digit, continue reducing in this way until a single-digit
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

        /// <summary>
        /// Is this a triangle?
        /// Implement a method that accepts 3 integer values a, b, c.The method should return true if a triangle can be built with
        /// the sides of given length and false in any other case.
        /// (In this case, all triangles must have surface greater than 0 to be accepted).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsTriangle(int a, int b, int c)
        {
            return ((a + b) > c) && ((a + c) > b) && ((b + c) > a);
        }

        /// <summary>
        /// Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.
        /// It should remove all values from list a, which are present in list b.
        /// Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
        /// If a value is present in b, all of its occurrences must be removed from the other:
        /// Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int[] ArrayDiff(int[] a, int[] b)
        {
            int[] c = new int[a.Length];
            int k = 0;

            if (a.Length == 0)
                return new int[] { };
            if (b.Length == 0)
                return a;

            foreach (int i in a)
            {
                var isExists = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] == i) isExists = true;
                }

                if (!isExists)
                {
                    c[k] = i;
                    k++;
                }
            }

            int[] ret = new int[k];
            int n = 0;
            for (int i = 0; i < k; i++)
            {
                if (!string.IsNullOrEmpty(c[i].ToString()))
                {
                    ret[n] = c[i];
                    n++;
                }
            }

            return ret;
            // глупое решение, которое убирает и значимые нули из массива в том числе
            //return c.Where(x => x != 0).ToArray();
        }

        /// <summary>
        /// In this kata you are required to, given a string, replace every letter with its position in the alphabet.
        /// If anything in the text isn't a letter, ignore it and don't return it.
        /// "a" = 1, "b" = 2, etc.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AlphabetPosition(string text)
        {
            string ret = "";
            string str = "abcdefghijklmnopqrstuvwxyz";
            
            foreach (char c in text.ToLower())
            {
                int i = str.IndexOf(c) + 1;
                if (i > 0)
                    ret += $"{i} ";
            }
            int num = str.IndexOf('я');
            return ret.TrimEnd();
            //LINQ
            //return (from c in text.ToLower() let i = str.IndexOf(c) + 1 where str.IndexOf(c) > 0 select i).Aggregate("", (current, i) => current + $"{i} ").TrimEnd;
        }

        /// <summary>
        /// The Western Suburbs Croquet Club has two categories of membership, Senior and Open. They would like your help with an application form that will tell prospective members which category they will be placed.
        /// To be a senior, a member must be at least 55 years old and have a handicap greater than 7. In this croquet club, handicaps range from -2 to +26; the better the player the lower the handicap.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            string[] ret = new string[data.Length];
            //не моложе 55 лет и иметь гандикап больше 7
            int i = 0;
            foreach (int[] ints in data)
            {
                ret[i] = (ints[0] >= 55 && ints[1] > 7) ? "Senior" : "Open";
                i++;
            }

            return ret;
        }

        /// <summary>
        /// Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)
        /// HH = hours, padded to 2 digits, range: 00 - 99
        /// MM = minutes, padded to 2 digits, range: 00 - 59
        /// SS = seconds, padded to 2 digits, range: 00 - 59
        /// The maximum time never exceeds 359999 (99:59:59)
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string GetReadableTime(int seconds)
        {
            string ret = $"{(seconds / 3600):00}:{(seconds % 3600 / 60):00}:{(seconds % 60):00}";
            return ret;
        }

        /// <summary>
        /// The Fibonacci numbers are the numbers in the following integer sequence (Fn):
        /// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...
        /// such as
        /// F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.
        /// Given a number, say prod(for product), we search two Fibonacci numbers F(n) and F(n+1) verifying
        /// F(n) * F(n+1) = prod.
        /// Your function productFib takes an integer(prod) and returns an array:
        /// [F(n), F(n + 1), true] or {F(n), F(n+1), 1}
        /// or(F(n), F(n+1), True)
        /// depending on the language if F(n) * F(n+1) = prod.
        /// If you don't find two consecutive F(m) verifying F(m) * F(m+1) = prodyou will return
        ///         [F(m), F(m + 1), false] or {F(n), F(n+1), 0}
        /// or(F(n), F(n+1), False)
        /// F(m) being the smallest one such as F(m) * F(m+1) > prod.
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static ulong[] productFib(ulong prod)
        {
            ulong prev = 0, next = 0;
            bool more = false;
            ulong i = 0;

            while (!more)
            {
                //next = fib(i);
                next = fib(i);
                if (prev * next >= prod)
                    more = true;
                else
                {
                    prev = next;
                    i++;
                }
            }

            var ret = new ulong[] { (ulong) prev, (ulong) next, ulong.Parse((prev * next == prod) ? "1" : "0")};

            return ret;
        }

        //static int fib(int n)
        //{
        //    return n > 1 ? fib(n - 1) + fib(n - 2) : n;
        //}

        static ulong FibRec(ulong p1, ulong p2, ulong n)
        {
            return (ulong) n == 0 ? p1 : FibRec(p2, p1 + p2, n - 1);
        }
        static ulong fib(ulong n) { return FibRec(0, 1, n); }

    }
}
