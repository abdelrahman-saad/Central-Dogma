using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private int counter;
        private void button2_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter ==1)
                functions.call();

            textBox2.Text = functions.from3_5_To_5_3(textBox1.Text);
            // textBox2.Show();
            textBox3.Text = functions.to_mRNA(textBox2.Text);
            var data = functions.codons_displayer(textBox3.Text);
            string n = "";
            foreach (var item in data)
            {
                n += item + " ";
            }

            textBox5.Text = n;
            var p = functions.proteinDisplayer(functions.proteinTable, data);
            string x = "";
            
            foreach (var item in p)
            {
                x += item + " ";
            }
          
            if (p.Count == 0 )
            {
                textBox4.Text = "NO Protein Found -_-";
                 MessageBox.Show("Cannot translate protein", "Translation Error");
            }
            else if (!(x.Contains("*")))
            {
                textBox4.Text = x;
                MessageBox.Show("Cannot translate protein no stop Codon", "Translation Error");
            }
            else if ((x.Contains('*')) )
            {
                textBox4.Text = x;
                MessageBox.Show("DONE !", "Translation Done");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
