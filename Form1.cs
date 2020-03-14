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
    public partial class Form1 : Form
    {
        int wybrane_pole = 0;
        int[,] plansza = new int[9, 9];
        int poziom_trudnosci = 9; // poziom trudnosci = liczba kolorow
        int punkty = 0;
        int[] kolejny_kolor = new int[3];
        int[,] tab = new int[9, 9]; // tablica do szukania drogi kulki

        public Form1()
        {            
            InitializeComponent();
            NowaGra();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private Label pole(int row, int col)
        {
            int nr = 1 + row * 9 + col;
            switch (nr)
            {
                case 1: return label1;
                case 2: return label2;
                case 3: return label3;
                case 4: return label4;
                case 5: return label5;
                case 6: return label6;
                case 7: return label7;
                case 8: return label8;
                case 9: return label9;
                case 10: return label10;
                case 11: return label11;
                case 12: return label12;
                case 13: return label13;
                case 14: return label14;
                case 15: return label15;
                case 16: return label16;
                case 17: return label17;
                case 18: return label18;
                case 19: return label19;
                case 20: return label20;
                case 21: return label21;
                case 22: return label22;
                case 23: return label23;
                case 24: return label24;
                case 25: return label25;
                case 26: return label26;
                case 27: return label27;
                case 28: return label28;
                case 29: return label29;
                case 30: return label30;
                case 31: return label31;
                case 32: return label32;
                case 33: return label33;
                case 34: return label34;
                case 35: return label35;
                case 36: return label36;
                case 37: return label37;
                case 38: return label38;
                case 39: return label39;
                case 40: return label40;
                case 41: return label41;
                case 42: return label42;
                case 43: return label43;
                case 44: return label44;
                case 45: return label45;
                case 46: return label46;
                case 47: return label47;
                case 48: return label48;
                case 49: return label49;
                case 50: return label50;
                case 51: return label51;
                case 52: return label52;
                case 53: return label53;
                case 54: return label54;
                case 55: return label55;
                case 56: return label56;
                case 57: return label57;
                case 58: return label58;
                case 59: return label59;
                case 60: return label60;
                case 61: return label61;
                case 62: return label62;
                case 63: return label63;
                case 64: return label64;
                case 65: return label65;
                case 66: return label66;
                case 67: return label67;
                case 68: return label68;
                case 69: return label69;
                case 70: return label70;
                case 71: return label71;
                case 72: return label72;
                case 73: return label73;
                case 74: return label74;
                case 75: return label75;
                case 76: return label76;
                case 77: return label77;
                case 78: return label78;
                case 79: return label79;
                case 80: return label80;
                case 81: return label81;
                default: return null;
            }
        }

        private void Odswiez()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label zmieniane = pole(i, j);
                    if (plansza[i, j] == 0)
                    {
                        zmieniane.Image = null;
                        continue;
                    }
                    zmieniane.Image = Image.FromFile(plansza[i, j] + ".png");
                    zmieniane.Refresh();
                }
            }
            label83.Text = punkty.ToString();
            label83.Refresh();
        }

        private int Punktowanie(int row, int col)
        {
            int mnoznik = 1;
            int wynik = 1;
            int firstX = row;
            int firstY = col;
            int lastX = row;
            int lastY = col;

            while (true) //------------- Sprawdzanie po rzedzie -----------
            {
                if (lastX + 1 < 9)
                    if (plansza[lastX, lastY] == plansza[lastX + 1, lastY])
                    {
                        lastX++;
                        wynik++;
                        if (wynik > 5)
                            mnoznik++;
                        continue;
                    }
                if (firstX - 1 >= 0)
                    if (plansza[firstX, firstY] == plansza[firstX - 1, firstY])
                    {
                        firstX--;
                        wynik++;
                        if (wynik > 5)
                            mnoznik++;
                        continue;
                    }
                if (wynik >= 5)
                {
                    for (int i = firstX; i <= lastX; i++)
                        plansza[i, firstY] = 0;
                    punkty += wynik * mnoznik;
                    return (wynik * mnoznik);
                }
                break;

            }

            if (wynik < 5)
            {
                wynik = 1;
                firstX = row;
                lastX = row;
                while (true) //------------- Sprawdzanie po kolumnie ----------
                {
                    if (lastY + 1 < 9)
                        if (plansza[lastX, lastY] == plansza[lastX, lastY + 1])
                        {
                            lastY++;
                            wynik++;
                            if (wynik > 5)
                                mnoznik++;
                            continue;
                        }
                    if (firstY - 1 >= 0)
                        if (plansza[firstX, firstY] == plansza[firstX, firstY - 1])
                        {
                            firstY--;
                            wynik++;
                            if (wynik > 5)
                                mnoznik++;
                            continue;
                        }
                    if (wynik >= 5)
                    {
                        for (int i = firstY; i <= lastY; i++)
                            plansza[firstX, i] = 0;
                        punkty += wynik * mnoznik;
                        return (wynik * mnoznik);
                    }
                    break;
                }
            }


            if (wynik < 5) //---------- sprawdzanie kwadratow ------
            {
                if (row + 1 < 9 && col + 1 < 9)
                    if (plansza[row, col] == plansza[row + 1, col]  &&
                        plansza[row, col] == plansza[row, col + 1] &&
                        plansza[row, col] == plansza[row + 1, col + 1])
                    {
                        punkty += 4;
                        plansza[row, col] = 0;
                        plansza[row + 1, col] = 0;
                        plansza[row, col + 1] = 0;
                        plansza[row + 1, col + 1] = 0;
                        return 4;
                    }
                if (row + 1 < 9 && col - 1 >= 0)
                    if (plansza[row, col] == plansza[row + 1, col] &&
                        plansza[row, col] == plansza[row, col - 1] &&
                        plansza[row, col] == plansza[row + 1, col - 1])
                    {
                        punkty += 4;
                        plansza[row, col] = 0;
                        plansza[row + 1, col] = 0;
                        plansza[row, col - 1] = 0;
                        plansza[row + 1, col - 1] = 0;
                        return 4;
                    }
                if (row - 1 >= 0 && col + 1 < 9)
                    if (plansza[row, col] == plansza[row - 1, col] &&
                        plansza[row, col] == plansza[row, col + 1] &&
                        plansza[row, col] == plansza[row - 1, col + 1])
                    {
                        punkty += 4;
                        plansza[row, col] = 0;
                        plansza[row - 1, col] = 0;
                        plansza[row, col + 1] = 0;
                        plansza[row - 1, col + 1] = 0;
                        return 4;
                    }
                if (row - 1 >= 0 && col - 1 >= 0)
                    if (plansza[row, col] == plansza[row - 1, col] &&
                        plansza[row, col] == plansza[row, col - 1] &&
                        plansza[row, col] == plansza[row - 1, col - 1])
                    {
                        punkty += 4;
                        plansza[row, col] = 0;
                        plansza[row - 1, col] = 0;
                        plansza[row, col - 1] = 0;
                        plansza[row - 1, col - 1] = 0;
                        return 4;
                    }
            }
            return 0;
        }

        private bool Koniec() // sprawdzenie konca gry
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++ )
                {
                    if (plansza[i, j] == 0)
                        return false;
                }
            return true;
        }

        private int Miejsce()
        {
            if (!File.Exists("wyniki.txt"))
            {
                StreamWriter wr = new StreamWriter("wyniki.txt");
                wr.WriteLine("");
                wr.WriteLine("");
                wr.WriteLine("");
                wr.Close();
            }
            StreamReader reader = new StreamReader("wyniki.txt");
            if (poziom_trudnosci == 9)
            {
                int iter = 0;
                var wyniki = reader.ReadLine().Split(new char[] { '#' });
                if (wyniki.Count() == 1)
                {
                    reader.Close();
                    return 1;
                }
                if (int.Parse(wyniki[wyniki.Count() - 1]) > punkty && wyniki.Count() < 20)
                {
                    reader.Close();
                    return wyniki.Count() / 2 + 1;
                }
                foreach (string x in wyniki)
                {
                    if (iter++ % 2 == 0) continue;
                    int wynik = int.Parse(x, System.Globalization.CultureInfo.InvariantCulture);
                    if (wynik < punkty)
                    {
                        reader.Close();
                        return iter / 2;
                    }
                }
            }
            else if (poziom_trudnosci == 7)
            {
                int iter = 0;
                reader.ReadLine().Split(new char[] { '#' });
                var wyniki = reader.ReadLine().Split(new char[] { '#' });
                if (wyniki.Count() == 1)
                {
                    reader.Close();
                    return 1;
                }
                if (int.Parse(wyniki[wyniki.Count() - 1]) > punkty && wyniki.Count() < 20)
                {
                    reader.Close();
                    return wyniki.Count() / 2 + 1;
                }
                foreach (string x in wyniki)
                {
                    if (iter++ % 2 == 0) continue;
                    int wynik = int.Parse(x, System.Globalization.CultureInfo.InvariantCulture);
                    if (wynik < punkty)
                    {
                        reader.Close();
                        return iter / 2;
                    }
                }
            }
            else
            {
                int iter = 0;
                reader.ReadLine().Split(new char[] { '#' });
                reader.ReadLine().Split(new char[] { '#' });
                var wyniki = reader.ReadLine().Split(new char[] { '#' });
                if (wyniki.Count() == 1)
                {
                    reader.Close();
                    return 1;
                }
                if (int.Parse(wyniki[wyniki.Count() - 1]) > punkty && wyniki.Count() < 20)
                {
                    reader.Close();
                    return wyniki.Count() / 2 + 1;
                }
                foreach (string x in wyniki)
                {
                    if (iter++ % 2 == 0) continue;
                    int wynik = int.Parse(x, System.Globalization.CultureInfo.InvariantCulture);
                    if (wynik < punkty)
                    {
                        reader.Close();
                        return iter / 2;
                    }
                }
            }
            reader.Close();
            return 0;
        }

        private void DodajLosoweKulki()
        {
            int row;
            int col;
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                if (kolejny_kolor[i] == 0)
                    kolejny_kolor[i] = rand.Next(poziom_trudnosci) + 1;
                do
                {
                    row = rand.Next(9);
                    col = rand.Next(9);
                } while (plansza[row, col] != 0);
                plansza[row, col] = kolejny_kolor[i];
                kolejny_kolor[i] = rand.Next(poziom_trudnosci) + 1;
                if (Koniec())
                {
                    label84.Visible = true;
                    int miejsce = Miejsce();
                    if (miejsce > 0)
                    {
                        Form3 form = new Form3(punkty, poziom_trudnosci, miejsce);
                        form.Show(this);
                    }
                    break;
                }
            }
            label86.Image = Image.FromFile(kolejny_kolor[0] + ".png");
            label87.Image = Image.FromFile(kolejny_kolor[1] + ".png");
            label88.Image = Image.FromFile(kolejny_kolor[2] + ".png");
        }



        private bool Root(int fromX, int fromY, int toX, int toY) // sprawdzanie dojsca do odleglej kratki (sprawdzanie kolejnych drog na bazie drzewa)
        {
            tab[fromX, fromY] = 1;
            int x_new = 0;
            int y_new = 0;
            if (fromX == toX && fromY == toY)
                return true;

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        x_new = fromX; y_new = fromY + 1; break;
                    case 1:
                        x_new = fromX; y_new = fromY - 1; break;
                    case 2:
                        x_new = fromX - 1; y_new = fromY; break;
                    case 3:
                        x_new = fromX + 1; y_new = fromY; break;
                }
                if (x_new < 0 || y_new < 0 || x_new >= 9 || y_new >= 9) continue;
                if (tab[x_new, y_new] != 0) continue;
                

                if (Root(x_new, y_new, toX, toY)) return true;
                tab[x_new, y_new] = -1;
            }
            return false;
        }

        private bool RuchMozliwy(int fromX, int fromY, int toX, int toY)
        {
            tab = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if(plansza[i, j] > 0) tab[i, j] = -1;


            return Root(fromX, fromY, toX, toY);
        }

        private bool Ruch(int fromX, int fromY, int toX, int toY)
        {
            if (RuchMozliwy(fromX, fromY, toX, toY))
            {
                plansza[toX, toY] = plansza[fromX, fromY];
                plansza[fromX, fromY] = 0;

                if (Punktowanie(toX, toY) == 0)
                    DodajLosoweKulki();
                Odswiez();
                return true;
            }
            return false;
        }

        private void OnClick(int row, int col)
        {
            Label label = pole(row, col);
            if (plansza[row, col] == 0 && wybrane_pole == 0) return;
            if (wybrane_pole == 0)
            {
                label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                wybrane_pole = 1 + row * 9 + col;
            }
            else if (wybrane_pole == 1 + row * 9 + col)
            {
                label.BackColor = System.Drawing.SystemColors.Control;
                wybrane_pole = 0;
            }
            else if (plansza[row, col] == 0)
            {
                if (Ruch((wybrane_pole - 1) / 9, ((wybrane_pole - 1) % 9), row, col))
                {
                    label = pole((wybrane_pole - 1) / 9, ((wybrane_pole - 1) % 9));
                    label.BackColor = System.Drawing.SystemColors.Control;
                    wybrane_pole = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(0, 0);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            OnClick(0, 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OnClick(0, 2);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OnClick(0, 3);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OnClick(0, 4);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OnClick(0, 5);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OnClick(0, 6);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OnClick(0, 7);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OnClick(0, 8);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            OnClick(1, 0);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            OnClick(1, 1);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            OnClick(1, 2);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            OnClick(1, 3);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            OnClick(1, 4);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            OnClick(1, 5);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            OnClick(1, 6);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            OnClick(1, 7);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            OnClick(1, 8);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            OnClick(2, 0);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            OnClick(2, 1);
        }

        private void label21_Click(object sender, EventArgs e)
        {
            OnClick(2, 2);
        }

        private void label22_Click(object sender, EventArgs e)
        {
            OnClick(2, 3);
        }

        private void label23_Click(object sender, EventArgs e)
        {
            OnClick(2, 4);
        }

        private void label24_Click(object sender, EventArgs e)
        {
            OnClick(2, 5);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            OnClick(2, 6);
        }

        private void label26_Click(object sender, EventArgs e)
        {
            OnClick(2, 7);
        }

        private void label27_Click(object sender, EventArgs e)
        {
            OnClick(2, 8);
        }

        private void label28_Click(object sender, EventArgs e)
        {
            OnClick(3, 0);
        }

        private void label29_Click(object sender, EventArgs e)
        {
            OnClick(3, 1);
        }

        private void label30_Click(object sender, EventArgs e)
        {
            OnClick(3, 2);
        }

        private void label31_Click(object sender, EventArgs e)
        {
            OnClick(3, 3);
        }

        private void label32_Click(object sender, EventArgs e)
        {
            OnClick(3, 4);
        }

        private void label33_Click(object sender, EventArgs e)
        {
            OnClick(3, 5);
        }

        private void label34_Click(object sender, EventArgs e)
        {
            OnClick(3, 6);
        }

        private void label35_Click(object sender, EventArgs e)
        {
            OnClick(3, 7);
        }

        private void label36_Click(object sender, EventArgs e)
        {
            OnClick(3, 8);
        }

        private void label37_Click(object sender, EventArgs e)
        {
            OnClick(4, 0);
        }

        private void label38_Click(object sender, EventArgs e)
        {
            OnClick(4, 1);
        }

        private void label39_Click(object sender, EventArgs e)
        {
            OnClick(4, 2);
        }

        private void label40_Click(object sender, EventArgs e)
        {
            OnClick(4, 3);
        }

        private void label41_Click(object sender, EventArgs e)
        {
            OnClick(4, 4);
        }

        private void label42_Click(object sender, EventArgs e)
        {
            OnClick(4, 5);
        }

        private void label43_Click(object sender, EventArgs e)
        {
            OnClick(4, 6);
        }

        private void label44_Click(object sender, EventArgs e)
        {
            OnClick(4, 7);
        }

        private void label45_Click(object sender, EventArgs e)
        {
            OnClick(4, 8);
        }

        private void label46_Click(object sender, EventArgs e)
        {
            OnClick(5, 0);
        }

        private void label47_Click(object sender, EventArgs e)
        {
            OnClick(5, 1);
        }

        private void label48_Click(object sender, EventArgs e)
        {
            OnClick(5, 2);
        }

        private void label49_Click(object sender, EventArgs e)
        {
            OnClick(5, 3);
        }

        private void label50_Click(object sender, EventArgs e)
        {
            OnClick(5, 4);
        }

        private void label51_Click(object sender, EventArgs e)
        {
            OnClick(5, 5);
        }

        private void label52_Click(object sender, EventArgs e)
        {
            OnClick(5, 6);
        }

        private void label53_Click(object sender, EventArgs e)
        {
            OnClick(5, 7);
        }

        private void label54_Click(object sender, EventArgs e)
        {
            OnClick(5, 8);
        }

        private void label55_Click(object sender, EventArgs e)
        {
            OnClick(6, 0);
        }

        private void label56_Click(object sender, EventArgs e)
        {
            OnClick(6, 1);
        }

        private void label57_Click(object sender, EventArgs e)
        {
            OnClick(6, 2);
        }

        private void label58_Click(object sender, EventArgs e)
        {
            OnClick(6, 3);
        }

        private void label59_Click(object sender, EventArgs e)
        {
            OnClick(6, 4);
        }

        private void label60_Click(object sender, EventArgs e)
        {
            OnClick(6, 5);
        }

        private void label61_Click(object sender, EventArgs e)
        {
            OnClick(6, 6);
        }

        private void label62_Click(object sender, EventArgs e)
        {
            OnClick(6, 7);
        }

        private void label63_Click(object sender, EventArgs e)
        {
            OnClick(6, 8);
        }

        private void label64_Click(object sender, EventArgs e)
        {
            OnClick(7, 0);
        }

        private void label65_Click(object sender, EventArgs e)
        {
            OnClick(7, 1);
        }

        private void label66_Click(object sender, EventArgs e)
        {
            OnClick(7, 2);
        }

        private void label67_Click(object sender, EventArgs e)
        {
            OnClick(7, 3);
        }

        private void label68_Click(object sender, EventArgs e)
        {
            OnClick(7, 4);
        }

        private void label69_Click(object sender, EventArgs e)
        {
            OnClick(7, 5);
        }

        private void label70_Click(object sender, EventArgs e)
        {
            OnClick(7, 6);
        }

        private void label71_Click(object sender, EventArgs e)
        {
            OnClick(7, 7);
        }

        private void label72_Click(object sender, EventArgs e)
        {
            OnClick(7, 8);
        }

        private void label73_Click(object sender, EventArgs e)
        {
            OnClick(8, 0);
        }

        private void label74_Click(object sender, EventArgs e)
        {
            OnClick(8, 1);
        }

        private void label75_Click(object sender, EventArgs e)
        {
            OnClick(8, 2);
        }

        private void label76_Click(object sender, EventArgs e)
        {
            OnClick(8, 3);
        }

        private void label77_Click(object sender, EventArgs e)
        {
            OnClick(8, 4);
        }

        private void label78_Click(object sender, EventArgs e)
        {
            OnClick(8, 5);
        }

        private void label79_Click(object sender, EventArgs e)
        {
            OnClick(8, 6);
        }

        private void label80_Click(object sender, EventArgs e)
        {
            OnClick(8, 7);
        }

        private void label81_Click(object sender, EventArgs e)
        {
            OnClick(8, 8);
        }

        private void label82_Click(object sender, EventArgs e)
        {
            
        }

        private void label83_Click(object sender, EventArgs e)
        {
            
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NowaGra();
        }

        private void NowaGra()
        {
            label84.Visible = false;
            punkty = 0;
            wybrane_pole = 0;
            kolejny_kolor[0] = 0;
            kolejny_kolor[1] = 0;
            kolejny_kolor[2] = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    plansza[i, j] = 0;
                }
            DodajLosoweKulki();
            Odswiez();
        }

        private void kolorowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            poziom_trudnosci = 5;
            NowaGra();
        }

        private void kolorowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            poziom_trudnosci = 7;
            NowaGra();
        }

        private void kolorowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            poziom_trudnosci = 9;
            NowaGra();
        }

        private void zakonczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wynikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 wyniki = new Form2();
            wyniki.Show(this);
        }
    }
}
