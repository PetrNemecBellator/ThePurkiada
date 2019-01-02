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
        private Button upButton = new Button();
        private Button downButton = new Button();
        private Button deleteButton = new Button();
        private bool alredzDrag = true;
        private int posY;
        public Label nazevPrikazu = new Label();
        public Label nazevPrikazu2 = new Label();
        public Label nazevPrikazu3 = new Label();
        private int typ;
        private int radekIndex;
        public ComboBox argument1cb = new ComboBox();
        public ComboBox argument2cb = new ComboBox();
        public ComboBox argument3cb = new ComboBox();
        public TextBox argument4cb = new TextBox();
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
            radekIndex = PosY;
            this.posY = PosY * 85;
            this.typ = typ;
            blok.Width = 200;
            blok.Height = 65;
            blok.Top = PosY * 85;
            blok.Left = (50);

            // button to navigate blok

            //
            upButton.MouseClick += UpButton_MouseClick;
            downButton.MouseClick += DownButton_MouseClick;
            deleteButton.MouseClick += DeleteButton_MouseClick;

            argument1cb.TextChanged += Argument1cb_TextChanged;
            argument2cb.TextChanged += Argument2cb_TextChanged;
            argument3cb.TextChanged += Argument3cb_TextChanged;
            argument4cb.TextChanged += Argument4cb_TextChanged;
            scrollO.Controls.Add(upButton);
            scrollO.Controls.Add(downButton);
            scrollO.Controls.Add(deleteButton);
            int offset = 20;
            upButton.SetBounds(250, offset + this.posY, 20, 20);
            upButton.Text = "▲";
            upButton.ForeColor = Color.Black;
            downButton.SetBounds(250, offset + this.posY + 20, 20, 20);
            downButton.Text = "▼";
            downButton.ForeColor = Color.Black;
            deleteButton.SetBounds(270, offset + this.posY + 13, 20, 20);
            deleteButton.Text = "X";
            deleteButton.ForeColor = Color.Black;

            //button to navigate blok

            //nazevPrikazu.MouseClick += NazevPrikazu_MouseClick;
            ScrolHelp = scrollO;
           // ScrolHelp.MouseMove += ScrolHelp_MouseMove;
            ScrolHelp.MouseClick += ScrolHelp_MouseClick1;
            //   Form1.zmenPocetBloku(1);

            int fakeAktualniPocetBloku = Form1.getAktpocet();
            tagAndOrigin[0] = fakeAktualniPocetBloku;
            blok.Tag = tagAndOrigin;
            cisloRadku.Tag = tagAndOrigin;

            blokONline = fakeAktualniPocetBloku;
            /*  for (int i = 1; i < fakeAktualniPocetBloku + 1; i++)
              {
                  argument4cb.Items.Add(i);
              }/*/


            this.cisloRadku.Font = new Font("Arial", 15);
            this.cisloRadku.BackColor = Color.FromArgb(1, 64, 64, 64);
            this.cisloRadku.Text = (fakeAktualniPocetBloku + 1).ToString();
            this.cisloRadku.SetBounds(0, this.posY, 45, 20);
            this.cisloRadku.ForeColor = Color.FromArgb(255, 0, 0, 0);
            scrollO.Controls.Add(cisloRadku);

          //  blok.MouseClick += Blok_MouseClick1;



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



            if (this.typ == 0) // prirad
            {

                blok.BackColor = Color.FromArgb(142, 158, 41);

                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 142, 158, 41);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "Do";
                this.nazevPrikazu2.SetBounds(0, 25, 80, 30);
                blok.Controls.Add(nazevPrikazu2);

                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 142, 158, 41);
                this.nazevPrikazu.Text = "ulož";
                this.nazevPrikazu.SetBounds(80, 25, 100, 80);

                this.argument1cb.SetBounds(40, 25, 30, 30);
                this.argument2cb.SetBounds(140, 25, 30, 30);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);
                blok.Controls.Add(nazevPrikazu2);

                //  this.nazevPrikazu.Text = argument1cb.GetItemText(this.argument1cb.SelectedItem);

            }
            else if (this.typ == 1) // Pricti jedna
            {
                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "K";
                this.nazevPrikazu2.SetBounds(10, 25, 30, 30);
                blok.Controls.Add(nazevPrikazu2);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);
                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1cb.Text = "-";
                this.argument1cb.Size = new Size(30, 00);
                this.argument1cb.Location = new Point(40, 25);
                this.blok.Controls.Add(argument1cb);

                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "přičti 1";
                this.nazevPrikazu.SetBounds(90, 25, 120, 40);


            }
            else if (this.typ == 2) // zmensi o 1
            {

                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "Od";
                this.nazevPrikazu2.SetBounds(0, 25, 40, 30);
                blok.Controls.Add(nazevPrikazu2);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);
                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 148, 0);

                this.argument1cb.Text = "-";
                this.argument1cb.Size = new Size(30, 00);
                this.argument1cb.Location = new Point(40, 25);
                this.blok.Controls.Add(argument1cb);

                this.blok.BackColor = Color.FromArgb(255, 148, 0);
                this.nazevPrikazu.Text = "odečti 1";
                this.nazevPrikazu.SetBounds(90, 25, 120, 40);

            }
            else if (this.typ == 3)//jump if
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 4, 70, 30);
                nazevPrikazu.Text = "pokud";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 0, 0, 255);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "skoč na";
                this.nazevPrikazu2.SetBounds(0, 35, 80, 30);
                blok.Controls.Add(nazevPrikazu2);

                this.nazevPrikazu3.Font = new Font("Arial", 15);
                this.nazevPrikazu3.BackColor = Color.FromArgb(255, 0, 0, 255);
                this.nazevPrikazu3.ForeColor = Color.White;
                this.nazevPrikazu3.Text = ". řádek";
                this.nazevPrikazu3.SetBounds(110, 35, 95, 30);
                blok.Controls.Add(nazevPrikazu3);
                //20,15 200,65
                //   blok.SetBounds(20, posY, 200, 65);


                blok.BackColor = Color.FromArgb(255, 0, 0, 255);

                argument1cb.Text = "-";
                argument1cb.Size = new Size(30, 00);
                argument1cb.Location = new Point(85, 4);
                blok.Controls.Add(argument1cb);

                argument2cb.Text = "-";
                argument2cb.Size = new Size(30, 00);
                argument2cb.Location = new Point(150, 4);
                
                argument2cb.Items.Add("-1");
                argument2cb.Items.Add('0');
                argument2cb.Items.Add('1');
                blok.Controls.Add(argument2cb);

                argument3cb.Text = "-";
                argument3cb.Size = new Size(30, 00);
                argument3cb.Location = new Point(117, 4);
                argument3cb.Items.Add('=');
                argument3cb.Items.Add('<');
                argument3cb.Items.Add('>');
                blok.Controls.Add(argument3cb);


                argument4cb.Text = "";
                argument4cb.Size = new Size(30, 00);
                argument4cb.Location = new Point(80, 35);
                blok.Controls.Add(argument4cb);


                /*  blok.Click += (s, e) => {
                      MessageBox.Show("Click");
                  };/**/



            }
            else if (typ == 4)// jump
            {
                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(0, 25, 80, 30);
                nazevPrikazu.Text = "skoč na ";
                nazevPrikazu.Font = new Font("Arial", 15);
    
                nazevPrikazu.BackColor = Color.FromArgb(255, 0, 0, 255);
                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 0, 0, 255);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = ". řádek";
                this.nazevPrikazu2.SetBounds(105, 25, 95, 30);
                blok.Controls.Add(nazevPrikazu2);

                blok.BackColor = Color.FromArgb(255, 0, 0, 255);
           
                // blok.MouseClick += Blok_MouseClick;
                argument4cb.Text = "";
                argument4cb.Size = new Size(30, 00);
              
                argument4cb.Location = new Point(85, 25);// new Point((60 * 2) , 32);
                blok.Controls.Add(argument4cb);
            }
            else if (typ == 5) // input
            {


                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 23, 99, 13);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "Do";
                this.nazevPrikazu2.SetBounds(0, 25, 40, 30);
                blok.Controls.Add(nazevPrikazu2);

                this.nazevPrikazu3.Font = new Font("Arial", 15);
                this.nazevPrikazu3.BackColor = Color.FromArgb(255, 23, 99, 13);
                this.nazevPrikazu3.Text = "ulož";
                this.nazevPrikazu3.SetBounds(80, 25, 50, 30);
                blok.Controls.Add(nazevPrikazu3);
                this.argument1cb.SetBounds(40, 25, 30, 30);
                this.argument2cb.SetBounds(140, 25, 30, 30);


                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(130, 25, 80, 80);
                nazevPrikazu.Text = "vstup";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);

                argument1cb.Text = "-";
                argument1cb.Size = new Size(30, 00);

                argument1cb.Location = new Point(40, 25);
                blok.Controls.Add(argument1cb);
            }
            else if (typ == 6)// output
            {
                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 23, 99, 13);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "Přidej";
                this.nazevPrikazu2.SetBounds(0, 25, 65, 30);
                blok.Controls.Add(nazevPrikazu2);

                
                

                blok.Controls.Add(nazevPrikazu);
                scrollO.Controls.Add(blok);
                nazevPrikazu.SetBounds(100, 25, 120, 80);
                nazevPrikazu.Text = "do výstupu";
                nazevPrikazu.Font = new Font("Arial", 15);
                nazevPrikazu.BackColor = Color.FromArgb(255, 23, 99, 13);


                blok.BackColor = Color.FromArgb(255, 23, 99, 13);
         
                argument2cb.Text = "-";
                argument2cb.Size = new Size(30, 00);
                argument2cb.Items.Add(0);
                argument2cb.Items.Add(1);
                argument2cb.Location = new Point(65, 25);
                blok.Controls.Add(argument2cb);
            }
            else if (typ == 7)
            {

                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "K";
                this.nazevPrikazu2.SetBounds(0, 20, 20, 30);
                blok.Controls.Add(nazevPrikazu2);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);
                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);


                this.blok.Controls.Add(argument1cb);

              // this.blok.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "přicti";
                this.nazevPrikazu.SetBounds(85, 25, 65,40);
                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(255, 178, 30, 30);

             
                this.argument1cb.SetBounds(40, 25, 30, 30);
                this.argument2cb.SetBounds(160, 25, 30, 30);
                this.blok.Controls.Add(argument1cb);
                this.blok.Controls.Add(argument2cb);
            }
            else if (typ == 8)
            {
                this.nazevPrikazu2.Font = new Font("Arial", 15);
                this.nazevPrikazu2.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu2.ForeColor = Color.White;
                this.nazevPrikazu2.Text = "Od";
                this.nazevPrikazu2.SetBounds(0, 20, 40, 30);
                blok.Controls.Add(nazevPrikazu2);

                scrollO.Controls.Add(blok);
                blok.Controls.Add(nazevPrikazu);
                this.blok.Controls.Add(argument1cb);
                //nazevPrikazu.Text = " Pricti jedna";
                this.nazevPrikazu.Font = new Font("Arial", 15);
                this.nazevPrikazu.BackColor = Color.FromArgb(255, 178, 30, 30);


                this.blok.Controls.Add(argument1cb);

                // this.blok.BackColor = Color.FromArgb(255, 178, 30, 30);
                this.nazevPrikazu.Text = "odečti";
                this.nazevPrikazu.SetBounds(85, 25, 65, 40);
                scrollO.Controls.Add(blok);
                blok.Controls.Add(argument1cb);
                blok.Controls.Add(argument2cb);
                blok.Controls.Add(nazevPrikazu);

                blok.BackColor = Color.FromArgb(255, 178, 30, 30);


                this.argument1cb.SetBounds(40, 25, 30, 30);
                this.argument2cb.SetBounds(160, 25, 30, 30);
                this.blok.Controls.Add(argument1cb);
                this.blok.Controls.Add(argument2cb);
            }
        }

        private void Argument4cb_TextChanged(object sender, EventArgs e)
        {
            Form1.setDalsiKrokBool(false);
        }

        private void Argument3cb_TextChanged(object sender, EventArgs e)
        {
            Form1.setDalsiKrokBool(false);
        }

        private void Argument2cb_TextChanged(object sender, EventArgs e)
        {
            Form1.setDalsiKrokBool(false);
        }

        private void Argument1cb_TextChanged(object sender, EventArgs e)
        {
            Form1.setDalsiKrokBool(false);
        }

        private void DeleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            
          /* DialogResult dialogResult = MessageBox.Show("Jste si opravdu jisti že chcete daný blok smazat?", "Smázni!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1.setDalsiKrokBool(false);
                ArrayList ar = this.tagAndOrigin;
                Form1.deleFromMainArray(this.posY/85);
                Form1.zmenPole();
            }*/
                Form1.setDalsiKrokBool(false);
                ArrayList ar = this.tagAndOrigin;
                Form1.deleFromMainArray(this.posY/85);
                Form1.zmenPole();
        }

        private void DownButton_MouseClick(object sender, MouseEventArgs e)
        {
           
            //MessageBox.Show((Form1.getAktpocet() - 1).ToString() + "== " + getIndex() + "souradnice:" + this.blok.Top.ToString());
            if (Form1.getAktpocet() - 1 == getIndex())
            {
                MessageBox.Show("příkazoví blok už je na konci programu nelze posunout níže", "Varování!");
            }
            else
            {
                Form1.setDalsiKrokBool(false);
                Form1.pridejDoPoleImaze(getIndex() + 1, getIndex());
                this.radekIndex += 1;
                Form1.zmenPole();
            }
        }
        private static int maxHodScrollBar;
        private static int minHodScrollBar;
        private static void setminMaxValuescrollBar(int min, int max)
        {
            maxHodScrollBar = max;
            minHodScrollBar =min;
        }
        private void jsouMiMaxvPohode()
        {
            //blbost
            if (maxHodScrollBar != ScrolHelp.VerticalScroll.Maximum || maxHodScrollBar != ScrolHelp.VerticalScroll.Maximum) jsouMiMaxvPohode();
           
            
        }
        private void UpButton_MouseClick(object sender, MouseEventArgs e)
        {
           
            Point puvodniBod = ScrolHelp.AutoScrollPosition;
            Point p = new Point(ScrolHelp.AutoScrollPosition.X, 0);
            setminMaxValuescrollBar(ScrolHelp.VerticalScroll.Minimum, ScrolHelp.VerticalScroll.Maximum);
            ScrolHelp.AutoScrollPosition= p;
           // Thread.Sleep(5000);
        //    MessageBox.Show("ten 1" +puvodniBod.ToString());

            if (getIndex() == 0)
            {
                MessageBox.Show("Dany blok je už nahoře nelze ho přesunout vyše","Varování");
            }
            else
            {
                Form1.setDalsiKrokBool(false);
                Form1.pridejDoPoleImaze(getIndex()-1 , getIndex());
                this.radekIndex -= 1;
                Form1.zmenPole();
             }
           
            ScrolHelp.AutoScrollPosition = puvodniBod;
           
          //  MessageBox.Show("te druhej"+ ScrolHelp.AutoScrollPosition.ToString());
        }

        public Button getdownButton()
        {
            return this.downButton;
        }
        public Button getupButton()
        {
            return this.upButton;
        }
        public Button getDeletebutton()
        {
            return this.deleteButton;
        }
        public  void setupButtonLocationY(int y)
        {
            this.upButton.Top = y+20;
        }
        public void setdownButtonLocationY(int y)
        {
            this.downButton.Top = y+20;
        }
        public void setDeletelocation(int y  )
        {
            this.deleteButton.Top = ((y+27));
        }

        private void NazevPrikazu_MouseClick(object sender, MouseEventArgs e)
        {
            ArrayList smazPomoc = new ArrayList();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //   MessageBox.Show(selected.ToString() + "je vybran ten druhej " + oneIsalreadySelected.ToString());
                if (oneIsalreadySelected)
                {
                    this.selected = true;
                    oneIsalreadySelected = false;
                    setBlokPoint(e.X + 20, e.Y + 20);
                }
                



            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                DialogResult dialogResult = MessageBox.Show("Jste si opravdu jisti že chcete daný blok smazat?", "Smazání", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ArrayList ar = this.tagAndOrigin;
                    Form1.deleFromMainArray((this.posY/85));
                    Form1.zmenPole();
                }
            }

        }

        private void NazevPrikazu_Click(object sender, EventArgs e)
        {
         }

        public void setsdebugLayText()
        {
            this.nazevPrikazu.Text = this.argument1cb.GetItemText(this.argument1cb.SelectedItem);
        }
        public int getTyp()
        {
            return this.typ;
        }
        public int getBlokWidth()
        {
            return blok.Width;
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
                if (((int)((e.Y) / 85)) > Form1.getAktpocet()  ){

                    Form1.pridejDoPoleImaze((Form1.getAktpocet()), getIndex());
                    setZokrouhlenouPozici(e.Y);
                    Form1.zmenPole();
                    oneIsalreadySelected = true;
            //        setdownButtonlocation(300, blok.Top);
               //     setUPButtonloaton(300, blok.Top);
                }
                else
                {
                    Form1.pridejDoPoleImaze(((int)((e.Y) / 85)), getIndex());
                    setZokrouhlenouPozici(e.Y);
                    Form1.zmenPole();
                    oneIsalreadySelected = true;
                 //   setdownButtonlocation(300, blok.Top);
                    //setUPButtonloaton(300, blok.Top);

                }
                selected = false;
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
        public int  getBlokLine()
        {
            return (blok.Top / 85) + 1;
        }
        private static string pouzitePromene = "";
        public static int getPocetPouzitichPromenych()
        {
            return pouzitePromene.Length;
        }
        public static void nullPouzitePormene()
        {
            pouzitePromene = "";
        }
        private void addPouzitaProm(string promena)
        {
            bool nealezena = false;
            for (int i = 0 ; i < pouzitePromene.Length; i++) {
                if (pouzitePromene[i] == promena[0])
                {
                    
                    return;                   
                }
            }
            pouzitePromene += promena;
            
            
        }

        public int getArgument1()
        {

            if ("A" == (this.argument1cb.Text.ToString()) || "B" == (this.argument1cb.Text.ToString()) || "C" == (this.argument1cb.Text.ToString()) || "D" == (this.argument1cb.Text.ToString()) || "E" == (this.argument1cb.Text.ToString()) || "F" == (this.argument1cb.Text.ToString()))
            {
                //  MessageBox.Show("pohoda moc ty arggumrnty 1");

                if ("A" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("A");
                    return int.MaxValue - 1;
                }
                else if ("B" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("B");
                    return int.MaxValue - 2;
                }
                else if ("C" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("C");
                    return int.MaxValue - 3;
                }
                else if ("D" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("D");
                    return int.MaxValue - 4;
                }
                else if ("E" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("E");
                    return int.MaxValue - 5;
                }
                else if ("F" == (this.argument1cb.GetItemText(this.argument1cb.Text.ToString())))
                {
                    addPouzitaProm("F");
                    return int.MaxValue - 6;
                }

                else if ("A" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("A");
                    return int.MaxValue - 1;
                }
                else if ("B" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("B");
                    return int.MaxValue - 2;
                }
                else if ("C" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("C");
                    return int.MaxValue - 3;
                }
                else if ("D" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("D");
                    return int.MaxValue - 4;
                }
                else if ("E" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("E");
                    return int.MaxValue - 5;
                }
                else if ("F" == (this.argument1cb.GetItemText(this.argument1cb.SelectedItem)))
                {
                    addPouzitaProm("F");
                    return int.MaxValue - 6;
                }
                //  else if ('i' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                //      return int.MaxValue;

            }
            return int.MaxValue;
        }
        private void setUPButtonloaton (int x, int y)
        {
            this.upButton.Left = x;
            this.upButton.Top = y;
        }
        private void setdownButtonlocation(int x , int y)
        {
            this.downButton.Left = x;
            this.downButton.Top = y;
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
            this.posY = y;
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
            return this.posY/85;
           // ArrayList ar = (ArrayList)blok.Tag;
            //return (int)ar[0];
        }
        private void Blok_MouseClick1(object sender, MouseEventArgs e)
        {

         // trochu smutny nastovovat to u kazdeho objektu a taky to ze je to az po kliku
            ArrayList smazPomoc = new ArrayList();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //   MessageBox.Show(selected.ToString() + "je vybran ten druhej " + oneIsalreadySelected.ToString());
                if (oneIsalreadySelected)
                {
                    this.selected = true;
                    oneIsalreadySelected = false;
                    setBlokPoint(e.X + 20, e.Y + 20);

                    
                    
                }
               /* else
                {
                    blok.Left = 50;
                    blok.Top = (int)((e.Y + 40) / 85) * 85;

                }*/



            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                DialogResult dialogResult = MessageBox.Show("Jste si opravdu jisti že chcete daný blok smazat?", "Smazní", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ArrayList ar = this.tagAndOrigin;
                    Form1.deleFromMainArray(this.posY/85);
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
            int cislo = 0;

                if (int.TryParse(this.argument2cb.Text, out cislo))
                {

                    if (this.typ == 6)
                    {
                        if (cislo == 0 || cislo == 1)
                        {
                            return cislo;
                        }
                        else
                        {
                            MessageBox.Show("Do bloku output nelze vložít nic kromě 0 a 1. ", "Chyba");
                            return int.MaxValue;
                        }
                     }
                     if (this.typ == 3)
                        {
                        return cislo;
                    }

                
            }
            else if ("A" == (this.argument1cb.Text.ToString()) || "B" == (this.argument2cb.Text.ToString()) || "C" == (this.argument2cb.Text.ToString()) || "D" == (this.argument2cb.Text.ToString()) || "E" == (this.argument2cb.Text.ToString()) || "F" == (this.argument2cb.Text.ToString()))
            {
                //  MessageBox.Show("pohoda moc ty arggumrnty 1");

                if ("A" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("A");
                    return int.MaxValue - 1;
                }
                else if ("B" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("B");
                    return int.MaxValue - 2;
                }
                else if ("C" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("C");
                    return int.MaxValue - 3;
                }
                else if ("D" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("D");
                    return int.MaxValue - 4;
                }
                else if ("E" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("E");
                    return int.MaxValue - 5;
                }
                else if ("F" == (this.argument2cb.GetItemText(this.argument2cb.Text.ToString())))
                {
                    addPouzitaProm("F");
                    return int.MaxValue - 6;
                }

                else if ("A" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("A");
                    return int.MaxValue - 1;
                }
                else if ("B" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("B");
                    return int.MaxValue - 2;
                }
                else if ("C" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("C");
                    return int.MaxValue - 3;
                }
                else if ("D" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("D");
                    return int.MaxValue - 4;
                }
                else if ("E" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("E");
                    return int.MaxValue - 5;
                }
                else if ("F" == (this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                {
                    addPouzitaProm("F");
                    return int.MaxValue - 6;
                }
                //  else if ('i' == char.Parse(this.argument2cb.GetItemText(this.argument2cb.SelectedItem)))
                //      return int.MaxValue;

            }
            return int.MaxValue;
        }



            //MessageBox.Show("argument je spatne zadaný na řadku: "+((this.posY/85)+1).ToString(), "Chyba!!");
            
        public int getArgument3()
        {
            if ("=" == (this.argument3cb.GetItemText(this.argument3cb.SelectedItem)).ToString())
                return 1;
            else if ("<" == (this.argument3cb.GetItemText(this.argument3cb.SelectedItem)).ToString())
                return 2;
            else if (">" == (this.argument3cb.GetItemText(this.argument3cb.SelectedItem)).ToString())
                return 3;
            return int.MaxValue;
        }
        public int getArgument4()
        {
            int cislo;
            //if (argument4cbcb.SelectedItem != null)
            if(int.TryParse(argument4cb.Text.ToString(),out cislo)){
                return cislo;
            }
            //return 7012;
            return int.MaxValue;
        }

        
    }
}
