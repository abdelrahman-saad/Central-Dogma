using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ConsoleApp2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
             

            //var choice = functions.display();
            //if (choice == 1)
            //{
            //    var num = functions._DNAMenu();
            //    string mRNA = functions.switch_and_transp(num);
            //    Queue<string> codons = functions.codons_displayer(mRNA);
            //    var proteinCodons = new Queue<string>(codons);
            //  //var p_codes = functions.proteinDisplayer(proteinTable, proteinCodons);
            //    Console.WriteLine("Codons are : ");
            //    while (codons.Count()!=0)
            //    {
            //        Console.WriteLine(codons.First()+ " ");

            //        codons.Dequeue();
            //    }


            //    var p_codes = functions.proteinDisplayer(proteinTable, proteinCodons);
            //    Console.WriteLine("Protein Sequence is : ");
            //    while (p_codes.Count()!=0)
            //    {
            //        Console.WriteLine(p_codes.First() + " ");

            //        p_codes.Dequeue();
            //    }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }           
        }
      
    }


//queue<std::string> proteinDisplayer(std::map<char, std::vector<std::string>> proteinTable, std::queue<std::string> codons_queue);
