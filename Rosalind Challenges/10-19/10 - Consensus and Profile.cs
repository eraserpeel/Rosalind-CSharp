using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class ConsensusAndProfile
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

        List<string> ParseFasta(string data)
        {
            List<string> parsed = new List<string>();
            string[] dataSplit = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string currentStr = "";
            foreach (string line in dataSplit)
            {
                if (!line[0].Equals('>'))
                    currentStr = currentStr + line.TrimEnd(Environment.NewLine.ToCharArray());
                else if (!currentStr.Equals(""))
                {
                    parsed.Add(currentStr);
                    currentStr = "";
                }
            }
            parsed.Add(currentStr);
            return parsed;
        }

        Dictionary<char, int[]> Profile(string data)
        {

            List<string> parsed = ParseFasta(data);
            int lengthOfDNA = parsed[0].Length;
            
            Dictionary<char, int[]> profiled = new Dictionary<char, int[]>();
            profiled['A'] = new int[lengthOfDNA];
            profiled['C'] = new int[lengthOfDNA];
            profiled['G'] = new int[lengthOfDNA];
            profiled['T'] = new int[lengthOfDNA];

            for (int i = 0; i < parsed.Count; i++)
            {
                for (int j = 0; j < lengthOfDNA; j++)
                {
                    char currentChar = parsed[i][j];
                    profiled[currentChar][j]++;
                }
                Console.WriteLine();
            }
            return profiled;

        }

        string FindMaxAmino(Dictionary<char, int[]> data)
        {
            string maxAminos = "";
            char[] aminos = { 'A', 'C', 'G', 'T' };

            for (int i = 0; i < data['A'].Length; i++)
            {
                int max = 0;
                char maxChar = 'A';

                for (int j = 0; j < aminos.Length; j++)
                {
                    if (data[aminos[j]][i] > max)
                    {
                        maxChar = aminos[j];
                        max = data[aminos[j]][i];
                    }

                }

                maxAminos = maxAminos + maxChar;
            }
            return maxAminos;
        }

        static void Main(string[] args)
        {
            ConsensusAndProfile cap = new ConsensusAndProfile();
            Dictionary<char, int[]> capData = cap.Profile(cap.LoadFile("../../10-data.txt"));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("../../10-data-output.txt"))
            {
                file.WriteLine(cap.FindMaxAmino(capData));

                foreach (KeyValuePair<char, int[]> entry in capData)
                {
                    file.Write(entry.Key + ": ");
                    Array.ForEach(entry.Value, x => file.Write(x + " "));
                    file.WriteLine();
                }
            }
            
            Console.Read();
        }
    }
}