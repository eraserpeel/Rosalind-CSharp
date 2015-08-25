using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class ComputingGC
    {
        string LoadFile(string filename)
        {
            try
            {
                return System.IO.File.ReadAllText(filename);
            }
            catch (FileNotFoundException ex)
            {
                return ex.ToString();
            }
        }

        Dictionary<string, float> ParseGCFile(string filename)
        {
            /* Overly complicated way of doing it, but could be more 
             * useful in the long run. 
             */

            Dictionary<string, float> dict = new Dictionary<string, float>();
            string text = LoadFile(filename);
            text = text.Replace(Environment.NewLine, "");
            foreach (Match m in Regex.Matches(text, @">([A-Za-z_0-9]*)"))
            {
                string key = m.ToString().Substring(1, 13);
                string dna = m.ToString().Substring(14);
                float gcPercent = ((float)dna.Count(str => str == 'C' || str == 'G') / dna.Length) * 100;
                dict.Add(key, gcPercent);
            }
            return dict;

        }
        
        
        static void Main(string[] args)
        {
            ComputingGC cgc = new ComputingGC();
            Dictionary<string, float> parsedGC = cgc.ParseGCFile("../../5-data.txt");
            foreach(KeyValuePair<string, float> entry in parsedGC)
            {
                Console.WriteLine(entry.Key + "\n" + entry.Value);
            }

            Console.WriteLine(parsedGC.FirstOrDefault(x => x.Value == parsedGC.Values.Max()).Key);
            Console.WriteLine(parsedGC.Values.Max());
            
            Console.Read();
        }

    }
}
