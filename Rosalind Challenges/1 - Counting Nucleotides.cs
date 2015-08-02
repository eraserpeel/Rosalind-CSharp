using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class CountingNucleotides
    {
        string LoadFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        string CountTerms(string textToSearch, string[] listOfLetters) {
            int [] termCount = new int[listOfLetters.Length];
            foreach(char term in textToSearch) {
                int termIndex = Array.FindIndex(listOfLetters, x => x.Equals(term.ToString()));
                if(termIndex >= 0)
                    termCount[termIndex]++; 
            }
            string counts = "";
            foreach (int i in termCount)
                counts += " " + i.ToString();
            return counts;
        }

        static void Main(string[] args)
        {
            CountingNucleotides c = new CountingNucleotides();
            string[] temp = { "A", "C", "G", "T" };
            Console.WriteLine(c.CountTerms(c.LoadFile("../../1-data.txt"), temp));
            Console.Read();
        }
    }
}
