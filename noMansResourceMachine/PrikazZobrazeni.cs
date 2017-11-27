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
            blok.Top = (posY);
            blok.Left = (20);
            if (this.typ == 0) // prirad
            {

                form.Controls.Add(blok);
                blok.Controls.Add(argument1);
                blok.Controls.Add(argument2);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(142, 158, 41);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 142, 158, 41);
                this.nazevPrikazu.Text = "<--Přiřaď";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1.SetBounds(10, 25, 30, 30);
                this.argument2.SetBounds(160, 25, 30, 30);

                //  this.nazevPrikazu.Text = argument1.GetItemText(this.argument1.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                form.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1);

                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1.Text = "-";
                this.argument1.Size = new Size(30, 00);
                this.argument1.Location = new Point(10,20);
                this.blok.Controls.Add(argument1);

                


                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(55, 15, 100, 30);

            }
            else if (this.typ == 2) // zmensi o 1
            {
                form.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1);

                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1.Text = "-";
                this.argument1.Size = new Size(30, 00);
                this.argument1.Location = new Point(10, 25);
                this.blok.Controls.Add(argument1);

                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(55, 25, 120, 40);

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
            else if (typ == 4)// jump
            {
                blok.Controls.Add(nazevPrikazu);
                form.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
               
                blok.Top = (posY);
                blok.Left = (20);
                blok.BackColor = Color.FromArgb(255, 0, 0, 255);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument1);
            }else if (typ == 5) // input
            {
                blok.Controls.Add(nazevPrikazu);
                form.Controls.Add(blok);
                nazevPrikazu.SetBounds(5, 20, 80, 30);
                nazevPrikazu.Text = "vstup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);

              
                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point((60 * 2) + 30, 25);
                blok.Controls.Add(argument1);
            }else if(typ == 6)// output
            {
                blok.Controls.Add(nazevPrikazu);
                form.Controls.Add(blok);
                blok.Controls.Add(argument1);

                nazevPrikazu.SetBounds(5, 20, 80, 30);
                nazevPrikazu.Text = "vystup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point((60 * 2) + 30, 25);
            }else if (typ == 7)
            {

                form.Controls.Add(blok);
                blok.Controls.Add(argument1);
                blok.Controls.Add(argument2);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(255, 178, 30, 30);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "<--pricti";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1.SetBounds(10, 25, 30, 30);
                this.argument2.SetBounds(160, 25, 30, 30);
            }
            else if(typ == 8)
            {

                form.Controls.Add(blok);
                blok.Controls.Add(argument1);
                blok.Controls.Add(argument2);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(255, 178, 30, 30);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "<--odecti";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1.SetBounds(10, 25, 30, 30);
                this.argument2.SetBounds(160, 25, 30, 30);
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
