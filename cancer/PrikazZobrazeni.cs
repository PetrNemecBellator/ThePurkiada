using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (this.typ == 0) // prirad
            { 
                
                form.Controls.Add(nazevPrikazu);
                form.Controls.Add(argument1);
                form.Controls.Add(argument2);
                this.nazevPrikazu.Text = "Přiřaď";
                this.nazevPrikazu.SetBounds(10, posY + 8, 50,30);
                this.argument1.SetBounds(100, posY, 30, 30);
                this.argument2.SetBounds(160, posY, 30, 30);
                argument1.Items.Add("A");
                argument1.Items.Add("B");
                argument2.Items.Add("A");
                argument2.Items.Add("B");
                //  this.nazevPrikazu.Text = argument1.GetItemText(this.argument1.SelectedItem);

            }
            if (this.typ == 1) // Pricti jedna
            {
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.argument1.SetBounds(60, posY, 50, 30);
              
            }
            if (this.typ == 2) // prirad
            {
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.argument1.SetBounds(60, posY, 50, 30);
                
            }
        }
        
        public int getTyp()
        {
            return this.typ;
        }

        public int getPromenaA()
        {
            if ( 'A' == char.Parse(this.argument1.GetItemText(this.argument1.SelectedItem)))
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
