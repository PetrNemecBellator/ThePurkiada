using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noMansResourceMachine
{
    public partial class Form1 : Form
    {
        //Prikaz pk;//= new Prikaz(0, 0, this);
        private static int pocetBloku;
      //  ArrayList prikazy = new ArrayList();
        List<List<int>> prikazy = new List<List<int>>();
        List<int> prikaz = new List<int>();
        List<PrikazZobrazeni> prikazySeVsim = new List<PrikazZobrazeni>();
        Levely[] vsechnyLevly = new Levely[2];
        
        //int [] pole= new pole
        int aktualniLevel = 1;
        public Form1()
        {
            InitializeComponent();
        }        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kompilovat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < prikazySeVsim.Count; i++)
            {

                prikaz.Add(prikazySeVsim[i].getTyp());
                textBox1.Text += "typ " + (prikazySeVsim[i].getTyp()).ToString();
                prikaz.Add(prikazySeVsim[i].getPromenaA());
                textBox1.Text += "argument1" + (prikazySeVsim[i].getPromenaA()).ToString();
                prikaz.Add(prikazySeVsim[i].getPromenaB());
                textBox1.Text += "argument2" + (prikazySeVsim[i].getPromenaB()).ToString();

                prikazy.Add(prikaz);
                prikaz.Clear();

            }
            for (int i = 0; i < prikazy.Count; i++)
            {

                if (prikazy[i][0] == 0)  // Prirad
                {
                    if (prikazy[i][1] == 1) // A
                    {

                        vsechnyLevly[aktualniLevel].setHodnotaA(prikazy[i][(int) vsechnyLevly[aktualniLevel].getHod(prikazy, i)]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }
                    else if (prikazy[i][1] == 1)
                    {
                        vsechnyLevly[aktualniLevel].setHodnotaB(prikazy[i][2]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }
                    else if (prikazy[i][1] == 1)
                    {
                        vsechnyLevly[aktualniLevel].setHodnotaC(prikazy[i][2]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }
                    else if (prikazy[i][1] == 1)
                    {
                        vsechnyLevly[aktualniLevel].setHodnotaD(prikazy[i][2]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }
                    else if (prikazy[i][1] == 1)
                    {
                        vsechnyLevly[aktualniLevel].setHodnotaE(prikazy[i][2]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }
                    else
                    {
                        vsechnyLevly[aktualniLevel].setHodnotaF(prikazy[i][2]);
                        textBox2.Text += "Hodnota promene A se zmenila na ";
                    }

                }



            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     /* private void jumpIf_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count , 3, panel_scrolllll));
        }*/


        private void jump_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 4, panel_scrolllll));
        }
        private void pricti1_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 1, panel_scrolllll));
        }

        private void odecti1_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 2, panel_scrolllll));
        }

        private void inputPanel_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 5, panel_scrolllll));
        }

      

        private void output_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 6, panel_scrolllll));
        }

        private void prirad_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 0, panel_scrolllll));
        }

        private void pricti_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 7, panel_scrolllll));
        }

        private void odecti_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 8, panel_scrolllll));
        }

        private void jumpIf_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, 3, panel_scrolllll));
            everyClick(prikazySeVsim.Count);
        }
        private void everyClick(int cislo)
        {
        }

     

        private void panel_scrolllll_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
