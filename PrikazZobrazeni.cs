using System;
using System.Collections;
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
        private bool alredzDrag = true;
        private int posY;
        public Label nazevPrikazu = new Label();
        private int typ;
        public ComboBox argument1cb = new ComboBox();
        public ComboBox argument2cb = new ComboBox();
        public ComboBox argument3cb = new ComboBox();
        public ComboBox argument4cb = new ComboBox();
        private int blokONline;
        private ArrayList tagAndOrigin = new ArrayList() { -1, true };
        private Panel blok = new Panel();
        //private Panel secondPart = new Panel();
        private bool posun = false;
        private bool selected = false;
        private Label cisloRadku = new Label();
        public static Panel ScrolHelp;
        private static bool oneIsalreadySelected = true;
        private static List<PrikazZobrazeni> prikazySeVsim;
        public PrikazZobrazeni(int PosY, int typ, Panel scrollO)
        {

            ScrolHelp = scrollO;
            ScrolHelp.MouseMove += ScrolHelp_MouseMove;
            //   Form1.zmenPocetBloku(1);

            int fakeAktualniPocetBloku = Form1.getAktpocet();
            tagAndOrigin[0] = fakeAktualniPocetBloku;
            blok.Tag = tagAndOrigin;
            cisloRadku.Tag = tagAndOrigin;

            blokONline = fakeAktualniPocetBloku;
            for (int i = 1; i < fakeAktualniPocetBloku + 1; i++)
            {
                argument4cb.Items.Add(i);
            }

            this.posY = PosY * 85 + 1;
            this.cisloRadku.Font = new Font("Arial", 15);
            this.cisloRadku.BackColor = Color.FromArgb(1, 64, 64, 64);
            this.cisloRadku.Text = (fakeAktualniPocetBloku + 1).ToString();
            this.cisloRadku.SetBounds(0, this.posY, 45, 20);
            this.cisloRadku.ForeColor = Color.FromArgb(255, 0, 0, 0);
            scrollO.Controls.Add(cisloRadku);

            blok.MouseClick += Blok_MouseClick1;

            this.typ = typ;
            blok.Width = 200;
            blok.Height = 65;
            blok.Top = (posY);
            blok.Left = (50);

            argument1cb.Items.Add('A');
            argument1cb.Items.Add('B');
            argument1cb.Items.Add('C');
            argument1cb.Items.Add('D');
            argument1cb.Items.Add('E');
            argument1cb.Items.Add('F');

            argument2cb.Items.Add('A');
            argument2cb.Items.Add('B');
            argument2cb.Items.Add('C');
            argument2cb.Items.Add('D');
            argument2cb.Items.Add('E');
            argument2cb.Items.Add('F');
            argument2cb.Items.Add('i');


            if (this.typ == 0) // prirad
            {

                blok.BackColor = Color.FromArgb(142, 158, 41);
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 142, 158, 41);
                this.nazevPrikazu.Text = "<--Přiřaď";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1cb.SetBounds(10, 25, 30, 30);
                this.argument2cb.SetBounds(160, 25, 30, 30);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);

                //  this.nazevPrikazu.Text = argument1cb.GetItemText(this.argument1cb.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);

                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1cb.Text = "-";
                this.argument1cb.Size = new Size(30, 00);
                this.argument1cb.Location = new Point(10, 20);
                this.blok.Controls.Add(argument1cb);



                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(55, 15, 100, 30);

            }
            else if (this.typ == 2) // zmensi o 1
            {
                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);
                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1cb.Text = "-";
                this.argument1cb.Size = new Size(30, 00);
                this.argument1cb.Location = new Point(10, 25);
                this.blok.Controls.Add(argument1cb);

                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "zmensi o 1";
                this.nazevPrikazu.SetBounds(55, 25, 120, 40);

            }
            else if (this.typ == 3)//jump if
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump if";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                //20,15 200,65
                //   blok.SetBounds(20, posY, 200, 65);


                blok.BackColor = Color.FromArgb(255, 0, 0, 255);
                int offset = 0;
                argument1cb.Text = "-";
                argument1cb.Size = new Size(30, 00);
                argument1cb.Location = new Point(20, 32);
                blok.Controls.Add(argument1cb);

                argument2cb.Text = "-";                
                argument2cb.Size = new Size(30, 00);
                argument2cb.Location = new Point(60, 32);
                blok.Controls.Add(argument2cb);

                argument3cb.Text = "-";
                argument3cb.Size = new Size(30, 00);
                argument3cb.Location = new Point((50 * 2) + offset, 32);
                argument3cb.Items.Add('=');
                argument3cb.Items.Add('<');
                argument3cb.Items.Add('>');
                blok.Controls.Add(argument3cb);


                argument4cb.Text = "-";
                argument4cb.Size = new Size(30, 00);
                argument4cb.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument4cb);


                /*  blok.Click += (s, e) => {
                      MessageBox.Show("Click");
                  };/**/



            }
            else if (typ == 4)// jump
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);


                blok.BackColor = Color.FromArgb(255, 0, 0, 255);

                // blok.MouseClick += Blok_MouseClick;
                argument4cb.Text = "-";
                argument4cb.Size = new Size(30, 00);
                argument4cb.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument4cb);
            }
            else if (typ == 5) // input
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(100, 25, 100, 80);
                nazevPrikazu.Text = "<--vstup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1cb.Text = "-";
                argument1cb.Size = new Size(30, 00);

                argument1cb.Location = new Point(10, 25);
                blok.Controls.Add(argument1cb);
            }
            else if (typ == 6)// output
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);

                nazevPrikazu.SetBounds(150, 25, 80, 30);
                nazevPrikazu.Text = "vystup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1cb.Text = "-";
                argument1cb.Size = new Size(30, 00);
                argument1cb.Location = new Point(5, 20);
            }
            else if (typ == 7)
            {

                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(255, 178, 30, 30);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "<--pricti";
                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1cb.SetBounds(10, 25, 30, 30);
                this.argument2cb.SetBounds(160, 25, 30, 30);
            }
            else if (typ == 8)
            {
                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);
                blok.BackColor = Color.FromArgb(255, 178, 30, 30);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "<--odecti";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1cb.SetBounds(10, 25, 30, 30);
                this.argument2cb.SetBounds(160, 25, 30, 30);
            }
        }
        public void setsdebugLayText()
        {
            this.nazevPrikazu.Text = this.argument1cb.GetItemText(this.argument1cb.SelectedItem);
        }
        public int getTyp()
        {
            return this.typ;
        }
        public void setZokrouhlenouPozici(int y)
        {
            //this.selected = false;            
            //nefunguje
            //MessageBox.Show(((Form1.getAktpocet() - 1) >= ((int)(y / 85))).ToString());
            if ((Form1.getAktpocet() - 1) >= ((int)(y / 85)))
            {
                y = (int)((y) / 85) * 85;
                this.blok.Left = 50;
                this.blok.Top = y;
                this.blok.Tag = blok.Top / 85;
                this.cisloRadku.Text = ((blok.Top / 85) + 1).ToString();
                this.cisloRadku.Top = y;
                this.tagAndOrigin[0] = blok.Top / 85;
                this.tagAndOrigin[1] = false;
                this.blok.Tag = tagAndOrigin;
                this.cisloRadku.Tag = tagAndOrigin;
                this.selected = false;
                // MessageBox.Show("zaokrouhleno");
            }

        }
        private void ScrolHelp_MouseClick1(object sender, MouseEventArgs e)
        {
            if (selected)
            {


                Form1.zmenPole();
                Form1.pridejDoPoleImaze(((int)((e.Y) / 85)), getIndex());
                setZokrouhlenouPozici(e.Y);
                Form1.zmenPole();
                oneIsalreadySelected = true;

            }
            /*
               setZokrouhlenouPozici(e.Y); 
                oneIsalreadySelected = true;
                selected = false;
                bool provedeno = false;
                ArrayList pomoc;  
                foreach (Control c in ScrolHelp.Controls)
                {
                   /* pomoc = (ArrayList)c.Tag;
                    MessageBox.Show("aktualni tag " + c.Tag.ToString() + "tag AKTUALNIHO objektu: " + this.blok.Tag.ToString());
                    if ((int)tagAndOrigin[0] == (int)pomoc[0] || provedeno)
                    {
                        if (((int)tagAndOrigin[0] == (int)pomoc[0]) && !((bool)pomoc[1])) //lip to nejde prisaham
                        {
                            this.tagAndOrigin[1] = true;
                            c.Tag = tagAndOrigin;
                            provedeno = true;
                            continue;
                        }
                        int pos = ((int)tagAndOrigin[0] + 1) * 85;

                        //   MessageBox.Show("posouv8m na pozici: "+pos.ToString());
                        if (c is Panel)

                        {
                            Panel panelControl = (Panel)c;
                            //panelControl.Top = (pos);
                            panelControl.SetBounds(50, pos, 200, 65);
                            tagAndOrigin[0] = pos / 85;
                            panelControl.Tag = tagAndOrigin;
                        }
                        else if (c is Label)
                        {

                            Label labelText = (Label)c;
                            //labelText.Top = pos;

                            labelText.SetBounds(0, pos, 45, 20);
                            labelText.Text = ((pos / 85) + 1).ToString();
                            tagAndOrigin[0] = pos / 85;
                            labelText.Tag = tagAndOrigin;
                        }
                    }                    

                }
                //setZokrouhlenouPozici(e.Y);
            }          */
        }
        public int getArgument1()
        {

            if ('A' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 1;
            else if ('B' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 2;
            else if ('C' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 3;
            else if ('D' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 4;
            else if ('E' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 5;
            else if ('F' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 6;
            else if ('i' == char.Parse(this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                return 0;

            else
                return 8;

        }
        private void ScrolHelp_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.selected)
            {
                setBlokPoint(e.X + 20, e.Y + 20);
            }
            //MessageBox.Show("Mouse moved");
        }
        public void setCisloRadkuPoint(int y, int x)
        {
            cisloRadku.Top = y;
            cisloRadku.Left = x;
        }
        public void setBlokPoint(int x, int y)
        {
            blok.Top = y;
            blok.Left = x;
        }
        public Panel getBlok()
        {
            return blok;
        }
        public Label getCisloratku()
        {
            return cisloRadku;
        }
        public int getIndex()
        {
            ArrayList ar = (ArrayList)blok.Tag;
            return (int)ar[0];
        }
        private void Blok_MouseClick1(object sender, MouseEventArgs e)
        {

            ScrolHelp.MouseClick += ScrolHelp_MouseClick1; // trochu smutny nastovovat to u kazdeho objektu a taky to ze je to az po kliku
            ArrayList smazPomoc = new ArrayList();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show(selected.ToString() + "je vybran ten druhej " + oneIsalreadySelected.ToString());
                if (oneIsalreadySelected)
                {
                    this.selected = true;
                    oneIsalreadySelected = false;

                }
                else
                {
                    blok.Left = 50;
                    blok.Top = (int)((e.Y + 40) / 85) * 85;
                    oneIsalreadySelected = true;
                }



            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                DialogResult dialogResult = MessageBox.Show("Jste si opravdu jisti že chcete daný blok smazat?", "Smazní", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ArrayList ar = this.tagAndOrigin;
                    Form1.deleFromMainArray((int)ar[0]);
                    Form1.zmenPole();
                }
            }
        }
    public void setTagPos(int index)
        {
            ArrayList pomoc = (ArrayList)cisloRadku.Tag;
            pomoc[0] = index;
            cisloRadku.Tag = pomoc;
            blok.Tag = pomoc;
        }
        public void setCisloRadkuText(String text)
        {
            cisloRadku.Text = text;
        }
        public int getArgument2()
        {
            if ('A' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 1;
            else if ('B' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 2;
            else if ('C' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 3;
            else if ('D' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 4;
            else if ('E' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 5;
            else if ('F' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 6;
            else if ('i' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                return 0;
            else
                return 7;
        }
        public int getArgument3()
        {
            if ('=' == char.Parse(this.argument3cb.GetItemText(this.argument3cb.SelectedItem)))
                return 1;
            else if ('<' == char.Parse(this.argument3cb.GetItemText(this.argument3cb.SelectedItem)))
                return 2;
            else if ('>' == char.Parse(this.argument3cb.GetItemText(this.argument3cb.SelectedItem)))
                return 3;
            return 4;
        }
        public int getArgument4()
        {

            //if (argument4cbcb.SelectedItem != null)
                return (int.Parse(argument4cb.Text.ToString()));
            //return 7012;
            
        }

        
    }
}
