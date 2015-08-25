using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Rosalind_Challenges
{
    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
    }
    
    class MortalFibonacciRabbits
    {
       
        public BigInteger Breed(int duration, int lifespan)
        {
            BigInteger[] ageCounts = new BigInteger[lifespan];
            ageCounts[0] = 1;
            for(int i = 1; i < duration; i++)
            {
                BigInteger[] temp = new BigInteger[lifespan];
                
                for (int j = 1; j < ageCounts.Count(); j++)
                    temp[0] += ageCounts[j];

                for(int j = 0; j < ageCounts.Count() - 1; j++)
                    temp[j + 1] = ageCounts[j];
                ageCounts = temp;
            }

            BigInteger a = 0;
            for (int j = 0; j < ageCounts.Count(); j++)
                a += ageCounts[j];

            return a;
        }

        static void Main(string[] args)
        {
            MortalFibonacciRabbits cap = new MortalFibonacciRabbits();
            Console.WriteLine(cap.Breed(87, 17));
            Console.Read();
        }
    }
}