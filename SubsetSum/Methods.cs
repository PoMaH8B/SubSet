using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    static class Methods
    {
        public static List<int> GenerateRandomList(int n, int min, int max)
        {
            Random rd = new Random();
            List<int> res = new List<int>();
            for(int i = 0; i < n; ++i)
            {
                res.Add(rd.Next(min, max + 1));
            }
            return res;
        }

        public static List<int> GreedySubsetSum(List<int> list, int sum, out int currSum)
        {
            var result = new List<int>();
            currSum = 0;
            foreach (int i in list.OrderByDescending(k => k).SkipWhile(k => k > sum))
            {
                currSum += i;
                if (currSum > sum)
                    return result;
                else
                    result.Add(i);
            }
            return result;
        }

        public static List<int> BrutSubsetSum(List<int> list, int sum)
        {
            try
            {
                return FindAllSubsets(list).First(set => set.Sum() == sum);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        private static IEnumerable<List<int>> FindAllSubsets(List<int> itemset)
        {
            long subsetCount = 1L << itemset.Count();
            if(subsetCount == 1)
            {
                throw new ArgumentException("Invalid itemset count");
            }
            for (int i = 0; i < subsetCount; i++)
            {
                List<int> subset = new List<int>();
                for (int bitIndex = 0; bitIndex < itemset.Count(); bitIndex++)
                {
                    if ((i & (1 << (itemset.Count - bitIndex - 1))) != 0)
                    {
                        subset.Add(itemset[bitIndex]);
                    }
                }
                yield return subset;
            }
        }
    }
}
