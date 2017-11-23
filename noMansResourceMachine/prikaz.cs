using System;
using System.Collections.Generic;
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
                form.Controls.Add(nazevPrikazu);
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
            if (this.typ == 1) // Pricti jedna
            {
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.promena1.SetBounds(60, posY, 50, 30);
              
            }
            if (this.typ == 2) // prirad
            {
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(30, posY, 100, 30);
                this.promena1.SetBounds(60, posY, 50, 30);
                
            }
        }
        public void setsdebugLayText()
        {
            this.nazevPrikazu.Text = this.promena1.GetItemText(this.promena1.SelectedItem);
        }
    }
}
