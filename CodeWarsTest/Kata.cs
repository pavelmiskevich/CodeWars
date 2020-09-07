using System;
using System.Collections.Generic;
using System.Text;

public static class Kata
{
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
            ret += Int32.Parse(str.Substring(i, 1));
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
        List<List<long>> list = new List<List<long>> { new List<long>() };

        for (long i = 1; i < Int64.MaxValue; i += 2)
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
            if (!String.IsNullOrEmpty(c[i].ToString()))
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

        var ret = new ulong[] { (ulong)prev, (ulong)next, UInt64.Parse((prev * next == prod) ? "1" : "0") };

        return ret;
    }

    //static int fib(int n)
    //{
    //    return n > 1 ? fib(n - 1) + fib(n - 2) : n;
    //}

    private static ulong FibRec(ulong p1, ulong p2, ulong n)
    {
        return (ulong)n == 0 ? p1 : FibRec(p2, p1 + p2, n - 1);
    }

    private static ulong fib(ulong n) { return FibRec(0, 1, n); }

    /// <summary>
    /// Your task is to sort a given string. Each word in the string will contain a single number. This number is the position the word should have in the result.
    /// Note: Numbers can be from 1 to 9. So 1 will be the first word(not 0).
    /// If the input string is empty, return an empty string. The words in the input String will only contain valid consecutive numbers.
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public static string Order(string words)
    {
        string ret = "";
        string[] arrStr = words.Split(' ');
        string[] arrStrRet = new string[9];
        foreach (string s in arrStr)
        {
            foreach (char c in s)
            {
                Int32.TryParse(c.ToString(), out var k);
                if (k == 0) continue;
                arrStrRet[k - 1] = s;
                break;
            }
        }

        foreach (string s1 in arrStrRet)
        {
            if (s1 != null)
                ret += $"{s1} ";
        }
        return ret.TrimEnd();
    }

    /// <summary>
    /// There is a queue for the self-checkout tills at the supermarket. Your task is write a function to calculate the total time required for all the customers to check out!
    /// input
    /// customers: an array of positive integers representing the queue.Each integer represents a customer, and its value is the amount of time they require to check out.
    /// n: a positive integer, the number of checkout tills.
    /// output
    /// The function should return an integer, the total time required.
    /// </summary>
    /// <param name="customers"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long QueueTime(int[] customers, int n)
    {
        long ret = 0;
        long[] arrTime = new long[n];
        foreach (int customer in customers)
        {
            long minArrTimeValue = 0;
            int queueNumber = 0;
            for (int i = 0; i < arrTime.Length; i++)
            {
                if (i == 0) minArrTimeValue = arrTime[i];
                else if (arrTime[i] < minArrTimeValue)
                {
                    minArrTimeValue = arrTime[i];
                    queueNumber = i;
                }
            }
            arrTime[queueNumber] += customer;
            //arrTime[Array.IndexOf(arrTime, arrTime.Min())] += customer;
        }
        foreach (long l in arrTime)
        {
            if (ret < l) ret = l;
        }
        return ret;
        //return arrTime.Max();
    }

    //using System.Collections.Generic;
    //using System.Linq;

    /// <summary>
    /// Find the unique number
    /// There is an array with some numbers. All numbers are equal except for one. Try to find it!
    /// findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
    /// findUniq([ 0, 0, 0.55, 0, 0 ]) === 0.55
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static int GetUnique(IEnumerable<int> numbers)
    {
        #region array solution
        int notUnique = 0;
        int? prev = null;
        foreach (int number in numbers)
        {
            if (prev == number)
            {
                notUnique = number;
                break;
            }
            prev = number;
        }
        foreach (int number in numbers)
        {
            if (!notUnique.Equals(number))
                return number;
            //if (notUnique != number)
            //{
            //    ret = number;
            //    break;
            //}
        }
        #endregion array solution
        #region LINQ solution
        //var unique = numbers.Distinct();
        //foreach (int i in unique)
        //{
        //    //int c = numbers.Count(x => x == i);
        //    int c = numbers.Count(i.Equals);
        //    if (c == 1)
        //        return i;
        //}
        #endregion LINQ solution
        return 0;
    }

    /// <summary>
    /// 5 kyu Greed is Good
    /// Greed is a dice game played with five six-sided dice. Your mission, should you choose to accept it, is to score a throw according
    /// to these rules. You will always be given an array with five six-sided dice values.
    /// </summary>
    /// <param name="dice"></param>
    /// <returns></returns>
    public static int Score(int[] dice)
    {
        int ret = 0;
        int[] dup = new int[6];
        foreach (int i in dice)
        {
            dup[i - 1]++;
        }
        #region better solution
        for (int i = 0; i < dup.Length; i++)
        {
            switch (i)
            {
                case 0:
                    ret += (dup[i] / 3 * 1000) + dup[i] % 3 * 100;
                    break;
                case 4:
                    ret += ((dup[i] / 3 * (i + 1)) * 100) + dup[i] % 3 * 50;
                    break;
                default:
                    ret += ((dup[i] / 3 * (i + 1)) * 100);
                    break;
            }
        }
        #endregion better solution
        #region simple solution
        //for (int i = 0; i < dup.Length; i++)
        //{
        //    if (dup[i] >= 3)
        //    {
        //        switch (i)
        //        {
        //            case 0:
        //                ret += ((i + 1) * 1000) + (dup[i] - 3) * 100;
        //                break;
        //            case 4:
        //                ret += ((i + 1) * 100) + (dup[i] - 3) * 50;
        //                break;
        //            default:
        //                ret += (i + 1) * 100;
        //                break;
        //        }
        //    }
        //    else
        //        if (dup[i] > 0)
        //            switch (i)
        //            {
        //                case 0:
        //                    ret += dup[i] * 100;
        //                    break;
        //                case 4:
        //                    ret += dup[i] * 50;
        //                    break;
        //            }

        //}
        #endregion simple solution
        return ret;
    }

    private static string sepStart = "([{";
    private static string sepEnd = ")]}";
    /// <summary>
    /// 5 kyu Molecule to atoms
    /// </summary>
    /// <param name="formula"></param>
    /// <returns></returns>
    /// TODO: Test Failed Your function should correctly parse a "chemical formula" from Dante's seventh circle of hell ;)
    public static Dictionary<string, int> ParseMolecule(string formula)
    {
        //string str = "";
        //char[] chars = formula.ToCharArray();
        //List <int> koefs = new List<int>() { 1, 0 };
        //int k = 1;
        //var ret = new Dictionary<string, int>();
        #region wrong solution
        //for (int i = 0; i < chars.Length; i++)
        //{
        //    if (sepEnd.Contains(chars[i]))
        //    {
        //        if (chars.Length > i + 1 && Char.IsDigit(chars[i + 1]))
        //            koefs.Add(koefs[koefs.Count - 1] * int.Parse(chars[i + 1].ToString()));
        //        else
        //            koefs.Add(1);
        //    }
        //}
        //for (int i = 0; i < chars.Length; i++)
        //{
        //    if (sepStart.Contains(chars[i]))
        //    {
        //        k++;
        //        continue;
        //    }
        //    if (sepEnd.Contains(chars[i])) continue;
        //    if (char.IsUpper(chars[i]))
        //        str = chars[i].ToString();
        //    if (chars.Length > i + 1)
        //    {
        //        if (char.IsLetter(chars[i + 1]))
        //        {
        //            if (!char.IsUpper(chars[i + 1]))
        //                str += chars[i + 1].ToString();
        //            else
        //            {
        //                //str = chars[i].ToString();
        //                if (str != "")
        //                {
        //                    if (!ret.ContainsKey(str))
        //                        ret.Add(str, koefs[k]);
        //                    else
        //                        ret[str] += koefs[k];
        //                }
        //                str = "";
        //            }
        //        }
        //        else
        //        {
        //            if (char.IsDigit(chars[i + 1]))
        //            {
        //                //complete digit
        //                int n = 1;
        //                string num = "";
        //                while (chars.Length > i + n && char.IsDigit(chars[i + n]))
        //                {
        //                    num += chars[i + n].ToString();
        //                    n++;
        //                }
        //                i += n - 1;
        //                if (!ret.ContainsKey(str))
        //                    ret.Add(str, int.Parse(num) * koefs[k]);
        //                else
        //                    ret[str] += int.Parse(num) * koefs[k];
        //                str = "";
        //            }
        //            else
        //            {
        //                if (!sepEnd.Contains(chars[i + 1]))
        //                {
        //                    if (str != "")
        //                    {
        //                        if (!ret.ContainsKey(str))
        //                            ret.Add(str, 1 * koefs[k]);
        //                        else
        //                            ret[str] += 1 * koefs[k];
        //                        str = "";
        //                    }
        //                    //k++;
        //                }
        //            }
        //        }
        //    }
        //}

        //if (str != "")
        //{
        //    if (!ret.ContainsKey(str))
        //        ret.Add(str, 1 * koefs[k]);
        //    else
        //        ret[str] += 1 * koefs[k];
        //}
        #endregion wrong solution
        //formula = "(C6H6)Fe(CO)2";
        //formula = "K4[ON(SO3)2]2";
        //formula = "((LiUtnUuoClU)3Fe(ClFUupN)3)12";
        //formula = "As2{Be4C5[BCo3(CO2)3]2}4Cu5"; //Be-16 O-48 //C-44 O-48
        //formula = "{((C6H6)Fe(CO)2C)}";
        int k = 1;
        var ret = new Dictionary<string, int>();
        int koefLevel = 0;
        string seps = "";
        int lengthL = 0, lengthD = 0, lengthK = 0;
        for (int i = 0; i < formula.Length; i++)
        {
            if (sepStart.Contains(formula[i]))
            {
                seps += formula[i];
                koefLevel++;
                continue;
            }
            if (sepEnd.Contains(formula[i]))
            {
                seps += $"{formula[i]}{getDigit(formula.Substring(i + 1), out lengthD)}";
                //koefs.Add(getDigit(formula.Substring(i + 1), out lengthD));
                koefLevel--;
                continue;
            }

            string tempKey = getLetter(formula.Substring(i), out lengthL);
            if (tempKey != "")
            {
                k = 1;
                //lengthK = 0;
                int shift = 0;
                for (int j = 0; j < koefLevel; j++)
                {
                    k *= findKoef(formula.Substring(i + lengthL + shift), out lengthK);
                    shift += lengthK;
                }

                int tempValue = getDigit(formula.Substring(i + lengthL), out lengthD);
                if (!ret.ContainsKey(tempKey))
                    ret.Add(tempKey, tempValue * k);
                else
                    ret[tempKey] += tempValue * k;
                //ret.Add(, );
                i += lengthL + lengthD - 1;
            }
        }

        return ret;
    }

    /// <summary>
    /// получает начальный элемент из стркои (первый заглавный и все последующие строчные)
    /// </summary>
    /// <param name="s">строка начиная с заглавного символа</param>
    /// <param name="l">количество полученных символов</param>
    /// <returns>начальный элемент</returns>
    private static string getLetter(string s, out int l)
    {
        l = 1;
        if (s.Length > 0 && !char.IsLetter(s[0]))
            return "";
        string ret = s.Substring(0, 1);
        for (int i = 1; i < s.Length; i++)
        {
            if (char.IsLower(s[i]))
            {
                ret += s[i];
                l++;
            }
            else
                break;
        }
        return ret;
    }

    /// /// <summary>
    /// получает первое число из строки
    /// </summary>
    /// <param name="s">строка после символа</param>
    /// <param name="l">количество полученных символов</param>
    /// <returns>первое число в строке</returns>
    private static int getDigit(string s, out int l)
    {
        l = 0;
        string ret = "";
        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                ret += c;
                l++;
            }
            else
                break;
        }
        return ret == "" ? 1 : int.Parse(ret);
    }

    /// /// <summary>
    /// получает первое число после ближайшей закрывающей скобки )]}
    /// </summary>
    /// <param name="s">строка после символа</param>
    /// <returns>первое число в строке после ближайшей закрывающей скобки )]}</returns>
    private static int findKoef(string s, out int l)
    {
        l = 0;
        int lengthD = 0;
        int ret = 0;
        int nested = 0;
        for (int i = 0; i < s.Length; i++)
        {
            //((LiUtnUuoClU)3Fe(ClFUupN)3)12
            //поиск закрывающей скобки, причем исключая полноценные
            //также есть идея идти в конца помножая
            //")]}"
            //пропуская вложенные
            if (sepStart.Contains(s[i]))
                nested++;

            if (sepEnd.Contains(s[i]) && nested == 0)
            {
                ret = getDigit(s.Substring(i + 1), out lengthD);
                l += lengthD;
                return ret;
            }

            if (sepEnd.Contains(s[i]))
                nested--;
            l++;
        }

        return ret;
    }
}

