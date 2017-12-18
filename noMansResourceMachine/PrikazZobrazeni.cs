﻿using System;
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
        public ComboBox argument1 = new ComboBox();
        public ComboBox argument2 = new ComboBox();
        public ComboBox argument3 = new ComboBox();
        public ComboBox argument4 = new ComboBox();
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
                argument4.Items.Add(i);
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

            if (this.typ == 0) // prirad
            {

                blok.BackColor = Color.FromArgb(142, 158, 41);
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 142, 158, 41);
                this.nazevPrikazu.Text = "<--Přiřaď";

                this.nazevPrikazu.SetBounds(60, 25, 100, 80);
                this.argument1.SetBounds(10, 25, 30, 30);
                this.argument2.SetBounds(160, 25, 30, 30);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1);
                blok.Controls.Add(argument2);
                blok.Controls.Add(nazevPrikazu);

                //  this.nazevPrikazu.Text = argument1.GetItemText(this.argument1.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1);

                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1.Text = "-";
                this.argument1.Size = new Size(30, 00);
                this.argument1.Location = new Point(10, 20);
                this.blok.Controls.Add(argument1);



                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "zvetsi o 1";
                this.nazevPrikazu.SetBounds(55, 15, 100, 30);

            }
            else if (this.typ == 2) // zmensi o 1
            {
                scrollO.Controls.Add(blok);
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
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 0, 80, 30);
                nazevPrikazu.Text = "jump if";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                //20,15 200,65
                //   blok.SetBounds(20, posY, 200, 65);


                blok.BackColor = Color.FromArgb(255, 0, 0, 255);
                int offset = 0;
                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point(20, 32);
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
                argument3.Location = new Point((50 * 2) + offset, 32);
                blok.Controls.Add(argument3);


                argument4.Text = "-";
                argument4.Size = new Size(30, 00);
                argument4.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument4);


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
                argument4.Text = "-";
                argument4.Size = new Size(30, 00);
                argument4.Location = new Point((60 * 2) + 30, 32);
                blok.Controls.Add(argument4);
            } else if (typ == 5) // input
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(100, 25, 100, 80);
                nazevPrikazu.Text = "<--vstup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);

                argument1.Location = new Point(10, 25);
                blok.Controls.Add(argument1);
            } else if (typ == 6)// output
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1);

                nazevPrikazu.SetBounds(150, 25, 80, 30);
                nazevPrikazu.Text = "vystup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1.Text = "-";
                argument1.Size = new Size(30, 00);
                argument1.Location = new Point(5, 20);
            } else if (typ == 7)
            {

                scrollO.Controls.Add(blok);
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
            else if (typ == 8)
            {
                scrollO.Controls.Add(blok);
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

        private void ScrolHelp_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.selected)
            {
                setBlokPoint(e.X + 20, e.Y + 20);
            }
            //MessageBox.Show("Mouse moved");
        }
        public Panel getBlok()
        {
            return blok;
        }
        public Label getCisloratku()
        {
            return cisloRadku;
        }
        
        private void ScrolHelp_MouseClick1(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                
                
                Form1.zmenPole();
                Form1.pridejDoPoleImaze(((int)((e.Y) / 85)) , getIndex());
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


    
    public static void initPrikazPole(List<PrikazZobrazeni> polePrikazu)
    {
        prikazySeVsim = polePrikazu;
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
    public void setZokrouhlenouPozici(int y)
    {
            //this.selected = false;            
            //nefunguje
            //MessageBox.Show(((Form1.getAktpocet() - 1) >= ((int)(y / 85))).ToString());
        if ((Form1.getAktpocet()-1) >=((int)( y/85)) )
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
        public void setCisloRadkuText(String text)
        {
            cisloRadku.Text = text;
        }
        public void setTagPos(int index)
        {
            ArrayList pomoc =(ArrayList) cisloRadku.Tag;
            pomoc[0] = index;
            cisloRadku.Tag = pomoc;
            blok.Tag = pomoc;
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
                MessageBox.Show(selected.ToString() +"je vybran ten druhej "+ oneIsalreadySelected.ToString());
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
                ArrayList ar;
            DialogResult dialogResult = MessageBox.Show("Jste si opravdu jisti že chcete daný blok smazat?", "Smazní", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (Control c in ScrolHelp.Controls)
                {
                    ar = (ArrayList)c.Tag;
                    if ((int)ar[0] == (int)tagAndOrigin[0])
                    {
                        smazPomoc.Add(c);
                    }
                    else if ((int)ar[0] > (int)tagAndOrigin[0])
                    {
                        int pos = ((int)(ar[0]) - 1) * 85;
                        //   MessageBox.Show("posouv8m na pozici: "+pos.ToString());
                        if (c is Panel)
                        {
                            {
                                Panel panelControl = (Panel)c;
                                //panelControl.Top = (pos);
                                panelControl.SetBounds(50, pos, 200, 65);
                                tagAndOrigin[0] = pos / 85;
                                panelControl.Tag =tagAndOrigin ;
                                //panelControl.Tag = pos / 85;
                            }
                        }
                        else if (c is Label)
                        {

                            Label labelText = (Label)c;
                            //labelText.Top = pos;

                            labelText.SetBounds(0, pos, 45, 20);
                            labelText.Text = ((pos / 85) + 1).ToString();
                            tagAndOrigin[0] = pos / 85;
                            labelText.Tag = tagAndOrigin;
                            //labelText.Tag = (pos / 85);
                        }


                    }
                }
                //    MessageBox.Show("Pocet veci na smazani!!!!!!: " + smazPomoc.Count.ToString());
                foreach (Control k in smazPomoc)
                {

                    k.BackColor = Color.FromArgb(255, 125, 65, 65);
                    ScrolHelp.Controls.Remove(blok);
                    ScrolHelp.Controls.Remove(cisloRadku);
                    ScrolHelp.Refresh();
                    k.Dispose();
                    //   MessageBox.Show("odstrnen blok s tagem "+blok.Tag.ToString()+ " \n label s tagem "+cisloRadku.Tag.ToString());
                }
                Form1.deleFromMainArray((int)(tagAndOrigin[0]));
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }



        }



    }


    private void panel_scrolllll_MouseClick(object sender, MouseEventArgs e)
    {
        //MessageBox.Show(e.X.ToString() + " "+ e.Y.ToString());
    }
    private void panel_scrolllll_Paint(object sender, PaintEventArgs e)
    {

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
    public void clickInit()
    {

    }
    private void setY(int posY)
    {
        blok.Top = (posY);
    }


    }

}


