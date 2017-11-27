using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace noMansResourceMachine
{
    public partial class Form1 : Form
    {
        
        List<List<int>> prikazy = new List<List<int>>();
        List<int> prikaz = new List<int>();
        List<PrikazZobrazeni> prikazySeVsim = new List<PrikazZobrazeni>();
        Levely[] vsechnyLevly = new Levely [2];
        int aktualniLevel = 1;

        public Form1()
        {
            InitializeComponent();
            PrikazZobrazeni pk = new PrikazZobrazeni(0, 0, this);
            prikazySeVsim.Add(pk);
            PrikazZobrazeni pk2 = new PrikazZobrazeni(50, 0, this);
            prikazySeVsim.Add(pk2);
            Levely level1 = new Levely(aktualniLevel);



        }

        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kompilovat_Click(object sender, EventArgs e)
        {
            // Zaznamenani Zmen ///////////////////
            prikazy.Clear();
            textBox1.Clear();

            for (int i = 0; i < prikazySeVsim.Count; i++)
            {
                
                prikaz.Add(prikazySeVsim[i].getTyp());
                textBox1.Text +="typ "+ ( prikazySeVsim[i].getTyp()).ToString();
                prikaz.Add(prikazySeVsim[i].getPromenaA());
                textBox1.Text += "argument1" + (prikazySeVsim[i].getPromenaA()).ToString();
                prikaz.Add(prikazySeVsim[i].getPromenaB());
                textBox1.Text += "argument2" +(prikazySeVsim[i].getPromenaB()).ToString();

                prikazy.Add(prikaz);
                prikaz.Clear();

            }
            // Zaznamenani Zmen ///////////////////   

            for (int i = 0; i < prikazy.Count; i++)
            {
                
                if (prikazy[i][0] == 0)  // Prirad
                {
                    if (prikazy[i][1] == 1) // A
                    {
                        
                        vsechnyLevly[aktualniLevel].setHodnotaA(prikazy[i][getHod(prikazy, i)]);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
