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
    public partial class Form3 : Form
    {
        int pkt;
        int poz;
        int mie;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(int wynik, int poziom, int miejsce)
        {
            InitializeComponent();
            label2.Text = "Zdobywasz " + miejsce + " miejsce z " + wynik + " punktami\nw rozgrywce przy " + poziom + " kolorach!";
            pkt = wynik;
            poz = poziom;
            mie = miejsce;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("wyniki.txt"))
            {
                StreamWriter writer = new StreamWriter("wyniki.txt");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.Close();
            }
            StreamReader reader = new StreamReader("wyniki.txt");
            string linia1;
            string linia2;
            string linia3;            
            linia1 = reader.ReadLine(); 
            linia2 = reader.ReadLine();
            linia3 = reader.ReadLine();
            reader.Close();

            if (poz == 9)
            {
                var split = linia1.Split(new char[] { '#' });
                int elem = split.Count();
                if (elem == 1)
                {
                    linia1 += "#";
                    split = linia1.Split(new char[] { '#' });
                }
                else if (elem < 20)
                {
                    linia1 += "##";
                    split = linia1.Split(new char[] { '#' });
                }
                elem = split.Count();
                for (int i = elem - 1; i >= mie * 2; i--)
                    split[i] = split[i - 2];
                split[mie * 2 - 2] = textBox1.Text;
                split[mie * 2 - 1] = pkt.ToString();
                linia1 = string.Join("#", split);
            }
            if (poz == 7)
            {
                var split = linia2.Split(new char[] { '#' });
                int elem = split.Count();
                if (elem == 1)
                {
                    linia2 += "#";
                    split = linia2.Split(new char[] { '#' });
                }
                else if (elem < 20)
                {
                    linia2 += "##";
                    split = linia2.Split(new char[] { '#' });
                }
                elem = split.Count();
                for (int i = elem - 1; i >= mie * 2; i--)
                    split[i] = split[i - 2];
                split[mie * 2 - 2] = textBox1.Text;
                split[mie * 2 - 1] = pkt.ToString();
                linia2 = string.Join("#", split);
                
            }
            if (poz == 5)
            {
                var split = linia3.Split(new char[] { '#' });
                int elem = split.Count();
                if (elem == 1)
                {
                    linia3 += "#";
                    split = linia2.Split(new char[] { '#' });
                }
                else if (elem < 20)
                {
                    linia3 += "##";
                    split = linia3.Split(new char[] { '#' });
                }
                elem = split.Count();
                for (int i = elem - 1; i >= mie * 2; i--)
                    split[i] = split[i - 2];
                split[mie * 2 - 2] = textBox1.Text;
                split[mie * 2 - 1] = pkt.ToString();
                linia3 = string.Join("#", split);
            }
            StreamWriter wr = new StreamWriter("wyniki.txt");
            wr.WriteLine(linia1);
            wr.WriteLine(linia2);
            wr.WriteLine(linia3);
            wr.Close();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
        }

    }
}
