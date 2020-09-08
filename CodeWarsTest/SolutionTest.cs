using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class SolutionTest
{
    [Test]
    public void SampleTests()
    {
        Assert.AreEqual(new List<string> { "e", "d", "a" }, TopWords.Top3("a a a  b  c c  d d d d  e e e e e"));
        Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, TopWords.Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
        Assert.AreEqual(new List<string> { "won't", "wont" }, TopWords.Top3("  //wont won't won't "));
        Assert.AreEqual(new List<string> { "e" }, TopWords.Top3("  , e   .. "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  ...  "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  '  "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  '''  "));
        Assert.AreEqual(new List<string> { "a", "of", "on" }, TopWords.Top3(
            string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                "mind, there lived not long since one of those gentlemen that keep a lance",
                "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                "coursing. An olla of rather more beef than mutton, a salad on most",
                "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                "on Sundays, made away with three-quarters of his income." })));
    }

    [TestCase(new[] { 1, 2, 2, 2 }, ExpectedResult = 1)]
    [TestCase(new[] { -2, 2, 2, 2 }, ExpectedResult = -2)]
    [TestCase(new[] { 11, 11, 14, 11, 11 }, ExpectedResult = 14)]
    public int BaseTest(IEnumerable<int> numbers)
    {
        return Kata.GetUnique(numbers);
    }

    /// <summary>
    /// 4 kyu Text align justify
    /// </summary>
    [Test]
    public void JustifyTest()
    {
        Assert.AreEqual("123  45\n6", Kata.Justify("123 45 6", 7));
        //Assert.AreEqual("Lorem  ipsum  dolor  sit amet,\nconsectetur  adipiscing  elit.\nVestibulum    sagittis   dolor\nmauris,  at  elementum  ligula\ntempor  eget.  In quis rhoncus\nnunc,  at  aliquet orci. Fusce\nat   dolor   sit   amet  felis\nsuscipit   tristique.   Nam  a\nimperdiet   tellus.  Nulla  eu\nvestibulum    urna.    Vivamus\ntincidunt  suscipit  enim, nec\nultrices   nisi  volutpat  ac.\nMaecenas   sit   amet  lacinia\narcu,  non dictum justo. Donec\nsed  quam  vel  risus faucibus\neuismod.  Suspendisse  rhoncus\nrhoncus  felis  at  fermentum.\nDonec lorem magna, ultricies a\nnunc    sit    amet,   blandit\nfringilla  nunc. In vestibulum\nvelit    ac    felis   rhoncus\npellentesque. Mauris at tellus\nenim.  Aliquam eleifend tempus\ndapibus. Pellentesque commodo,\nnisi    sit   amet   hendrerit\nfringilla,   ante  odio  porta\nlacus,   ut   elementum  justo\nnulla et dolor.", Kata.Justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sagittis dolor mauris, at elementum ligula tempor eget. In quis rhoncus nunc, at aliquet orci. Fusce at dolor sit amet felis suscipit tristique. Nam a imperdiet tellus. Nulla eu vestibulum urna. Vivamus tincidunt suscipit enim, nec ultrices nisi volutpat ac. Maecenas sit amet lacinia arcu, non dictum justo. Donec sed quam vel risus faucibus euismod. Suspendisse rhoncus rhoncus felis at fermentum. Donec lorem magna, ultricies a nunc sit amet, blandit fringilla nunc. In vestibulum velit ac felis rhoncus pellentesque. Mauris at tellus enim. Aliquam eleifend tempus dapibus. Pellentesque commodo, nisi sit amet hendrerit fringilla, ante odio porta lacus, ut elementum justo nulla et dolor.", 30));
        //нулевая последовательность
        //Assert.AreEqual("", Kata.Justify("", 5));
        //Assert.AreEqual("", Kata.Justify("", 0));
        //слова равны длине
        //Assert.AreEqual("12345\n54321\n6 95", Kata.Justify("12345 54321 6 95", 5));
        //слова чуть меньше длины
        //Assert.AreEqual("1234\n5432\n6 95", Kata.Justify("1234 5432 6 95", 5));
        //строка null
        //Assert.AreEqual("", Kata.Justify(null, 5));
        //добавляется по 2 пробела везде
        //Assert.AreEqual("123  45  6\n95", Kata.Justify("123 45 6 95", 10));
        //добавляется один двойной и несколько одинарных пробелов
        //добавляется несколько двойных и один иднарный пробел
        //добавляется несколько двойных и несколько одинарных пробелов
    }
}