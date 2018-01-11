﻿using System;
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
        Levely[] vsechnyLevely= new Levely[3] { new Levely(0), new Levely(1), new Levely(2) };
        private static Panel[] poleButonuEnabledDisabled;
        //int [] pole= new pole
        int aktualniLevel = 0;
        int pocetProvedenychInstrukci = 0;
        int pocetPouzitychPromenych = 0;
        private int aktualniRadek = -1;
        public Form1()
        {
            

            InitializeComponent();
            button9.Enabled = false;
            kompilovat.Enabled = false;
            poleButonuEnabledDisabled = new Panel[8] { jumpIf, jump, output, inputPanel, pricti, odecti1, pricti1, odecti1};
            vypisKonzole();
//            vypisKonzole();
            zadani.Text = vsechnyLevely[aktualniLevel].getZadani();




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ArrayList chybneBloky = new ArrayList();
        public bool jeCisloOk(int cislo)
        {
            return cislo == 7012;
        }
        public void blokChybaVipis(string typBloku, int radek)
        {
            MessageBox.Show("Blok "+ typBloku.ToString()+" na řádku " + radek.ToString() + "\n nemá spravně doplněné argumenty","Chyba!");
        }
        private void kompilovat_Click(object sender, EventArgs e)
        {
            
            aktualniRadek = -1;
            button9.Enabled = true;

            prikazy = new List<List<int>>();
            konzole.Clear();
            //textBox1.Clear();
            vsechnyLevely[aktualniLevel] = new Levely( aktualniLevel) ;
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
                //textBox1.Text += "typ" + (prikazySeVsim[i].getTyp()).ToString();
                if (prikazySeVsim[i].getTyp() == 0)
                {
                    if (prikazySeVsim[i].getArgument1() == 7012 && prikazySeVsim[i].getArgument2() == 7012)
                    {
                        blokChybaVipis("přiřaď", i + 1);
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                   // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgument2()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                    //textBox1.Text += "  argument2cb" + (prikazy[i][2]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 1)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument1())){
                        blokChybaVipis("přičti jedna", i + 1);
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 2)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("odečti 1", i + 1);
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 3) // jump if
                {if((jeCisloOk(prikazySeVsim[i].getArgument1())&& jeCisloOk(prikazySeVsim[i].getArgument2())
                    && jeCisloOk(prikazySeVsim[i].getArgument3()) && jeCisloOk(prikazySeVsim[i].getArgument4()))){
                        blokChybaVipis("skoč pokud", i + 1);
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    prikaz.Add(prikazySeVsim[i].getArgument3());
                    prikaz.Add(prikazySeVsim[i].getArgument4());
                }
                else if (prikazySeVsim[i].getTyp() == 4)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument4()))
                    {
                        blokChybaVipis("skoč",i + 1);
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument4());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 5)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("vstup", i + 1);
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 6)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument2()))
                    {
                        MessageBox.Show((jeCisloOk(prikazySeVsim[i].getArgument2()).ToString() + "a jakz cislo si dostal: " + (prikazySeVsim[i].getArgument2())));
                        blokChybaVipis("výstup", i + 1);
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                //...
                else if (prikazySeVsim[i].getTyp() == 7)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument4()))
                    {
                        blokChybaVipis("přicti", i + 1);
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument1());
                   // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgument2()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                    //textBox1.Text += "  argument2cb" + (prikazy[i][2]).ToString();
                }


                // ||


                prikazy.Add(prikaz);

                //textBox1.Text += "   typ " + (prikazy[i][0]).ToString();

                konecKompilace:;
                prikaz = new List<int>();
                                

            }
            ////////precetli jste   Zaznamenani Zmen
        }


        //// Provadeni Priakazu
        private void vyhra()
        {
            MessageBox.Show("Vyhral jsi!");
            aktualniLevel++;
            prikazySeVsim.Clear();
            panel_scrolllll.Controls.Clear();
            konzole.Clear();
            vypisKonzole();
            inputTB.Clear();
            outputTB.Clear();
            zadani.Text = vsechnyLevely[aktualniLevel].getZadani();
            pocetProvedenychInstrukci = 0;
            pocetPouzitychPromenych = 0;
        }
        private void button9_Click(object sender, EventArgs e)
        {

            if (int.Parse(velikostKroku.Text) == 2522000)
            {

                vyhra();
                goto konecProcesovani;
            }


            else if (int.Parse(velikostKroku.Text) > 100)
            {
                MessageBox.Show("Pocet kroku je moc velky, musi byt pod 100");
                goto konecProcesovani;

            }
            for (int i = 0; i < int.Parse(velikostKroku.Text); i++)
            {

                pocetProvedenychInstrukci += 1;
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
                           konzole.AppendText(aktualniRadek + 1+". ");
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
                           konzole.AppendText(aktualniRadek + 1+". ");
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
                           konzole.AppendText(aktualniRadek + 1+". ");
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
                             MessageBox.Show("Nelze skocit na radek"+kamSkocit.ToString(),"Chyba!!");
                        }
                        else
                        {
                            if (prikazy[aktualniRadek][3] == 1)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) == vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() +" = "+ vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                   konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " = " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());

                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podminka nesplnena ");
                                    konzole.AppendText(Environment.NewLine);
                                }
                            }
                            else if (prikazy[aktualniRadek][3] == 2)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) < vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " < " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " < " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podminka nesplnena ");
                                    konzole.AppendText(Environment.NewLine);
                                }

                            }
                            else if (prikazy[aktualniRadek][3] == 3)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) > vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " > " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                   konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " > " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podminka nesplnena ");
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
                           konzole.AppendText(aktualniRadek + 1+". ");
                            konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". radek"); //po
                            konzole.AppendText(Environment.NewLine);
                            // MessageBox.Show("aktialni rakde " + aktualniRadek.ToString());
                        }

                    }


                    else if (prikazy[aktualniRadek][0] == 5) // input
                    {

                        int specArgument1 = prikazy[aktualniRadek][1]; // kam
                        vsechnyLevely[aktualniLevel].setHodnota(specArgument1, vsechnyLevely[aktualniLevel].getInput());
                        //textbox text co se stalo(priradilo se A k B)
                        inputTB.Clear();
                        for (int mocforcylklu = 0; mocforcylklu < vsechnyLevely[aktualniLevel].getInputCely().Count(); mocforcylklu++)
                        {

                            inputTB.AppendText(vsechnyLevely[aktualniLevel].getInputCely()[i].ToString() + "  ");
                        }
                       konzole.AppendText(aktualniRadek + 1+". ");
                        vypisKonzole();
                        //MessageBox.Show(aktualniRadek.ToString() + "  typ  " + prikazy[aktualniRadek][0].ToString());






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
                           konzole.AppendText(aktualniRadek + 1+". ");
                            konzole.AppendText("Do vystupu bylo pridano cislo");
                            konzole.AppendText(Environment.NewLine);

                            outputTB.AppendText(vsechnyLevely[aktualniLevel].getHodnota(specArgument1).ToString() + " ");


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

                                if (bl)
                                {
                                    if (vsechnyLevely[aktualniLevel].getMaxPocetRadku() != 0)
                                    {
                                        if (prikazy.Count() > vsechnyLevely[aktualniLevel].getMaxPocetRadku())
                                        {

                                            MessageBox.Show("Výstup máš správně, ale máš moc (" + prikazy.Count() + ") řádků");
                                            break;
                                        }
                                    }
                                    if (vsechnyLevely[aktualniLevel].getMaxPocetInstrukci() != 0)
                                    {
                                        if (pocetProvedenychInstrukci > vsechnyLevely[aktualniLevel].getMaxPocetInstrukci())
                                        {
                                            MessageBox.Show("Výstup máš správně, ale provedl jsi moc (" + pocetProvedenychInstrukci + ") instrukcí(příkazů)");
                                            break;
                                        }
                                    }

                                    if (vsechnyLevely[aktualniLevel].getMaxPocetPromenych() != 0)
                                    {
                                        for (int idk = 1; idk < 7; idk++)
                                        {
                                            if (vsechnyLevely[aktualniLevel].getHodnota(idk) != null)
                                            {
                                                pocetPouzitychPromenych += 1;
                                            }
                                        }
                                        if (pocetPouzitychPromenych > vsechnyLevely[aktualniLevel].getMaxPocetPromenych())
                                        {
                                            MessageBox.Show("Výstup máš správně, ale použil jsi moc (" + pocetPouzitychPromenych + ") proměnných");
                                            break;
                                        }


                                    }

                                    vyhra();
                                    break;
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
                           konzole.AppendText(aktualniRadek + 1+". ");
                            vypisKonzole();

                        }

                    }
                    else if (prikazy[aktualniRadek][0] == 8) // odecti
                    {
                        //MessageBox.Show("  mmmmmmm " + aktualniRadek.ToString());
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]);


                        if (hodA == null)
                        {


                        }
                        else
                        {

                            vsechnyLevely[aktualniLevel].setHodnota(prikazy[aktualniRadek][1], (int)vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) - (int)hodA);
                            //textbox text co se stalo(priradilo se A k B)
                           konzole.AppendText(aktualniRadek + 1+". ");
                            vypisKonzole();

                        }

                    }

                }

            }
            konecProcesovani:;
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
        public void zobrazNapovedu(string nadpis,string obsahNapovedy)
        {
            MessageBox.Show(obsahNapovedy,nadpis);
        }
      
        public static void zmenPole()
        {
            /* todo 
             * smaze fraficke pole a nahradi je 
             * aktulanim polem z prikazySeVsim            * 
             * 
             * */
            PrikazZobrazeni.ScrolHelp.Controls.Clear();
            for (int i = 0; i < prikazySeVsim.Count; i++)
            {
                int yPos = i * 85;
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getCisloratku());
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getBlok());

                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getDeletebutton());
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getupButton());
                PrikazZobrazeni.ScrolHelp.Controls.Add(prikazySeVsim[i].getdownButton());

                prikazySeVsim[i].setCisloRadkuPoint(yPos, 0);
                prikazySeVsim[i].setBlokPoint(50, yPos);
                prikazySeVsim[i].setTagPos(i);
                
                prikazySeVsim[i].setupButtonLocationY(yPos);
                prikazySeVsim[i].setdownButtonLocationY(yPos+20);
                prikazySeVsim[i].setDeletelocation(yPos);
                prikazySeVsim[i].setCisloRadkuText((i + 1).ToString());
            }
        }

        private void everyBtnClick(int typPrikazu)
        {
            kompilovat.Enabled = true;
            button9.Enabled = false;

            prikazySeVsim.Add(new PrikazZobrazeni(prikazySeVsim.Count, typPrikazu, panel_scrolllll));
            // prikazySeVsim[prikazySeVsim.Count - 1].setBlokPoint(200, 20);
            //prikazySeVsim[prikazySeVsim.Count-1].setBlokPoint(20,)
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
            int cislo;

            if (int.TryParse(velikostKroku.Text,out cislo))
            {
                velikostKroku.BackColor = Color.WhiteSmoke;
            }
            else
            {
                velikostKroku.BackColor = Color.Red;
            }
        }

        private void output_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(6);
        }

        public static void pridejDoPoleImaze(int cilovtIndex, int puvodniIndex)//PrikazZobrazeni pavel)
        {

            //    MessageBox.Show("cilovi index " + cilovtIndex.ToString() + "puvodni index" + puvodniIndex.ToString() + " celkovi pocet prikazu" + prikazySeVsim.Count);
            if (cilovtIndex > prikazySeVsim.Count-1) { 
                prikazySeVsim[prikazySeVsim.Count-1] = prikazySeVsim[puvodniIndex];
            }
            else
            {
                PrikazZobrazeni pavel = prikazySeVsim[puvodniIndex];
                prikazySeVsim.RemoveAt(puvodniIndex);
            //    PrikazZobrazeni posun = null;// prikazySeVsim[i];
                                             //PrikazZobrazeni posun;
                prikazySeVsim.Insert(cilovtIndex, pavel);
            }/*
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

        private void odecti_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("skoč když", "Když se splní podminka skočí na jiný řádek."+
                "\n   příklad: 1. pole \"5\" 2. pole \">\" 3. pole \"2\" 4.pole \"4\" \n  " +
                "5 je vetši než 2 takže program pokračuje od 4 řadku \n  " +
                "pokud by byla podminka nepravdiva nic se neděje program \n   pokračuje dale.");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("vstup", "Vezme 1 cislo ze vstupu a uloziho do promene zadane v 1.poli ");
        }

        private void napSkoc_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("skoč", "Vždy skočí na řádek zadaný v poli");
        }

        private void napPricti1_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("přičti jedna", "K promněnne v 1. poli přičte jedna \n  "+
                "příklad: pole obsahuje \"5\"  vysledna hodnota je 6 (5+1) ");
        }

        private void napOdecti1_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("odečti jedna", "K promněnne v 1. poli odečte jedna \n  " +
                "příklad: pole obsahuje \"6\"  vysledna hodnota je 5 (6-1) ");
        }

        private void napVystup_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("výstup", "Vezme čislo z proměnné zadané v 1. poli \n  " +
                "poté je dá do výstupu ");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("přiřaď", "Proměnnou napsanou 1. poli nahradí hodnoutou proměnné nebo čila zadaneho v 2. poli \n\t"+
                "příklad: A=1 B=5 1.pole \"A\" 2. pole \"5\" \n   vysledne hodnoty  A =5 B=5");
        }

        private void napPricti_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("příčti", "K promněnne v 1. poli příčte proměnnou nebo čislo z 2. pole \n  " +
                "příklad:(proměnná)  A=6 1.pole obsahuje \"A= 6\" (proměnná) B=5 2.pole \"B=5\"  vysledna hodnota je A= 11  (5+6), B= 5. ");
        }

        private void napOdecti_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("příčti", "K promněnne v 1. poli odečte proměnnou nebo čislo z 2. pole \n\t" +
                "příklad: (proměnná A=6) 1.pole obsahuje \"A\" (proměnná B=5) 2.pole \"B\"  vysledna hodnota  A = -1  (5-6), B= 5. ");
        }

        private void skocKdyzLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(3);
        }

        private void skocLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(4);
        }

        private void pricti1Label_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(1);
        }

        private void odecti1Label_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(2);
        }

        private void vstupLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(5);
        }

        private void vystupLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(6);
        }

        private void priradLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(0);
        }

        private void prictiLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(7);
        }

        private void odectiLabel_MouseClick(object sender, MouseEventArgs e)
        {
            everyBtnClick(8);
        }
    }
}
