﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noMansResourceMachine
{

    class Levely                                      
    {
      private  List<int> input = new List<int>();
      private  List<int> output = new List<int>();
      private  string zadaniText;
      private  string typVstupu;
      private  int maxPocetRadku = 0;
      private  int maxPocetPrvedenychInstrukci = 0;
      private  int maxPocetPromenych = 0;

      private  int? hodnotaA;
      private int? hodnotaB;
      private  int? hodnotaC;
      private  int? hodnotaD;
      private int? hodnotaE;
      private  int? hodnotaF;

        private int aktualniLevel;

        private static Random rnd = new Random();

        public Levely(int aktualniLevel)  // vsechny zadani: vynasob A s B, z 20 udelej 5, vynasob vstup sestnacti ,
        {
            input.Clear();
            this.aktualniLevel = aktualniLevel ;

            if (aktualniLevel == 0)
            {
                maxPocetRadku = 4;
                maxPocetPrvedenychInstrukci = 4;
                maxPocetPromenych = 2;
                typVstupu = "pouze dve cisla";
                zadaniText = "Do vystupu dej vstup v obracenem poradi (napr.: vstup: 5;3 vystup: 3;5)@Typ vstupu:" + typVstupu + " @@Maximalni pocet radku: " + maxPocetRadku + "@Maximalni pocet provadenych instrukci: " + maxPocetPrvedenychInstrukci + "@Maximalni pocet pouzitich promenych: " + maxPocetPromenych;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(-999, 999));
                input.Add(rnd.Next(-999, 999));
                output.Add(input[1]);
                output.Add(input[0]);
                this.hodnotaA = null;
                this.hodnotaB = null;
                this.hodnotaC = null;
                this.hodnotaD = null;
                this.hodnotaE = null;
                this.hodnotaF = null;

            }
            else if (aktualniLevel == 0)
            {
                maxPocetRadku = 10;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 1;
                typVstupu = "10 cisel od 0 do 12 ";
                zadaniText = "Pokud je cislo sudy, tak dej do vystupu 0, pokud lichy, do vystupu dej 1 (napr.: vstup: 5,8,1,... vystup: 1,0,1,...)@Typ vstupu:" + typVstupu + " @@Maximalni pocet radku: " + maxPocetRadku + "@Maximalni pocet provadenych instrukci: " + maxPocetPrvedenychInstrukci + "@Maximalni pocet pouzitich promenych: " + maxPocetPromenych;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                for(int i = 0; i < 10; i++)
                {
                    input.Add(rnd.Next(1, 12));
                }
                
                for(int i =0; i < 10;i++)
                {
                    if(input[i] % 2 == 0)
                    {
                        output.Add(0);
                    }else
                    {
                        output.Add(1);
                    }
                    
                    
                }
                

                this.hodnotaA = null;
                this.hodnotaB = null;
                this.hodnotaC = null;
                this.hodnotaD = null;
                this.hodnotaE = null;
                this.hodnotaF = null;
                
            }
            else if (aktualniLevel == 6)
            {
                maxPocetRadku = 8;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 3;
                typVstupu = "jakekoli cislo od dvou";
                zadaniText = "Do vystupu dej prvni cislo ze vstupu vynasobeny druhym cislem ze vstupu (napr.: vstup: 5;3 vystup: 15)@Typ vstupu:" + typVstupu + " @@Maximalni pocet radku: " + maxPocetRadku + "@Maximalni pocet provadenych instrukci: " + maxPocetPrvedenychInstrukci + "@Maximalni pocet pouzitich promenych: " + maxPocetPromenych;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(2, 7));
                input.Add(rnd.Next(2, 7));
                output.Add(input[0] * input[1]);
                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }
            else if (aktualniLevel == 5)
            {
                maxPocetRadku = 999;
                maxPocetPrvedenychInstrukci = 6;
                maxPocetPromenych = 999;
                typVstupu = "jakekoli cislo ";
                zadaniText = "Do vystupu dej vynasobeny sestnacti (napr.: vstup: 3 vystup: 42)@Typ vstupu:" + typVstupu + " @@Maximalni pocet radku: " + maxPocetRadku + "@Maximalni pocet provadenych instrukci: " + maxPocetPrvedenychInstrukci + "@Maximalni pocet pouzitich promenych: " + maxPocetPromenych;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(3, 7));

                output.Add(input[0] * 16);

                this.hodnotaA = null;
                this.hodnotaB = null;
                this.hodnotaC = null;
                this.hodnotaD = null;
                this.hodnotaE = null;
                this.hodnotaF = null;

            }
        }
        public string getZadani()
        {
            return this.zadaniText;
        }
        public int getMaxPocetRadku()
        {
            return this.maxPocetRadku;
        }
        public int getMaxPocetInstrukci()
        {
            return this.maxPocetPrvedenychInstrukci;
        }
        public int getMaxPocetPromenych()
        {
            return this.maxPocetPromenych;
        }
        public int getInput()
        {
            if (this.input.Count == 0) {
                MessageBox.Show("došli inputy nemužeš brat další čísla", "Chyba");
                return int.MaxValue;
            }
            int x = this.input[0];
            this.input.RemoveAt(0);
            return x;
        }
        public static int k = 0;
        public string getWinCode()
        {
            /*

                        var vr = Encoding.UTF8.GetBytes(Form1.getJmeno().ToUpper());
                        string s = "";
                        int k = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            k += 2;
                            if (k > vr[0].ToString().Count())
                            {
                                k = 0;
                            }
                            s += "\n" + vr[0].ToString().Insert(k, i.ToString()) + (i * 6).ToString();
                        }



                         */
            var vr = Encoding.UTF8.GetBytes(Form1.getJmeno().ToUpper());
            string s = "";
            

                k += 2;
                if (k > vr[0].ToString().Count())
                {
                    k = 0;
                }
            MessageBox.Show(k.ToString() + " " + aktualniLevel);
            return "\n" + vr[0].ToString().Insert(k, aktualniLevel.ToString()) + (aktualniLevel * 6).ToString();


        }
        public List<int> getInputCely()
        {

            return this.input;
        }

        public List<int> getOutput()
        {

            return output;
        }


        public int? getHodnota(int argument1)
        {
            if (argument1 == int.MaxValue - 1)
                return this.hodnotaA;
            else if (argument1 == int.MaxValue - 2)
                return this.hodnotaB;
            else if (argument1 == int.MaxValue - 3)
                return this.hodnotaC;
            else if (argument1 == int.MaxValue - 4)
                return this.hodnotaD;
            else if (argument1 == int.MaxValue - 5)
                return this.hodnotaE;
            else if (argument1 == int.MaxValue - 6)
                return this.hodnotaF;                    

            else
                return argument1;

        }

        public void setHodnota(int argument2, int operacaniHodnota)
        {
        
            if (argument2 == int.MaxValue-1)
                this.hodnotaA = operacaniHodnota;
            //textBox2.Text += "Hodnota promene A se zmenila na ";
            else if (argument2 == int.MaxValue - 2)
                this.hodnotaB = operacaniHodnota;
            else if (argument2 == int.MaxValue - 3)
                this.hodnotaC = operacaniHodnota;
            else if (argument2 == int.MaxValue - 4)
                this.hodnotaD = operacaniHodnota;
            else if (argument2 == int.MaxValue - 5)
                this.hodnotaE = operacaniHodnota;
            else if (argument2 == int.MaxValue - 6)
                this.hodnotaF = operacaniHodnota;

        }

        //////////////////////get///////
        public int? getHodnotaA()
        {
            return this.hodnotaA;
        }
        public int? getHodnotaB()
        {
            return this.hodnotaB;
        }
        public int? getHodnotaC()
        {
            return this.hodnotaC;
        }
        public int? getHodnotaD()
        {
            return this.hodnotaD;
        }
        public int? getHodnotaE()
        {
            return this.hodnotaE;
        }
        public int? getHodnotaF()
        {
            return this.hodnotaF;
        }

        // ////////////////set/////////

        public void setHodnotaA(int hodnotaA)
        {
            this.hodnotaA = hodnotaA;
        }
        public void setHodnotaB(int hodnotaB)
        {
            this.hodnotaB = hodnotaB;
        }
        public void setHodnotaC(int hodnotaC)
        {
            this.hodnotaC = hodnotaC;
        }
        public void setHodnotaD(int hodnotaD)
        {
            this.hodnotaD = hodnotaD;
        }
        public void setHodnotaE(int hodnotaE)
        {
            this.hodnotaE = hodnotaE;
        }
        public void setHodnotaF(int hodnotaF)
        {
            this.hodnotaF = hodnotaF;
        }


    }


}
