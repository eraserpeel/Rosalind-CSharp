using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class RecurrencRelation
    {
        long CalculatePopulation(long f1, long f2, long generations, long generationSize)
        {
            if (generations <= 2)
                return f2;
            return CalculatePopulation(f2, f2 + f1 * generationSize, generations - 1, generationSize);
        }

        static void Main(string[] args)
        {
            RecurrencRelation r = new RecurrencRelation();
            Console.WriteLine(r.CalculatePopulation(1, 1, 30, 3));
            Console.Read();
        }
    }
}
