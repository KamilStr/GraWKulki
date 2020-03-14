using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraWKulki
{
    public partial class Form2 : Form
    {
        int iter;
        string[] wyniki9;
        string[] wyniki7;
        string[] wyniki5;

        public Form2()
        {
            InitializeComponent();
            if (!File.Exists("wyniki.txt"))
            {
                StreamWriter wr = new StreamWriter("wyniki.txt");
                wr.WriteLine("");
                wr.WriteLine("");
                wr.WriteLine("");
                wr.Close();
            }
            StreamReader reader = new StreamReader("wyniki.txt");
            wyniki9 = reader.ReadLine().Split(new char[] { '#' });
            wyniki7 = reader.ReadLine().Split(new char[] { '#' });
            wyniki5 = reader.ReadLine().Split(new char[] { '#' });
            reader.Close();
            Wypisz(wyniki9);
        }

        private void Wypisz(string[] wyniki)
        {
            iter = 1;
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            foreach (string x in wyniki)
            {
                if (iter++ % 2 == 1)
                {
                    label4.Text += (iter / 2).ToString() + '\n';
                    label5.Text += x + '\n';
                }
                else
                    label6.Text += x + '\n';
            }
            label4.Refresh();
            label5.Refresh();
            label6.Refresh();
        }

        private void kolorowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wypisz(wyniki9);
        }

        private void kolorowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Wypisz(wyniki7);
        }

        private void kolorowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Wypisz(wyniki5);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
