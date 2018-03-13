using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noMansResourceMachine
{
    public partial class Form1 : Form
    {
        //Prikaz pk;//= new Prikaz(0, 0, this);
        public static String jmeno = "a";
        private int pocetBloku;
        //  ArrayList prikazy = new ArrayList();
        private static int aktualniPocetBloku;
        private bool nastalaChyba = false;
        List<List<int>> prikazy = new List<List<int>>();
        List<int> prikaz = new List<int>();
        List<int> outputHrace = new List<int>();
        static List<PrikazZobrazeni> prikazySeVsim = new List<PrikazZobrazeni>();
        Thread beziciProgram;
        Levely[] vsechnyLevely = new Levely[9] { new Levely(0), new Levely(1), new Levely(2), new Levely(3), new Levely(4), new Levely(5), new Levely(6), new Levely(7), new Levely(8) };
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
            //  kompilovat.Enabled = false;
            beziciProgram = new Thread(kompilaceJede);
            beziciProgram.Name = "vlaknoKompilace";
            
            
            vypisKonzole();
            //            vypisKonzole();
            zadani.Text = vsechnyLevely[aktualniLevel].getZadani();
            prijmeni.BackColor = Color.Red;

            MessageBox.Show("Tato aplikace slouží k programovaní zadaných úkolu pomoci jednoduchých bloku. Ty jsou umístěny na pravé straně. Kliknutím na ně je umístíte doprostřed a vytvoříte blokové schema programu podle zadání vlevo. Vyplňte příjmení. Pokud bude program správně, postupujete do dalšího levelu. Proměnné požíváte A-F, konstanty lze psát jen do bloku \"skoč když\" a \"výstup\". Svůj program spustíme kliknutiím na tlačítko \"Start\", poté se do kolonky vstup (vlevo uprostřed) vygenerují nahodná čísla, se kterými bude Váš program pracovat. Pěknou zábavu!", "Základní informace");



        }

        public static String getJmeno()
        {
            return jmeno.ToUpper();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ArrayList chybneBloky = new ArrayList();
        public bool jeCisloOk(int cislo)
        {
            return cislo == int.MaxValue;
        }
        public void blokChybaVipis(string typBloku, int řádek)
        {
            MessageBox.Show("Blok " + typBloku.ToString() + " na řádku " + řádek.ToString() + "\n nemá spravně doplněné argumenty", "Chyba!");
        }
        public void kompilaceJede()
        {
            nastalaChyba = false;
            aktualniRadek = -1;
            button9.Enabled = true;
            pocetProvedenychInstrukci = 0;
            pocetPouzitychPromenych = 0;

            prikazy = new List<List<int>>();
            konzole.Clear();
            inputTB.Clear();
            outputTB.Clear();
            outputHrace.Clear();
            //textBox1.Clear();
            vsechnyLevely[aktualniLevel] = new Levely(aktualniLevel);
            vypisKonzole();
            konzole.AppendText(Environment.NewLine);

            for (int i = 0; i < vsechnyLevely[aktualniLevel].getInputCely().Count(); i++)
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
                    if (prikazySeVsim[i].getArgument1() == int.MaxValue || prikazySeVsim[i].getArgument2() == int.MaxValue)
                    {
                        blokChybaVipis("přiřaď", i + 1);
                        nastalaChyba = true;
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
                    if (jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("přičti 1", i + 1);
                        nastalaChyba = true;
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 2)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("odečti 1", i + 1);
                        nastalaChyba = true;
                        goto konecKompilace;
                    }
                    prikaz.Add(prikazySeVsim[i].getArgument1());
                }
                else if (prikazySeVsim[i].getTyp() == 3) // jump if
                {
                    if ((jeCisloOk(prikazySeVsim[i].getArgument1()) && jeCisloOk(prikazySeVsim[i].getArgument2())
                       && jeCisloOk(prikazySeVsim[i].getArgument3()) && jeCisloOk(prikazySeVsim[i].getArgument4())))
                    {
                        blokChybaVipis("skoč pokud", i + 1);
                        nastalaChyba = true;
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
                        blokChybaVipis("skoč", i + 1);
                        nastalaChyba = true;
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
                        nastalaChyba = true;
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
                        //  MessageBox.Show((jeCisloOk(prikazySeVsim[i].getArgument2()).ToString() + "a jakz cislo si dostal: " + (prikazySeVsim[i].getArgument2())));
                        blokChybaVipis("výstup", i + 1);
                        nastalaChyba = true;
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    //textBox1.Text += "    argument3cb" + (prikazySeVsim[i].getArgument3()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                }
                //...
                else if (prikazySeVsim[i].getTyp() == 7)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument2()) || jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("přičti", i + 1);
                        nastalaChyba = true;
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgument2()).ToString();
                    //textBox1.Text += "  argument1cb" + (prikazy[i][1]).ToString();
                    //textBox1.Text += "  argument2cb" + (prikazy[i][2]).ToString();
                }
                else if (prikazySeVsim[i].getTyp() == 8)
                {
                    if (jeCisloOk(prikazySeVsim[i].getArgument2()) || jeCisloOk(prikazySeVsim[i].getArgument1()))
                    {
                        blokChybaVipis("odečti", i + 1);
                        nastalaChyba = true;
                        goto konecKompilace;
                    }

                    prikaz.Add(prikazySeVsim[i].getArgument1());
                    // textBox1.Text += "    argument1cb" + (prikazySeVsim[i].getArgument1()).ToString();

                    prikaz.Add(prikazySeVsim[i].getArgument2());
                    // textBox1.Text += "    argument2cb" + (prikazySeVsim[i].getArgu
                }


                // ||


                prikazy.Add(prikaz);

                //textBox1.Text += "   typ " + (prikazy[i][0]).ToString();

                konecKompilace:;
                button9.Enabled = !nastalaChyba;
                prikaz = new List<int>();



            }
        }
        private bool uzKompiluji;
        private void kompilovat_Click(object sender, EventArgs e)
        {
            if (uzKompiluji == false)
            {
                kompilovat.Text = "jede";
                beziciProgram.Start();
                uzKompiluji = true;
            }
            else
            {
                kompilovat.Text = "is paused";
                beziciProgram.Suspend();
                uzKompiluji= false;

            }
        }
            ////////precetli jste   Zaznamenani Zmen
        


        //// Provadeni Priakazu
        public static string posledniWinCode = "";
        public void setWinCode(string kod)
        {
            Form1.posledniWinCode = kod;
        }
        private void vyhra()
        {
            setWinCode( vsechnyLevely[aktualniLevel].getWinCode());
            MessageBox.Show("Vyhral jsi: \n opiš kod aktualniho levlu: " + posledniWinCode + ".\n nelze se vratit zpět!","Vyhra");
            aktualniPocetBloku = 0;
            aktualniLevel++;
            if (aktualniLevel > vsechnyLevely.Count())
            {
                MessageBox.Show("Už nezbývají žádné levely", "Totalní výhra");
                aktualniLevel--;
            }
            else
            {
                prikazySeVsim.Clear();
                panel_scrolllll.Controls.Clear();
                konzole.Clear();
                vypisKonzole();
                inputTB.Clear();
                outputTB.Clear();
                /*  String s = "";
                  var vr = Encoding.UTF8.GetBytes(Form1.getJmeno().ToUpper());

                  int k = 0;
                  for (int i = 0; i <vsechnyLevely.Count(); i++)
                  {
                      k += 2;
                      if (k > vr[0].ToString().Count())
                      {
                          k = 0;
                      }
                      s += "\n" + vr[0].ToString().Insert(k, i.ToString()) + (i * 6).ToString();
                  }
                 MessageBox.Show(s);*/
                zadani.Text = vsechnyLevely[aktualniLevel].getZadani();
                pocetProvedenychInstrukci = 0;
                pocetPouzitychPromenych = 0;
            }

            }
        private void button9_Click(object sender, EventArgs e)
        {
            int velikostKrokuInt;
            if (int.TryParse(velikostKroku.Text, out velikostKrokuInt))
            {
                if (velikostKrokuInt == 2522000)
                {
                    vyhra();
                    goto konecProcesovani;
                }
                else if (int.Parse(velikostKroku.Text) > 100)
                {
                    MessageBox.Show("Pocet kroku je moc velky, musi byt pod 100");
                    goto konecProcesovani;

                }

            }
            else
            {
                MessageBox.Show("Nevyplňená kolonka \"počet kroků\"", "Chyba");
                goto konecProcesovani;
            }

            /*else if(vsechnyLevely[aktualniLevel].getPocetZbivajicichVzstupu()+1 == 0)
            {
                MessageBox.Show("Váš program je nejspíš chynný vyčerpal(a) jste všechny vstupy zkuste jej změnit a dat znovu start.","Chyba");
             //   goto konecProcesovani;
            }*/
            for (int i = 0; i < int.Parse(velikostKroku.Text); i++)
            {

                pocetProvedenychInstrukci += 1;
                aktualniRadek += 1;
                //MessageBox.Show("aktualni řádek: " + aktualniRadek.ToString());

                if (aktualniRadek < prikazy.Count)
                {

                    //MessageBox.Show(prikazy[aktualniRadek][0].ToString());

                    if (prikazy[aktualniRadek][0] == 0) // Prirad
                    {
                        int? hodA = vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]);


                        if (hodA == null)
                        {

                            MessageBox.Show("blok přiřaď \n promněnné na řadku" + (aktualniRadek+1) + " nebyla přiřazena hodnota \n tak to program nemuže běžet.", "Kritická chyba");
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
                            MessageBox.Show("blok pricti 1  jedna \n proměnné na řadku" + ((aktualniRadek+1)) + " nebyla přiřazena hodnota \n tak to program nemuže běžet.", "Kritická chyba");

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
                            MessageBox.Show("blok odečti jedna \n proměnné na řadku" + ((aktualniRadek+1)) + " nebyla přiřazena hodnota \n tak to program nemuže běžet.", "Kritická chyba");

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
                       
                        if (kamSkocit < 0 || kamSkocit > prikazy.Count+1)
                        {
                             MessageBox.Show("Nelze skočit na řádek: "+kamSkocit.ToString(),"Chyba!!");
                        }
                        else
                        {                            
                            if (prikazy[aktualniRadek][3] == 1)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) == vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    //MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() +" = "+ vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skočil jsi na " + (aktualniRadek + 2).ToString() + ". řádek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    //MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " = " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());

                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podmínka nesplněna ");
                                    konzole.AppendText(Environment.NewLine);
                                }
                            }
                            else if (prikazy[aktualniRadek][3] == 2)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) < vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    //MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " < " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skočil jsi na " + (aktualniRadek + 2).ToString() + ". řádek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    //MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " < " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podmínka nesplněna ");
                                    konzole.AppendText(Environment.NewLine);
                                }

                            }
                            else if (prikazy[aktualniRadek][3] == 3)
                            {
                                if (vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]) > vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]))
                                {
                                    //MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " > " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    aktualniRadek = kamSkocit - 2;
                                   konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Skočil jsi na " + (aktualniRadek + 2).ToString() + ". řádek"); //po
                                    konzole.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                  //  MessageBox.Show(vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][1]).ToString() + " > " + vsechnyLevely[aktualniLevel].getHodnota(prikazy[aktualniRadek][2]).ToString());
                                    konzole.AppendText(aktualniRadek + 1+". ");
                                    konzole.AppendText("Podminka nesplněna ");
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
                            konzole.AppendText("Skocil jsi na " + (aktualniRadek + 2).ToString() + ". řádek"); //po
                            konzole.AppendText(Environment.NewLine);
                            // MessageBox.Show("aktialni rakde " + aktualniRadek.ToString());
                        }

                    }


                    else if (prikazy[aktualniRadek][0] == 5) // input
                    {

                        int specArgument1 = prikazy[aktualniRadek][1]; // kam
                        int aktualniInput = vsechnyLevely[aktualniLevel].getInput();
                        if (jeCisloOk(aktualniInput))
                        {
                            MessageBox.Show("Váš program je nejspíš chybnný vyčerpal(a) jste všechny vstupy zkuste jej změnit a dat znovu start.", "Chyba");
                            goto konecProcesovani;
                        }
                        vsechnyLevely[aktualniLevel].setHodnota(specArgument1, aktualniInput);
                       
                        //textbox text co se stalo(priradilo se A k B)
                        inputTB.Clear();
                        for (int mocforcylklu = 0; mocforcylklu < vsechnyLevely[aktualniLevel].getInputCely().Count(); mocforcylklu++)
                        {

                            inputTB.AppendText(vsechnyLevely[aktualniLevel].getInputCely()[mocforcylklu].ToString() + "  ");
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

                            MessageBox.Show("blok výstup \n  na řádku" + aktualniRadek + " nebyla přiřazena hodnota \n tak to program nemuže běžet.", "Kritická chyba");
                        }
                        else
                        {
                            outputHrace.Add((int)vsechnyLevely[aktualniLevel].getHodnota(specArgument1));
                           konzole.AppendText(aktualniRadek + 1+". ");
                            konzole.AppendText("Do výstupu bylo přidáno číslo");
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
                                    /*
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
                                    */
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
                            MessageBox.Show("blok odečti pricti na řadku" + aktualniRadek + " nebyla přiřazena hodnota \n tak to program nemuže běžet.", "Kritická chyba");

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
                            MessageBox.Show("blok odečti \n proměnné na řadku" + aktualniRadek + " nebyla přiřazena hodnota \n tak to program nemuže běžet.","Kritická chyba");
                            goto konecProcesovani;
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
            if (textPrijmeni.Enabled == false)
            {
                kompilovat.Enabled = true;
                button9.Enabled = false;
            }
            else
            {
                MessageBox.Show("Neni zadano přijmení", "Přijmení");
            }

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
        public static void setDalsiKrokBool(bool pouzit)
        {
            button9.Enabled = pouzit;
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
            zobrazNapovedu("skoč když", "Když se splní podminka skočí na Vámi zadaný řádek."+
                "\npříklad: 1. pole \"5\" 2. pole \">\" 3. pole (proměnné ale i zadaná čísla) \"2\" 4.pole \"4\" (čísla) \n  " +
                "5 je vetši než 2 takže program pokračuje od 4 řadku \n  " +
                "pokud by byla podminka nepravdiva nic se neděje program \n   pokračuje nasledujícím řádkem.");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("vstup", "Vezme 1. číslo ze vstupu a uložího do proměnné zadané v 1.poli ");
        }

        private void napSkoc_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("skoč", "Vždy skočí na řádek Vámi zadaný v poli");
        }

        private void napPricti1_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("přičti jedna", "K proměnné v 1. poli přičte jedna \n  "+
                "příklad: pole obsahuje \"5\"  vysledna hodnota je 6 (5+1) ");
        }

        private void napOdecti1_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("odečti jedna", "Od proměnné v 1. poli odečte jedna \n  " +
                "příklad: pole obsahuje \"6\"  vysledna hodnota je 5 (6-1) ");
        }

        private void napVystup_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("výstup", "Vezme čislo z proměnné zadané v 1. poli ale také příjmá čísla 0 a 1 \n  " +
                "poté je dá do výstupu ");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("přiřaď", "Proměnnou napsanou 1. poli nahradí hodnoutou proměnné v 2. poli \n"+
                "příklad: A=1 B=5 1.pole \"A\" 2. pole \"5\" \n   vysledne hodnoty  A =5 B=5");
        }

        private void napPricti_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("příčti", "K promněnne v 1. poli příčte proměnnou nebo čislo z 2. pole \n" +
                "příklad:(proměnná)  A=6 1.pole obsahuje \"A= 6\" (proměnná) B=5 2.pole \"B=5\"  vysledna hodnota je \"A= 11\"  (5+6), \"B= 5.\" ");
        }

        private void napOdecti_Click(object sender, EventArgs e)
        {
            zobrazNapovedu("příčti", "Od proměnné v 1. poli odečte proměnnou nebo čislo z 2. pole \n" +
                "příklad: (proměnná A=6) 1.pole obsahuje \"A\" (proměnná B=5) 2.pole \"B\"  vysledna hodnota  \"A = -1\"  (5-6), \"B= 5.\" ");
        }

        private void skocKdyzLabel_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void skocLabel_MouseClick(object sender, MouseEventArgs e)
        {
        
        }

        private void pricti1Label_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void odecti1Label_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void vstupLabel_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void vystupLabel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void priradLabel_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

       

        private void odectiLabel_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
          //  MessageBox.Show("Je povino vyplnit pole přijmení jinak nebude vaše skore hodnoceno. \nPo spuštení vašeho programu se do vstupu napíšou náhodná čísla, vaším úkolem bude vzít tato čísla, provést s nimi požadovanou operaci (napsana v zadání) a dát výsledný číslo do vstupu.\n Program se píše takhle - na pravo se nachází příkazove bloky ze kterých se bude skladat vas program. Do bloků je povoleno zadavat pouze proměnné (A,B,C,D,E,F) až na vyjímky - do výstupu lze zadat aji 0 a 1, a do \"skoč když\"do třetího pole(po porovnacim poli) lze zadat i jakekoli čislo. Proměnné ve vyplňovacím poli říkají, do jaké proměnné se ma číslo uložit nebo z jaké proměnné vzít hodnotu.\n Svuj program spustíš kliknutím na \"start\". Poté, se vygenerují nahodná čisla do kolonky \"Vstup \" (vlevo uprostred).\nPříkaz vstup uloží do proměnné (krerou jste zadali do vyplňovacího pole) první číslo ze vstupu. Když příkaz vstup použijete znova, ulozi se 2. cislo ze vstupu, a tak dál.\nPříkaz výstup dá do výstupu hodnotu z promene, kterou jste zadali do vyplnovaciho pole.\nPříkaz skoc kdyz porovna dve promeny (nebo promenou s cislem), a pokud a vzorec bude pravdivy, program se bude cist od radku, ktery je napsan ve 4.poli, pokud neni pravdivy, program pokracuje dal.\nDalší vysvětlení jednotlivych prikazu muzete zobrazit kliknutim na otaznik vedle příkazů ", "Zakldani informace");
            MessageBox.Show("Tato aplikace slouží k programovaní zadaných úkolu pomoci jednoduchých bloku. Ty jsou umístěny na pravé straně. Kliknutím na ně je umístíte doprostřed a vytvoříte blokové schema programu podle zadání vlevo. Vyplňte příjmení. Pokud bude program správně, postupujete do dalšího levelu. Proměnné požíváte A-F, konstanty lze psát jen do bloku \"skoč když\" a \"výstup\". Svůj program spustíme kliknutiím na tlačítko \"Start\", poté se do kolonky vstup (vlevo uprostřed) vygenerují nahodná čísla, se kterými bude Váš program pracovat. Pěknou zábavu!", "Základní informace");
        }

        private void prijmeni_TextChanged(object sender, EventArgs e)
        {
            if (prijmeni.Text == "")
            {
                prijmeni.BackColor = Color.Red;

                kompilovat.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                prijmeni.BackColor = Color.WhiteSmoke;
            }
        }

        private void textPrijmeni_Click(object sender, EventArgs e)
        {
            if (prijmeni.Text == "")
            {
                prijmeni.BackColor = Color.Red;
                textPrijmeni.BackColor = Color.Red;
                kompilovat.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                jmeno = prijmeni.Text[0].ToString().ToUpper();
                textPrijmeni.Visible = false;
                textPrijmeni.Enabled = false;
                prijmeni.Visible = false;
                prijmeni.Enabled = false;
                label2.Enabled = false;
                label2.Visible = false;
               
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    

        private void napovedaDebug_Click_1(object sender, EventArgs e)
        {
            zobrazNapovedu("aktualní hodnoty programu", "zobrazuje číslo řádku který se zrovna provádí a změnu kterou tento řádek provedl. \n "+
                "A vypisuje hodnoty vašich proměnných.");

        }

        private void vystupLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(6);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            everyBtnClick(0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            everyBtnClick(1);
        }

        private void prictiLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(7);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            everyBtnClick(3);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            everyBtnClick(3);
        }

        private void skocKdyzLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(3);
        }

        private void skocLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(4);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            everyBtnClick(4);
        }

        private void pricti1Label_Click(object sender, EventArgs e)
        {
            everyBtnClick(1);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            everyBtnClick(2);
        }

        private void odecti1Label_Click(object sender, EventArgs e)
        {
            everyBtnClick(2);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            everyBtnClick(5);
        }

        private void vstupLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(5);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            everyBtnClick(6);
        }

        private void priradLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(0);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            everyBtnClick(7);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            everyBtnClick(8);
        }

        private void odectiLabel_Click(object sender, EventArgs e)
        {
            everyBtnClick(8);
        }

        private void pricti_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prictiLabel_MouseClick_1(object sender, MouseEventArgs e)
        {

        }
    }
}
