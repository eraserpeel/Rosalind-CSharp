using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class PointMutations
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

        int CountPointMutations(string a, string b)
        {
            return a.Zip(b, (x, y) => x == y).Count(z => !z);
        }

        static void Main(string[] args)
        {
            PointMutations pm = new PointMutations();
            string text = pm.LoadFile("../../6-data.txt");
            string [] splitText = text.Split(new string []{Environment.NewLine}, StringSplitOptions.None);
            Console.WriteLine(pm.CountPointMutations(splitText[0], splitText[1]));
            Console.Read();
        }

    }
}
