using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class MendelsFirstLaw
    {

        double CalculateProbability(double k, double m, double n)
        {
            double numCreatures = k + m + n;
            double probOfDominant = 0;

            if (k > 1)
                probOfDominant = probOfDominant + (k / numCreatures);
            
            if (m > 1)
                probOfDominant = probOfDominant + ((0.75) * ((m / numCreatures) * ((m - 1) / (numCreatures - 1))));
            
            probOfDominant = probOfDominant + ((m / numCreatures) * ((k) / (numCreatures - 1)));
            probOfDominant = probOfDominant + ((0.50) * ((m / numCreatures) * ((n) / (numCreatures - 1))));
            probOfDominant = probOfDominant + ((0.50) * ((n / numCreatures) * ((m) / (numCreatures - 1))));
            probOfDominant = probOfDominant + ((n / numCreatures) * ((k) / (numCreatures - 1)));
            
            return probOfDominant;
        }

        static void Main(string[] args)
        {
            MendelsFirstLaw mf = new MendelsFirstLaw();
            Console.WriteLine(mf.CalculateProbability(15, 23, 26));
            Console.Read();
        }

    }
}
