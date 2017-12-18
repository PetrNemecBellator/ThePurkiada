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
        static List<PrikazZobrazeni> prikazySeVsim = new List<PrikazZobrazeni>();
        Levely[] vsechnyLevly = new Levely[2];
        private static int aktualniPocetBloku;

        //int [] pole= new pole
        int aktualniLevel = 1;
        public Form1()
        {
            InitializeComponent();
            PrikazZobrazeni.initPrikazPole(prikazySeVsim);
            // PrikazZobrazeni.setScroll(groupBox1);
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

                        vsechnyLevly[aktualniLevel].setHodnotaA(prikazy[i][(int)vsechnyLevly[aktualniLevel].getHod(prikazy, i)]);
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
        public void blbos()
        {

        }
        /*  public void smazPole(int index, PrikazZobrazeni pavel)
          {


              PrikazZobrazeni posun;
              //PrikazZobrazeni posun;
              for (int i = index; i < prikazySeVsim.Count; i++)
              {
                  posun = prikazySeVsim[i];
                  prikazySeVsim[i] = pavel;

              }
          }
  */
        public static void pridejDoPoleImaze(int cilovtIndex, int puvodniIndex)//PrikazZobrazeni pavel)
        {
            MessageBox.Show("cilovi index " + cilovtIndex.ToString() + "puvodni index" + puvodniIndex.ToString() + " celkovi pocet prikazu" + prikazySeVsim.Count);
            PrikazZobrazeni pavel = prikazySeVsim[puvodniIndex];
            prikazySeVsim.RemoveAt(puvodniIndex);
            PrikazZobrazeni posun = null;// prikazySeVsim[i];
            //PrikazZobrazeni posun;

            if (cilovtIndex == prikazySeVsim.Count)
            {
               // MessageBox.Show("podminka");
                pavel.setTagPos(cilovtIndex);
                pavel.setBlokPoint(50, cilovtIndex * 85);
                prikazySeVsim.Add(pavel);
            }
            else
            {
                MessageBox.Show("cil index " + cilovtIndex.ToString() + " pocet opakovani: " + (prikazySeVsim.Count));
                posun = prikazySeVsim[cilovtIndex];
                prikazySeVsim[cilovtIndex] = pavel;
                // List<PrikazZobrazeni> pomocnicek = new List<PrikazZobrazeni>();
             /*    int  i = prikazySeVsim.Count;
                PrikazZobrazeni pomocnicek = new PrikazZobrazeni[i];
                for (int i = 0; i < prikazySeVsim.Count; i++)
                {
                    if (cilovtIndex == i)
                    {
                        pavel.setBlokPoint(50, (prikazySeVsim.Count + 2) * 85);
                        pavel.setCisloRadkuPoint((prikazySeVsim.Count + 2) * 85, 0);
                        pomocnicek.Add(pavel);
                        continue;
                    }
                    (prikazySeVsim[i]).setBlokPoint(50, (prikazySeVsim.Count + 2) * 85);
                    (prikazySeVsim[i]).setCisloRadkuPoint((prikazySeVsim.Count + 2) * 85, 0);
                    pomocnicek.Add(prikazySeVsim[i]);
                }
                pomocnicek.CopyTo(0,prikazySeVsim,0,pomocnicek.Count);
            }
                //prikazySeVsim.Insert(cilovtIndex,pavel);
                // prikazySeVsim[cilovtIndex + 1] = posun;
                /* for (int i = cilovtIndex; i<prikazySeVsim.Count-1 ; i++)
             {

                //pavel =  prikazySeVsim[i];
                //prikazySeVsim[i] = posun;
                /* pavel = prikazySeVsim[i]; // predchozi
                 prikazySeVsim[i] = posun; //aktualni 
                 posun = prikazySeVsim[i + 1];
                 posun.setBlokPoint(50, (i+1) * 85);
                 posun.setCisloRadkuPoint(( i+1) * 85, 0);
               */ // posun = pavel;
                  /*
                   prikazySeVsim[i] = pavel;
                   pavel= prikazySeVsim[i + 1];
                   prikazySeVsim[i+1] = posun;*/

                


                //}
                     posun.setBlokPoint(50, (prikazySeVsim.Count+2) * 85);
                     posun.setCisloRadkuPoint((prikazySeVsim.Count+2) * 85, 0);
                     prikazySeVsim.Add(posun);
                 

         }
        
        public static void zmenPole()
        {
            PrikazZobrazeni.ScrolHelp.Controls.Clear();
             for (int i = 0; i<prikazySeVsim.Count; i++)
            {
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getCisloratku());
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getBlok());
                prikazySeVsim[i].setCisloRadkuPoint(i*85,0);
                prikazySeVsim[i].setBlokPoint(50,i*85);
                prikazySeVsim[i].setTagPos(i);
                prikazySeVsim[i].setCisloRadkuText((i + 1).ToString());
            }
        }

        protected override void OnMouseMove(MouseEventArgs mouseEv)
        {

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
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 4,panel_scrolllll));
            aktualniPocetBloku++;
        }
        private void pricti1_Click(object sender, EventArgs e)
        {
          prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 1, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void odecti1_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 2, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void inputPanel_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 5, panel_scrolllll));
            aktualniPocetBloku++;
        }

      

        private void output_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 6, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void prirad_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 0, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void pricti_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 7, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void odecti_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 8, panel_scrolllll));
            aktualniPocetBloku++;
        }

        private void jumpIf_Click(object sender, EventArgs e)
        {
            prikazySeVsim.Add(new PrikazZobrazeni(aktualniPocetBloku, 3, panel_scrolllll));
            aktualniPocetBloku++;
        }
        private void everyClick(int cislo)
        {
        }
        /*  public List<List<PrikazZobrazeni>>  getPrikazy()
          {
              return this.prikazyToget;
          }*/

      public static void deleFromMainArray(int pozice)
        {

           // MessageBox.Show("aktualne mazana pozice: "+pozice.ToString());
            prikazySeVsim.RemoveAt(pozice);
            aktualniPocetBloku--;

        }
        
        public static void zmenPocetBloku(int prictePocetbloku)
        {
            aktualniPocetBloku += prictePocetbloku;
        }
        public static int getAktpocet()
        {
           return aktualniPocetBloku;
        }
        private void panel_scrolllll_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
