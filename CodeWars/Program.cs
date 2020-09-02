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
            #region productFib
            //ulong[] temp = productFib(4895); //new ulong[] { 55, 89, 1 };
            //foreach (ulong i in temp)
            //{
            //    Console.Write($"{i} ");
            //}
            #endregion productFib
            #region Order
            //Console.WriteLine(Order("is2 Thi1s T4est 3a")); //"Thi1s is2 3a T4est"
            #endregion Order
            #region QueueTime
            //Console.WriteLine(QueueTime(new int[] { }, 1)); //0
            //Console.WriteLine(QueueTime(new int[] { 1, 2, 3, 4 }, 1)); //10
            //Console.WriteLine(QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2)); //9
            //Console.WriteLine(QueueTime(new int[] { 10, 2, 3, 3 }, 2)); //10
            //Console.WriteLine(QueueTime(new int[] { 1, 2, 3, 4, 5 }, 100)); //5
            //Console.WriteLine(QueueTime(new int[] { 2, 4, 3, 2, 2 }, 3)); //5
            //Console.WriteLine(QueueTime(new int[] { 2, 3, 10 }, 2)); //12
            //Console.WriteLine(QueueTime(new int[] { 2, 2, 3, 10 }, 3)); //12
            //Console.WriteLine(QueueTime(new int[] { 2, 2, 2, 1 }, 3)); //3
            #endregion QueueTime
            #region GetUnique
            //Console.WriteLine(GetUnique(new[] { -2, 2, 2, 2 })); ///0.55
            #endregion GetUnique
            #region Score
            //Console.WriteLine(Score(new int[] { 2, 2, 2, 5, 3 })); //250
            //Console.WriteLine(Score(new int[] { 1, 1, 5, 3, 3 })); //250
            //Console.WriteLine(Score(new int[] { 1, 1, 1, 1, 1 })); //1200
            //Console.WriteLine(Score(new int[] { 2, 3, 4, 6, 2 })); //0
            //Console.WriteLine(Score(new int[] { 4, 4, 4, 3, 3 })); //400
            #endregion Score
            #region GetPeaks
            //GetPeaks(new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 }); // new int[]{3,7}, new int[]{6,3},
            //GetPeaks(new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 }); //
            //GetPeaks(new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 }); //
            //GetPeaks(new int[] { 2, 1, 3, 1, 2, 2, 2, 2, 1 }); //
            //GetPeaks(new int[] { 2, 1, 3, 1, 2, 2, 2, 2 }); //
            #endregion GetPeaks
            #endregion old task
            #region ParseMolecule
            //((UunUun(Si(AlHeArUtn)9(LiUtnUuoClU)3Fe(ClFUupN)3)4)12Utn(((FeUuuKUuoArU)3O(FArUubUuuMg)2(UUbnArUuuFeUqn)11C)7ArUtn)8)11((UO(Uqn(CCaUuu)13CaU(FFBeKUunU)11B(UuuHClLiUuu)12)8(UCaSiPO)8)8(Be((UbnUuuUun)10(UbnOAr)13B(UuuSiUup)2BUun)2((BBNeClPNe)11FCl(HNeFe)2)3(UuuUbnUP(PBClUup)3)9)12B)4Ca(PN(((NMgUuoHe)9NaUbn(FeKOSUtnKAl)7F(UbnPNCa)2)5(Si(BeArKUuuUuo)5Ca(NaFCl)4(ArOHB)3BO)9((CUupUubMg)8(UbnUupK)9(SiBeFeClU)6Uub)5((SiUqnH)13He(HeUtnUupNaHUun)8)8Ca(UbnF(PHBe)2UqnNa)10He)3(Cl(P(UubSiUtnArH)4(UFeUuuCBe)6(UUubUqnSi)7)5OUup((LiCLi)8U(UNeUuoO)10)11)4(((UbnLiLiHeUbn)12(NLiArUuo)2CaCl(UuoAlLiUuuFK)8)5(Ubn(CaUqnClUuoAl)4(MgUunPMgSBC)9H(UubHCOLiUubUup)11UuoO)3((OUupUqnUtnN)13(FeUupCaFeUunCU)11UuoU)10)6K(SUup(Uun(FeBUunAlCl)9(CUunFSi)2(BeUubUbn)7(ArArH)13P(UuuSiUtnCaFeB)7)4K((OHeLiMgNe)12Utn(UubBUup)11Si(AlAlArClUuo)11(LiSiUuuOC)4Ne)11U)5)5
            Kata.ParseMolecule("Cp2Fe2(CO)4"); //[CpFe(CO)2]2 //(C6H6)Fe(CO)2
            Kata.ParseMolecule("Na(MgNAl)9NaKHeUbnMg");
            // Expected: equivalent to < ["Na", 2], ["Mg", 10], ["N", 9], ["Al", 9], ["K", 1], ["He", 1], ["Ubn", 1] >
            // But was:  < ["Na", 10], ["Mg", 18], ["N", 9], ["Al", 9], ["K", 9], ["He", 9], ["Ubn", 9] >
            // Missing(5) : < ["Na", 2], ["Mg", 10], ["K", 1], 
            Kata.ParseMolecule("C6H12O6"); //C6H12O6
            Kata.ParseMolecule("C2H5OH");
            Kata.ParseMolecule("(H2O)");
            Kata.ParseMolecule("H2O");
            Kata.ParseMolecule("Mg(OH)2");
            Kata.ParseMolecule("K4[ON(SO3)2]2");
            #endregion ParseMolecule
            Console.ReadLine();
        }
    }
}
