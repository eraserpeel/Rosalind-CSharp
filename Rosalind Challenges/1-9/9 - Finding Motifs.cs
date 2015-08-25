using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class FindingMotifs
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

        IEnumerable<int> FindSubstring(string primary, string sub)
        {
            int [] finds = {};
            if (primary.Length < sub.Length)
                return finds;
            return Regex.Matches(primary, @"(?="+sub+")").Cast<Match>().Select(m => m.Index + 1);
                        
        }

        static void Main(string[] args)
        {
            FindingMotifs fm = new FindingMotifs();
            string [] strands = fm.LoadFile("../../9-data.txt").Split(new string [] {Environment.NewLine}, StringSplitOptions.None);
            foreach(int found in fm.FindSubstring(strands[0], strands[1]))
                Console.Write(found + " ");
            Console.Read();
        }
    }
}

