using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class TopWords
{
    /// <summary>
    /// 4 kyu Most frequently used words in a text
    /// Write a function that, given a string of text (possibly with punctuation and line-breaks), returns an array of the top-3 most
    /// occurring words, in descending order of the number of occurrences.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static List<string> Top3(string s)
    {
        List<string> ret = new List<string>();
        string str = "";
        int i = 0;
        foreach (char c in s.ToLower())
        {
            if (char.IsLetter(c) || c.Equals('\''))
                str += c;
            else
            {
                if (str.Replace("\'", "") != "")
                {
                    ret.Add(str);
                    str = "";
                }
            }
        }
        if (str.Replace("\'", "") != "")
            ret.Add(str);
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (string s1 in ret)
        {
            if (!dict.ContainsKey(s1))
                dict.Add(s1, 1);
            else
                dict[s1] += 1;
        }
        ret = new List<string>();
        foreach (KeyValuePair<string, int> keyValuePair in dict.OrderByDescending(pair => pair.Value))
        {
            ret.Add(keyValuePair.Key);
            i++;
            if (i == 3) break;
        }
        return ret;
    }
}