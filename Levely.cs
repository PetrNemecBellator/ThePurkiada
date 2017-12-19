using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noMansResourceMachine
{

    class Levely                                      
    {
        List<int> input = new List<int>();
        List<int> output = new List<int>();
        int? hodnotaA = null;
        int? hodnotaB = null;
        int? hodnotaC = null;
        int? hodnotaD = null;
        int? hodnotaE = null;
        int? hodnotaF = null;
        int min;
        int max;
        static Random rnd = new Random();

        public Levely(int aktualniLevel, int min,int max)  // vsechny zadani: vynasob A s B, z 20 udelej 5, vynasob vstup sestnacti ,
        {
            this.min = min;
            this.max = max;
            input.Add(rnd.Next(min, max));
            input.Add(rnd.Next(min, max));
            if (aktualniLevel == 0)
            {
                output.Add(input[1]);
                output.Add(input[0]);
                this.hodnotaA = 3;
                this.hodnotaB = 5;
                this.hodnotaC = -9;
                this.hodnotaD = 71000;

            }
            else if (aktualniLevel == 1)
            {
                input.Clear();
                input.Add(8);
                input.Add(5);
                
            }
        }
        public int getMin()
        {
            return this.min;
        }
        public int getMax()
        {
            return this.max;
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
