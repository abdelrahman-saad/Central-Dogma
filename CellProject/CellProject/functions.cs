using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    class functions
    {
        public static Dictionary<char, List<string>> proteinTable = new Dictionary<char, List<string>>();
        public static void call()
        {
            char cha;
            string temp;
            var list = new List<string>();
            string path = @"C:\Users\AMR HANY\Desktop\CellProject\Codes.txt";
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    cha = Convert.ToChar(line); ;
                    line = streamReader.ReadLine();
                    temp = line;
                    while (temp.Length != 0)
                    {
                        var token = temp.Substring(0, 3);
                        list.Add(token);
                        temp = temp.Remove(0, 3);
                    }
                    proteinTable.Add(cha, new List<string>(list));
                    if (line == null)
                        break;
                    list = new List<string>();
                }
            }
        }
        public static string from3_5_To_5_3(string temp)
        {
            StringBuilder transp = new StringBuilder();
            StringBuilder trash = new StringBuilder();
            foreach (char cha in temp)
            {
                if (cha == 'T' || cha == 't')
                    transp.Append('A');

                else if (cha == 'A' || cha == 'a')
                    transp.Append('T');

                else if (cha == 'C' || cha == 'c')
                    transp.Append('G');

                else if (cha == 'G' || cha == 'g')
                    transp.Append('C');
                else
                    trash.Append(cha);
            }
            return transp.ToString();
        }
        public static string to_mRNA(string temp)
        {
            string mRNA;
            StringBuilder transp = new StringBuilder();
            StringBuilder trash = new StringBuilder();
            foreach (char cha in temp)
            {
                if (cha == 'T' || cha == 't')
                    transp.Append('U');

                else if (cha == 'A' || cha == 'a')
                    transp.Append('A');

                else if (cha == 'C' || cha == 'c')
                    transp.Append('C');

                else if (cha == 'G' || cha == 'g')
                    transp.Append('G');
            }
            return transp.ToString();
        }
        public static Queue<string> codons_displayer(string temp)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                try
                {
                    string token = temp.Substring(0, 3);
                    queue.Enqueue(token);
                    temp = temp.Remove(0, 3);
                }
                catch (Exception token)
                {
                    break;
                }
            }

            return queue;
        }
        public static Queue<StringBuilder> proteinDisplayer(Dictionary<char, List<string>> proteinTable,
            Queue<string> codons_queue)
        {
            Queue<StringBuilder> proteinCodes = new Queue<StringBuilder>();

            if (codons_queue.Contains("AUG"))
            {
                while(codons_queue.Count != 0)
                {
                    if (codons_queue.First() == "AUG")
                    {
                        var limit = codons_queue.Count;
                        for (var i = 0; i <= limit; i++)
                        {
                            foreach (var pair in proteinTable)
                            {
                                if (pair.Value.Contains(codons_queue.First()))
                                {
                                    StringBuilder x = new StringBuilder();
                                    x.Append(pair.Key);
                                    proteinCodes.Enqueue(x);
                                    if (pair.Key == '*')
                                        return proteinCodes;
                                    codons_queue.Dequeue();
                                }

                                if (codons_queue.Count == 0)
                                    return proteinCodes;
                            }
                        }
                    }

                    else
                    {
                        codons_queue.Dequeue();
                        continue;
                    }
                }
            }
            else
            {
                return proteinCodes;
            }
            return proteinCodes;

        }
    }
}