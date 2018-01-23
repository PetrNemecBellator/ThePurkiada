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

            input.Clear();

            if (aktualniLevel == 0)
            {
                maxPocetRadku = 4;
                maxPocetPrvedenychInstrukci = 4;
                maxPocetPromenych = 2;
                typVstupu = "2 jakákoli čísla";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Na vstupu jsou dvě čisla, dej je do výstupu v obraceném pořadí (např.: vstup: 5;3 výstup: 3;5) (použij pouze bloky vstup a výstup)@Typ vstupu: " + typVstupu + " @@Maximalní počet řádků: " + maxPocetRadku + "@Maximalní počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(-99, -1));
                input.Add(rnd.Next(0, 99));
                output.Add(input[1]);
                output.Add(input[0]);
                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;

            }
            else if (aktualniLevel == 1)
            {
                maxPocetRadku = 3;
                maxPocetPrvedenychInstrukci = 31;
                maxPocetPromenych = 1;
                typVstupu = "10 jakýchkoli čísel";
                zadaniText = "Level "+(aktualniLevel+1) +": Do výstpu dej všechna čisla z vstupu (např.: vstup: 5,3,8,... výstup: 5,3,8,...) (použij blok skoč)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych ;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);


                for (int i = 0; i < 10; i++)
                {

                    input.Add(rnd.Next(0, 999));
                    output.Add(input[i]);

                }

                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }
            else if (aktualniLevel == 2) // netstovano
            {
                maxPocetRadku = 6;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 1;
                typVstupu = "10 jakýchkoliv čísel";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Pokud je na vstupu číslo menší než 0, do výstupu dej 0. Pokud je na vstupu čislo větší nebo rovno nule, do výstupu dej 1@(např.: vstup: 8,-5,-8,0,54,-1,... výstup: 1,0,0,1,1,0,...)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych ;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);

                for (int i = 0; i < 10; i++)
                {
                    int nahoda = rnd.Next(0, 3);
                    if (nahoda == 0)
                    {
                        input.Add(rnd.Next(-10, 0));
                        output.Add(0);
                    }
                    else if (nahoda == 1)
                    {
                        input.Add(rnd.Next(0, 1));
                        output.Add(1);
                    }
                    else
                    {
                        input.Add(rnd.Next(1, 10));
                        output.Add(1);
                    }
                }
               
                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }

            else if (aktualniLevel == 3) //neeeeeeeeeeeeeeeeeeeeeee
            {
                maxPocetRadku = 5;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 1;
                typVstupu = "5 čísel od 5 do 10";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Odpočet (např.: vstup: 5,3 výstup: 5,4,3,2,1, 3,2,1)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych + "@Kód od předchozího levelu:" + Form1.posledniWinCode;;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                for (int j = 0; j < 5; j++)
                {
                    int nahoda = rnd.Next(5, 8);
                    input.Add(nahoda);

                    for (int i = nahoda; i > 0; i--)
                    {
                        output.Add(i);
                    }
                }
                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }
            else if (aktualniLevel == 4)
            {
                maxPocetRadku = 7;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 2;
                typVstupu = "10 čísel od -99 do 99";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Do výstupu dej absolutní hodnotu vstupu (od záporneho čísla odstraň mínus a kladné ponechej) (např.: vstup: 8,-5,0,-1,35,... výstup: 8,5,0,1,35,...)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych ;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);

                for (int i = 0; i < 10; i++)
                {
                    input.Add(rnd.Next(-99, 99));
                }

                for (int i = 0; i < 10; i++)
                {
                    output.Add(Math.Abs(input[i]));
                }

                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }
            else if (aktualniLevel == 5) // netestovano
            {
                maxPocetRadku = 999;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 999;
                typVstupu = "10 čísel od 0 do 20";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Pokud je na vstupu sudé číslo, do výstupu dej 0, pokud liché, do výstupu dej 1 (např.: vstup: 5,8,1,... výstup: 1,0,1,...)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych ;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                for (int i = 0; i < 10; i++)
                {
                    input.Add(rnd.Next(1, 20));
                }
                for (int i = 0; i < 10; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        output.Add(0);
                    }
                    else
                    {
                        output.Add(1);
                    }
                }

                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }

            else if (aktualniLevel == 6)
            {
                maxPocetRadku = 999;
                maxPocetPrvedenychInstrukci = 6;
                maxPocetPromenych = 999;
                typVstupu = "jedno jakékoli číslo ";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Do vystupu dej vstup vynásobený šestnácti (např.: vstup: 3 výstup: 42)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych + "@Kód od předchozího levelu:" + Form1.posledniWinCode;;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(3, 7));

                output.Add(input[0] * 16);

                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;

            }
            else if (aktualniLevel == 7)
            {
                maxPocetRadku = 7;
                maxPocetPrvedenychInstrukci = 999;
                maxPocetPromenych = 3;
                typVstupu = "dvě jakakoli čísla vyšší než 1";
                zadaniText = "Level " + (aktualniLevel + 1) + ": Do výstupu dej první číslo ze vstupu vynásobeny druhým číslem ze vstupu (např.: vstup: 5;3 výstup: 15)@Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych ;
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
                input.Add(rnd.Next(2, 9));
                input.Add(rnd.Next(2, 9));
                output.Add(input[0] * input[1]);
                this.hodnotaA = 0;
                this.hodnotaB = 0;
                this.hodnotaC = 0;
                this.hodnotaD = 0;
                this.hodnotaE = 0;
                this.hodnotaF = 0;


            }else if (aktualniLevel == 8)
            {
                maxPocetRadku = -1;
                maxPocetPrvedenychInstrukci = 404;
                maxPocetPromenych = 42;
                typVstupu = "404";
                zadaniText = "Vyhráli jste!!! @Typ vstupu: " + typVstupu + " @@Maximalni počet řádků: " + maxPocetRadku + "@Maximalni počet provedených instrukcí: " + maxPocetPrvedenychInstrukci + "@Maximalni počet použitých proměných: " + maxPocetPromenych + "@Kód od předchozího levelu:" + Form1.posledniWinCode.ToString();
                zadaniText = zadaniText.Replace("@", System.Environment.NewLine);
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
            //MessageBox.Show(k.ToString() + " " + aktualniLevel);
            return  vr[0].ToString().Insert(k, aktualniLevel.ToString()) + (aktualniLevel * 6).ToString();


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
        public int getPocetZbivajicichVzstupu()
        {
           return this.input.Count();
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
