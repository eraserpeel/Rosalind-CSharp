using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind_Challenges
{
    class TranslatingRNA
    {
        Dictionary<string, string> codonLookup;

        public TranslatingRNA() 
        {
            codonLookup = new Dictionary<string,string>();
            LoadLookupTable();
        }

        void LoadLookupTable()
        {
            string text = LoadFile("../../codon_table.txt");
            string [] splitText = text.Replace(Environment.NewLine, " ").Split(' ');
            splitText = splitText.Where(c => c.Length > 0).ToArray();
            for (int i = 0; i < splitText.Length - 1; i = i + 2)
                codonLookup.Add(splitText[i], splitText[i + 1]);
            
        }

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

        string Translate(string rna)
        {
            string translation = "";
            for (int i = 0; i < rna.Length; i = i + 3)
                translation = translation + codonLookup[rna.Substring(i, 3)];

            return translation;
        }

        static void Main(string[] args)
        {
            TranslatingRNA tr = new TranslatingRNA();
            Console.WriteLine(tr.Translate(tr.LoadFile("../../8-data.txt")));
            Console.Read();
        }
    }
}
