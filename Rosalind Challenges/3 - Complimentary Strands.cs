using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class Complimentary
    {
        String LoadFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        /// <summary>
        /// I feel like this method can be simplified in some form, perhaps using
        /// linq or a more complex replace method. Otherwise it works just fine.
        /// </summary>
        /// <param name="dnaSequence"></param>
        /// <returns></returns>
        String ReverseCompliment(string dnaSequence)
        {
            char[] tempSequence = dnaSequence.ToCharArray();
            Array.Reverse(tempSequence);
            for(int i = 0; i < tempSequence.Length; i++) 
            {
                switch (tempSequence[i])
                {
                    case 'A':
                        tempSequence[i] = 'T';
                        break;
                    case 'T':
                        tempSequence[i] = 'A';
                        break;
                    case 'C':
                        tempSequence[i] = 'G';
                        break;
                    case 'G':
                        tempSequence[i] = 'C';
                        break;
                }                
            }
                
            return new string(tempSequence);
        }

        static void Main(string[] args)
        {
            Complimentary c = new Complimentary();
            Console.WriteLine(c.ReverseCompliment(c.LoadFile("../../3-data.txt")));
            Console.Read();
        }
    }
}
