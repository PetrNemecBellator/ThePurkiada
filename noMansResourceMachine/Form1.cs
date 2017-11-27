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
            //    pk = new Prikaz(0, 0, this);
            //   this.BackColor = Color.FromArgb(255,255,255,255)
            PrikazZobrazeni[] ml = new PrikazZobrazeni[] {new PrikazZobrazeni (0, 0, this),
            new PrikazZobrazeni(85,1,this), new PrikazZobrazeni(85*2,2,this), new PrikazZobrazeni(85*3,3,this),
            new PrikazZobrazeni(85*4,4,this),
            new PrikazZobrazeni(85*5,5,this),
              new PrikazZobrazeni(85*5,6,this),
            new PrikazZobrazeni(85*7,7,this),
            new PrikazZobrazeni(85*6,7,this)};
        

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

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
