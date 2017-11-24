using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                pozadi.Controls.Add(nazevPrikazu);
                form.Controls.Add(pozadi);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump if";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                //20,15 200,65
                pozadi.SetBounds(20, 15, 200, 65);
                pozadi.BackColor = Color.FromArgb(255, 0, 0, 255);
                // promena1.SetBounds(25, 20, 40, 20);
                //  promena1.BackColor = Color.FromArgb(255, 0, 0, 0);
                //form.Controls.Add(promena1);
                //promena1.Location = new Point(5, 5);
                //promena1 = new ComboBox();
                int offset = 0;
                promena1.Text = "-";
                promena1.Size = new Size(30, 00);
                promena1.Location = new Point( 20, 32);
                pozadi.Controls.Add(promena1);

                promena2.Text = "-";
                promena2.Items.Add("=");
                promena2.Items.Add("<");
                promena2.Items.Add(">");
                promena2.Size = new Size(30, 00);
                promena2.Location = new Point(60, 32);
                pozadi.Controls.Add(promena2);

                promena3.Text = "-";
                promena3.Size = new Size(30, 00);
                promena3.Location = new Point((50*2)+ offset,32 );
                pozadi.Controls.Add(promena3);


                promena4.Text = "-";
                promena4.Size = new Size(30, 00);
                promena4.Location = new Point((60*2) + 30, 32 );
                pozadi.Controls.Add(promena4);
             
                //  pozadi.Click += new EventHandler(pozadi_click);
               pozadi.Click += (s, e) => {
                   MessageBox.Show("Click");
               };

                /*

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
