using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class TranscribingRNA
    {
        string LoadFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        string Transcribe(string text)
        {
            return text.Replace('T', 'U');
        }

        static void Main(string[] args)
        {
            TranscribingRNA c = new TranscribingRNA();
            Console.WriteLine(c.Transcribe(c.LoadFile("../../2-data.txt")));
            Console.Read();
        }
    }
}
