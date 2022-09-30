using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opak2Rocnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZpracujPole(string[] pole, string podretezec, out string prvniSCfirou, out string posledniKonci)
        {
            bool obsahujeCifru = false;
            prvniSCfirou = null;
            posledniKonci = null;
            for(int i=0; i<pole.Length; i++)
            {
                for (int j = 0; j < pole[i].Length && !obsahujeCifru; j++)  //!Obsahujecifru az najdu prvni cifru ukonci
                {
                    if (char.IsDigit(pole[i][j]))
                    {
                        obsahujeCifru = true;
                        prvniSCfirou = pole[i];
                    }
                }
                if (pole[i].EndsWith(podretezec)) posledniKonci = pole[i];
            }

            foreach (string s in pole)
            {
                for(int i = 0; i < s.Length&&!obsahujeCifru; i++)
                {
                    if (char.IsDigit(s[i]))
                    {
                        obsahujeCifru=true;
                        prvniSCfirou = s;
                    }
                }
                if (s.EndsWith(podretezec)) posledniKonci = s;
            }
            return;
        }

        private string[] p;

        private void button1_Click(object sender, EventArgs e)
        {
            int pocetRadku = textBox1.Lines.Count();
            p = new string[pocetRadku];
            //string[] poleSlov = new string[10];
            char[] oddelovace = { ' ', ',', '.' };
            //string nejkratsi=null;

            for(int i = 0; i < pocetRadku; ++i)
            {
                string[] poleSlov = textBox1.Lines[i].Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
                if (poleSlov.Length > 0)
                {
                    string nejkratsi = poleSlov[0];
                    foreach (string slovo in poleSlov)
                    {
                        if (slovo.Length < nejkratsi.Length) nejkratsi = slovo;
                    }
                    p[i] = nejkratsi;
                }
                else
                {
                    p[i] = string.Empty; //Z prazdneho retezce poznam ze na radku nic nebylo
                                          //(prazdny radek nebo pouze oddelovace v radku)
                }
            }

            listBox1.Items.Clear();
            foreach (string kratkeSlovo in p)
            {
                listBox1.Items.Add(kratkeSlovo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*char[] oddelovace = { ' ', ',', '.' };
            string[] poleStringu = new string[textBox1.Lines.Count()];
            for (int i = 0; i < textBox1.Lines.Count(); ++i)
            {
                poleStringu= textBox1.Lines[i].Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
            }
            */string substring = textBox2.Text, prvniSCif = null,posledniKonci=null;
            
            ZpracujPole(p,substring,out prvniSCif,out posledniKonci);
            MessageBox.Show("První slovo s cifrou je: " + prvniSCif);
            MessageBox.Show("Poslední řetězec končící zadaným podřetězcem: " + posledniKonci);

        }
    }
}
