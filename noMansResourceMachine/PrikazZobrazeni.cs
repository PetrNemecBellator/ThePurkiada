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
    class PrikazZobrazeni
    {
        private int posY;

        public Label nazevPrikazu = new Label();
        private int typ;
        public ComboBox argument1 = new ComboBox();
        public ComboBox argument2 = new ComboBox();
        public ComboBox argument3 = new ComboBox();
        public ComboBox argument4 = new ComboBox();
        private Panel blok = new Panel();

        public PrikazZobrazeni(int PosY, int typ,Form form)
        {
            this.posY = PosY;
            this.typ = typ;
            blok.Width = 200;
            blok.Height = 65;
            if (this.typ == 0) // prirad
            {
              
                form.Controls.Add(argument1);
                form.Controls.Add(argument2);
                this.nazevPrikazu.Text = "Přiřaď";
                this.nazevPrikazu.SetBounds(10, posY + 8, 50,30);
                this.argument1.SetBounds(100, posY, 30, 30);
                this.argument2.SetBounds(160, posY, 30, 30);
                argument1.Items.Add("ahoj");
                argument1.Items.Add("programovani de skvele");
              //  this.nazevPrikazu.Text = argument1.GetItemText(this.argument1.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.argument1.SetBounds(60, posY, 50, 30);
              
            }
            else if (this.typ == 2) // prirad
            {
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.argument1.SetBounds(60, posY, 50, 30);
                
                //String.Format("dsaf {0}", posY);
                
            }
            else if (this.typ == 3)//jump if
            {
                blok.Controls.Add(nazevPrikazu);
                form.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump if";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                //20,15 200,65
                //   blok.SetBounds(20, posY, 200, 65);
                blok.Top = (posY);
                blok.Left = (20);
                blok.BackColor = Color.FromArgb(255, 0, 0, 255);
                int offset = 0;
                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point( 20, 32);
                blok.Controls.Add(argument1);

                argument2.Text = "-";
                argument2.Items.Add("=");
                argument2.Items.Add("<");
                argument2.Items.Add(">");
                argument2.Size = new Size(30, 00);
                argument2.Location = new Point(60, 32);
                blok.Controls.Add(argument2);

                argument3.Text = "-";
                argument3.Size = new Size(30, 00);
                argument3.Location = new Point((50*2)+ offset,32 );
                blok.Controls.Add(argument3);


                argument4.Text = "-";
                argument4.Size = new Size(30, 00);
                argument4.Location = new Point((60*2) + 30, 32 );
                blok.Controls.Add(argument4);
             
                //  blok.Click += new EventHandler(blok_click);
               blok.Click += (s, e) => {
                   MessageBox.Show("Click");
               };

                

            }
            else if (typ == 4)
            {
                blok.Controls.Add(nazevPrikazu);
                form.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                //20,15 200,65
                //idealni roytex 85 (y)
                //blok.SetBounds(20, posY, 200, 65);
                blok.Top = (posY);
                blok.Left = (20);
                blok.BackColor = Color.FromArgb(255, 0, 0, 255);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument1);
            }

        }
        public void setsdebugLayText()
        {
            this.nazevPrikazu.Text = this.argument1.GetItemText(this.argument1.SelectedItem);
        }
        public int getTyp()
        {
            return this.typ;
        }

        public int getPromenaA()
        {
            if ('A' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 1;
            else if ('B' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 2;
            else if ('C' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 3;
            else if ('D' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 4;
            else if ('E' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 5;
            else if ('F' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
                return 6;
            else
                return 7;

        }
        public int getPromenaB()
        {
            if ('A' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 1;
            else if ('B' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 2;
            else if ('C' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 3;
            else if ('D' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 4;
            else if ('E' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 5;
            else if ('F' == char.Parse(this.argument2.GetItemText(this.argument2.SelectedItem)))
                return 6;
            else
                return 7;
        }


    }
}
