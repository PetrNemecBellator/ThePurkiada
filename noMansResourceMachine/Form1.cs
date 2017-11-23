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
        Prikaz pk;//= new Prikaz(0, 0, this);
        ArrayList prikazy = new ArrayList();
        Panel panel = new Panel();
        public Form1()
        {
            InitializeComponent();
            pk = new Prikaz(0, 0, this);
        

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kompilovat_Click(object sender, EventArgs e)
        {
            Prikaz ifl = new Prikaz(0, 3, this);
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
