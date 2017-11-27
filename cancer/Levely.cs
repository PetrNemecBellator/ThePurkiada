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
        int? hodnotaA = null;
        int? hodnotaB = null;
        int? hodnotaC = null;
        int? hodnotaD = null;
        int? hodnotaE = null;
        int? hodnotaF = null;
        public Levely(int aktualniLevel)
        {
            if (aktualniLevel == 1)
            {
                input.Add(7);
                input.Add(2);

            }
            else if (aktualniLevel == 2)
            {
                input.Clear();
                input.Add(8);
                input.Add(5);

            }
        }

        public int? getHodnotaA()
        {
            return this.hodnotaA;
        }
        public int? getHodnotaB()
        {
            return this.hodnotaB;
        }
        
        public int? getHod(List<List<int>>  prikazy, int i)
        {
            if (prikazy[i][1] == 1)
                return this.hodnotaA;
        }

        //////////
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
