using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsTest
{
    public class PickPeaks
    {
        /// <summary>
        /// 5 kyu Pick peaks
        /// In this kata, you will write a function that returns the positions and the values of the "peaks" (or local maxima) of a numeric array.
        /// For example, the array arr = [0, 1, 2, 5, 1, 0] has a peak at position 3 with a value of 5 (since arr[3] equals 5).
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            int pos = 0, peak = 0;
            List<int> posL = new List<int>(), peaksL = new List<int>();
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    pos = i;
                    peak = arr[i];

                }
                else
                {
                    if (arr[i - 1] <= arr[i] || pos <= 0) continue;
                    posL.Add(pos);
                    peaksL.Add(peak);
                    pos = 0;
                    peak = 0;
                }
            }

            var ret = new Dictionary<string, List<int>>()
            {
                ["pos"] = posL,
                ["peaks"] = peaksL
            };

            return ret;
        }
    }
}
