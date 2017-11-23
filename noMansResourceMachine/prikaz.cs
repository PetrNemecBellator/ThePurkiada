using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace noMansResourceMachine
{
    class Prikaz
    {
        private int posY;
        
        public Label nazevPrikazu = new Label();
        private int typ;
        private Panel pozadi = new Panel();
        public ComboBox promena1 = new ComboBox();
        public ComboBox promena2 = new ComboBox();
        public ComboBox promena3 = new ComboBox();
        public ComboBox promena4 = new ComboBox();
        
        public Prikaz(int PosY, int typ,Form form)
        {
            this.posY = PosY;
            this.typ = typ;
            if (this.typ == 0) // prirad
            {
              
                form.Controls.Add(promena1);
                form.Controls.Add(promena2);
                this.nazevPrikazu.Text = "Přiřaď";
                this.nazevPrikazu.SetBounds(10, posY + 8, 50,30);
                this.promena1.SetBounds(100, posY, 30, 30);
                this.promena2.SetBounds(160, posY, 30, 30);
                promena1.Items.Add("ahoj");
                promena1.Items.Add("programovani de skvele");
              //  this.nazevPrikazu.Text = promena1.GetItemText(this.promena1.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.promena1.SetBounds(60, posY, 50, 30);
              
            }
            else if (this.typ == 2) // prirad
            {
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.promena1.SetBounds(60, posY, 50, 30);
                
            }
            else if (this.typ == 3)//jump if
            {
                form.Controls.Add(nazevPrikazu);
                form.Controls.Add(pozadi);
                nazevPrikazu.SetBounds(20, 18, 65, 50);
                nazevPrikazu.Text = "jump if";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                pozadi.SetBounds(20, 15, 200, 65);
                pozadi.BackColor = Color.FromArgb(255, 0, 0, 255);
                // form.Controls.Add(promena1);
                pozadi.Controls.Add(promena1);
                promena1.SetBounds(25, 20, 20, 20);
                promena1.BackColor = Color.FromArgb(255, 255, 255, 255);/*

        public ComboBox promena2 = new ComboBox();
        public ComboBox promena3 = new ComboBox();
        public ComboBox promena4 = new ComboBox();/*/
    }

        }
        public void setsdebugLayText()
        {
            this.nazevPrikazu.Text = this.promena1.GetItemText(this.promena1.SelectedItem);
        }
    }
}
