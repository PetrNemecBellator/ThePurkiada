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
            pk.setsdebugLayText();
        }
    }
}
