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
        private int pocetBloku;
        //  ArrayList prikazy = new ArrayList();
        private static int aktualniPocetBloku;

        List<List<int>> prikazy = new List<List<int>>();
        List<int> prikaz = new List<int>();
        List<int> outputHrace = new List<int>();
      static  List<PrikazZobrazeni> prikazySeVsim = new List<PrikazZobrazeni>();
        Levely[] vsechnyLevely= new Levely[2] { new Levely(0,20,999), new Levely(1,40,50) };
        private static Panel[] poleButonuEnabledDisabled;
        //int [] pole= new pole
        int aktualniLevel = 0;
        private int aktualniRadek = -1;
        public Form1()
        {
            

            InitializeComponent();
            button9.Enabled = false;
            poleButonuEnabledDisabled = new Panel[8] { jumpIf, jump, output, inputPanel, pricti, odecti1, pricti1, odecti1};
            vypisKonzole();
          
            
        }        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void kompilovat_Click(object sender, EventArgs e)
        {
            
            aktualniRadek = -1;
            button9.Enabled = true;

            prikazy = new List<List<int>>();
            konzole.Clear();
            textBox1.Clear();
            vsechnyLevely[aktualniLevel] = new Levely( aktualniLevel,vsechnyLevely[aktualniLevel].getMin(), vsechnyLevely[aktualniLevel].getMax()) ;
            vypisKonzole();
            konzole.AppendText(Environment.NewLine);

            for(int i = 0; i < vsechnyLevely[aktualniLevel].getInputCely().Count();i++)
            {
                inputTB.AppendText(vsechnyLevely[aktualniLevel].getInputCely()[i].ToString() + "  ");
            }
            //Zaznamenani Zmen
            


            for (int i = 0; i < prikazySeVsim.Count; i++)  // prechod z bloku na blok
            {
               
                prikaz.Add(prikazySeVsim[i].getTyp());
                textBox1.Text += "typ" + (prikazySeVsim[i].getTyp()).ToString();
                if (prikazySeVsim[i].getTyp() == 0)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                   // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgument2()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                    //textBox1.Text += "  argument2cb" + (prikazy[i][2]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 1)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 2)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 3) // jump if
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    prikaz.Add(prikazySeVsim[i].getArgument3());
                    prikaz.Add(prikazySeVsim[i].getArgument4());
                }
                else if (prikazySeVsim[i].getTyp() == 4)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument4());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 5)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 6)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                //...
                else if (prikazySeVsim[i].getTyp() == 7)
                {
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                   // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgument2()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                    //textBox1.Text += "  argument2cb" + (prikazy[i][2]).ToString();
                }


                // ||


                prikazy.Add(prikaz);

                textBox1.Text += "   typ " + (prikazy[i][0]).ToString();
                
              
                prikaz = new List<int>();

            }
            ////////precetli jste   Zaznamenani Zmen
        }


        //// Provadeni Priakazu

        private void button9_Click(object sender, EventArgs e)
        {
               
            //for (int i = 0; a <= aktualniRadek;i++)
            for (int i = 0; i < int.Parse(velikostKroku.Text); i++ )
            {
                
                aktualniRadek += 1;
                //MessageBox.Show("aktualni radek: " + aktualniRadek.ToString());
                
                if (aktualniRadek < prikazy.Count)
                {

                    //MessageBox.Show(prikazy[aktualniRadek][0].ToString());

                    if (prikazy[aktualniRadek][0] == 0) // Prirad
                    {
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]);
                      
          
                        if (hodA == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(prikazy[aktualniRadek][1], (int)hodA);
                            //textbox text co se stalo(priradilo se A k B)

                            vypisKonzole();
                            //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());

                        }

                    }
                    else if (prikazy[aktualniRadek][0] == 1) // Pricit jedna
                    {
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]);


                        if (hodA == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(prikazy[aktualniRadek][1], (int)hodA + 1);
                            //textbox text co se stalo(priradilo se A k B)

                            vypisKonzole();
                            //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());

                        }

                    }
                    else if (prikazy[aktualniRadek][0] == 2) // odecti jedna
                    {
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]);


                        if (hodA == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(prikazy[aktualniRadek][1], (int)hodA - 1);
                            //textbox text co se stalo(priradilo se A k B)

                            vypisKonzole();
                            //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());

                        }
                        
                    }
                    else if (prikazy[aktualniRadek][0] == 3) // jump if
                    {
                        //MessageBox.Show("typ ", prikazy[aktualniRadek][0].ToString());
                        int kamSkocit = prikazy[aktualniRadek][4];
                        if (kamSkocit < 0 || kamSkocit > prikazy.Count)
                        {
                            // MessageBox.Show("mmmmm lysarny " + prikazy[aktualniRadek][1].ToString() + " prikk " + prikazy.Count.ToString());
                        }
                        else
                        {
                            if(prikazy[aktualniRadek][3] == 1)
                            {
                                if(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) == vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    konzole.AppendText("Podminka nesplnena ");
                                    konzole.AppendText(Environment.NewLine);
                                }
                            }
                            else if (prikazy[aktualniRadek][3] == 2)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) < vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    konzole.AppendText("Podminka nesplnena ");
                                    konzole.AppendText(Environment.NewLine);
                                }

                            }
                            else if (prikazy[aktualniRadek][3] == 3)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) > vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    konzole.AppendText("Podminka nesplnena " ); 
                                    konzole.AppendText(Environment.NewLine);

                                }

                            }

                            
                            // MessageBox.Show("aktialni rakde " + aktualniRadek.ToString());
                        }

                    }

                    else if (prikazy[aktualniRadek][0] == 4) // jump 
                    {
                        //MessageBox.Show("typ ", prikazy[aktualniRadek][0].ToString());
                        int kamSkocit = prikazy[aktualniRadek][1];
                        if (kamSkocit < 0 || kamSkocit > prikazy.Count)
                        {
                            // MessageBox.Show("mmmmm lysarny " + prikazy[aktualniRadek][1].ToString() + " prikk " + prikazy.Count.ToString());
                        }
                        else
                        {

                            aktualniRadek = kamSkocit - 2;
                            konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                            konzole.AppendText(Environment.NewLine);
                            // MessageBox.Show("aktialni rakde " + aktualniRadek.ToString());
                        }

                    }


                    else if (prikazy[aktualniRadek][0] == 5) // input
                    {
                        
                        int specArgument1 = prikazy[aktualniRadek][1]; // kam
                        if ((vsechnyLevely[aktualniLevel].getHodnota(specArgument1)) == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(specArgument1, vsechnyLevely[aktualniLevel].getInput());
                            //textbox text co se stalo(priradilo se A k B)

                            vypisKonzole();
                            //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());

                        }

                    }
                    else if (prikazy[aktualniRadek][0] == 6) // output
                    {

                        int specArgument1 = prikazy[aktualniRadek][1]; // kam
                        if ((vsechnyLevely[aktualniLevel].getHodnota(specArgument1)) == null)
                        {


                        }
                        else
                        {
                            outputHrace.Add((int)vsechnyLevely[aktualniLevel].getHodnota(specArgument1));
                            konzole.AppendText(Environment.NewLine);
                            konzole.AppendText("output: ");
                            for (int w = 0; w < outputHrace.Count(); w++)
                            {
                                konzole.AppendText(outputHrace[w].ToString());
                            }

                            if (outputHrace.Count() == vsechnyLevely[aktualniLevel].getOutput().Count())
                            {
                                bool bl = true;
                                for (int k = 0; k < outputHrace.Count(); k++)
                                {
                                    if (outputHrace[k] != vsechnyLevely[aktualniLevel].getOutput()[k])
                                    {
                                        bl = false;
                                        break;
                                    }
                                   


                                }
                                if(bl)
                                {
                                    konzole.AppendText(Environment.NewLine);
                                    konzole.AppendText("Vyhral jsi!");
                                }

                            }    

                            //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());

                        }

                    }
                    
                    else if (prikazy[aktualniRadek][0] == 7) // pricti
                    {
                        //MessageBox.Show("  mmmmmmm " + aktualniRadek.ToString());
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]);


                        if (hodA == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(prikazy[aktualniRadek][1], (int)hodA + (int)vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]));
                            //textbox text co se stalo(priradilo se A k B)

                            vypisKonzole();

                        }

                    }

                }
            }
        }
        //// precetli jste  Provadeni Priakazu

        private void vypisKonzole()
        {
            konzole.AppendText("a = " + vsechnyLevely[aktualniLevel].getHodnotaA());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaA().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }
            konzole.AppendText("b = " + vsechnyLevely[aktualniLevel].getHodnotaB());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaB().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }
            konzole.AppendText("c = " + vsechnyLevely[aktualniLevel].getHodnotaC());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaC().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }
            konzole.AppendText("d = " + vsechnyLevely[aktualniLevel].getHodnotaD());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaD().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }
            konzole.AppendText("e = " + vsechnyLevely[aktualniLevel].getHodnotaE());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaE().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }
            konzole.AppendText("f = " + vsechnyLevely[aktualniLevel].getHodnotaF());
            for (int i = 0; i < 7 - vsechnyLevely[aktualniLevel].getHodnotaF().ToString().Length; i++)
            {
                konzole.AppendText(" ");
            }

            konzole.AppendText(Environment.NewLine);
        }

        private void setDisebledOthers(string tag)
        {
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
        public static void zmenPole()
        {
            PrikazZobrazeni.ScrolHelp.Controls.Clear();
            for (int i = 0; i < prikazySeVsim.Count; i++)
            {
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getCisloratku());
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getBlok());
                prikazySeVsim[i].setCisloRadkuPoint(i * 85, 0);
                prikazySeVsim[i].setBlokPoint(50, i * 85);
                prikazySeVsim[i].setTagPos(i);
                prikazySeVsim[i].setCisloRadkuText((i + 1).ToString());
            }
        }

        private void everyBtnClick(int typPrikazu)
        {
            kompilovat.Enabled = false;
            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, typPrikazu, panel_scrolllll));
            prikazySeVsim[prikazySeVsim.Count - 1].setBlokPoint(200, 20);
            aktualniPocetBloku = prikazySeVsim.Count();
        }

        private void jumpIf_Click(object sender, EventArgs e)
        {
            everyBtnClick(3);
        }


        private void jump_Click(object sender, EventArgs e)
        {
            everyBtnClick(4);
        }
        private void pricti1_Click(object sender, EventArgs e)
        {
            everyBtnClick(1);
        }

        private void odecti1_Click(object sender, EventArgs e)
        {
            everyBtnClick(2);
        }

        private void inputPanel_Click(object sender, EventArgs e)
        {
            everyBtnClick(5);
        }
        public static int getAktpocet()
        {
            return aktualniPocetBloku;
        }
        private void jumpIf_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prirad_Click(object sender, EventArgs e)
        {
            everyBtnClick(0);
        }

        private void pricti_Click(object sender, EventArgs e)
        {
            everyBtnClick(7);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void prirad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void velikostKroku_TextChanged(object sender, EventArgs e)
        {

        }

        private void output_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(6);
        }

        public static void pridejDoPoleImaze(int cilovtIndex, int puvodniIndex)//PrikazZobrazeni pavel)
        {
        //    MessageBox.Show("cilovi index " + cilovtIndex.ToString() + "puvodni index" + puvodniIndex.ToString() + " celkovi pocet prikazu" + prikazySeVsim.Count);
            PrikazZobrazeni pavel = prikazySeVsim[puvodniIndex];
            prikazySeVsim.RemoveAt(puvodniIndex);
            PrikazZobrazeni posun = null;// prikazySeVsim[i];
            //PrikazZobrazeni posun;
            prikazySeVsim.Insert(cilovtIndex, pavel);/*
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

            /*posun.setBlokPoint(50, (prikazySeVsim.Count + 2) * 85);
            posun.setCisloRadkuPoint((prikazySeVsim.Count + 2) * 85, 0);
            prikazySeVsim.Add(posun);

        }*/
        }

        private void outputTB_TextChanged(object sender, EventArgs e)
        {

        }
        public static void deleFromMainArray(int pozice)
        {

            // MessageBox.Show("aktualne mazana pozice: "+pozice.ToString());
            prikazySeVsim.RemoveAt(pozice);
            aktualniPocetBloku--;

        }
    }
}
