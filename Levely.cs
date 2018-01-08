using System;
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

      private  int? hodnotaA = null;
      private int? hodnotaB = null;
      private  int? hodnotaC = null;
      private  int? hodnotaD = null;
      private int? hodnotaE = null;
      private  int? hodnotaF = null;

        private static Random rnd = new Random();

        public Levely(int aktualniLevel)  // vsechny zadani: vynasob A s B, z 20 udelej 5, vynasob vstup sestnacti ,
        {
            input.Clear();

            if (aktualniLevel == 0)
            {
                maxPocetRadku = 4;
                maxPocetPrvedenychInstrukci = 4;
                maxPocetPromenych = 2;
                typVstupu = "jakekoli cislo";
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
            else if (aktualniLevel == 1)
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
                this.hodnotaA = null;
                this.hodnotaB = null;
                this.hodnotaC = null;
                this.hodnotaD = null;
                this.hodnotaE = null;
                this.hodnotaF = null;


            }
            else if (aktualniLevel == 2)
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
            int x = this.input[0];
            this.input.RemoveAt(0);
            return x;
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
            if (argument1 == 1)
                return this.hodnotaA;
            else if (argument1 == 2)
                return this.hodnotaB;
            else if (argument1 == 3)
                return this.hodnotaC;
            else if (argument1 == 4)
                return this.hodnotaD;
            else if (argument1 == 5)
                return this.hodnotaE;
            else if (argument1 == 6)
                return this.hodnotaF;
            else if (argument1 == 0)
                return getInput();

            else
                return null;

        }

        public void setHodnota(int argument2, int operacaniHodnota)
        {
            if (argument2 == 1)
                this.hodnotaA = operacaniHodnota;
            //textBox2.Text += "Hodnota promene A se zmenila na ";
            else if (argument2 == 2)
                this.hodnotaB = operacaniHodnota;
            else if (argument2 == 3)
                this.hodnotaC = operacaniHodnota;
            else if (argument2 == 4)
                this.hodnotaD = operacaniHodnota;
            else if (argument2 == 5)
                this.hodnotaE = operacaniHodnota;
            else if (argument2 == 6)
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
