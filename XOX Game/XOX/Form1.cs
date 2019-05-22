using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool sira = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Text = string.Empty;
                    btn.Size = new Size(70, 70);
                    btn.Location = new Point(75+70*j,80+70*i);
                    btn.Font = new Font(btn.Font.FontFamily, 40);
                    btn.Name = $"btn{(i * 3) + (j + 1)}";
                    btn.BackColor = Color.White;
                    label1.ForeColor = Color.Red;
                    Controls.Add(btn);
                    btn.Click += Btn_Click;
                    btn.Click += Kazanan;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnOyna = (Button)sender;
            
            if (sira)
            {
                btnOyna.Text = "X";
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Red;
            }
            else
            {
                btnOyna.Text = "O";
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;               
            }
            sira = !sira;
            btnOyna.Enabled = false;
            
        }
        int player1 = 0;
        int player2 = 0;

        private void Arrtir()
        {
            if (!sira)
            {
                ++player1;
                label1.Text = "PLAYER 1 : " + player1.ToString();
                MessageBox.Show("Kazanan Player 1");

            }
            else
            {
                ++player2;
                label2.Text = "PLAYER 2 : " + player2.ToString();
                MessageBox.Show("Kazanan Player 2");
                sira = false;
            }

           
        }

        private void RenkDegistir(int sayi1,int sayi2,int sayi3, object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();

            foreach (Control c in this.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    buttons.Add(b);
                }
            }

            buttons[sayi1].BackColor = Color.DarkGreen;
            buttons[sayi2].BackColor = Color.DarkGreen;
            buttons[sayi3].BackColor = Color.DarkGreen;
        }

        private void Kazanan(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();

            foreach (Control c in this.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    buttons.Add(b);
                }
            }
              

            if (buttons[0].Text == buttons[1].Text && buttons[1].Text == buttons[2].Text && !buttons[0].Enabled)
            {
                RenkDegistir(0, 1, 2,sender,e);
                Arrtir();              
                Sifirla();
                
            }
            else if (buttons[3].Text == buttons[4].Text && buttons[4].Text == buttons[5].Text && !buttons[3].Enabled)
            {
                RenkDegistir(3, 4, 5, sender, e);
                Arrtir();
                Sifirla();
            }
            else if (buttons[6].Text == buttons[7].Text && buttons[7].Text == buttons[8].Text && !buttons[6].Enabled)
            {
                RenkDegistir(6, 7, 8, sender, e);
                Arrtir();
                Sifirla();
            }
            //////////////////////////////////////////
            if (buttons[0].Text == buttons[3].Text && buttons[3].Text == buttons[6].Text && !buttons[0].Enabled)
            {
                RenkDegistir(0, 3, 6, sender, e);
                Arrtir();
                Sifirla();
            }
            else if (buttons[1].Text == buttons[4].Text && buttons[4].Text == buttons[7].Text && !buttons[1].Enabled)
            {
                RenkDegistir(1, 4, 7, sender, e);
                Arrtir();
                Sifirla();
            }
            else if (buttons[2].Text == buttons[5].Text && buttons[5].Text == buttons[8].Text && !buttons[2].Enabled)
            {
                RenkDegistir(2, 5, 8, sender, e);
                Arrtir();
                Sifirla();
            }

            else if (buttons[0].Text == buttons[4].Text && buttons[4].Text == buttons[8].Text && !buttons[0].Enabled)
            {
                RenkDegistir(0, 4, 8, sender, e);
                Arrtir();
                Sifirla();

            }

            else if (buttons[2].Text == buttons[4].Text && buttons[4].Text == buttons[6].Text && !buttons[6].Enabled)
            {
                RenkDegistir(2, 4, 6, sender, e);
                Arrtir();
                Sifirla();
            }

            else if (buttons[0].Enabled == false && buttons[1].Enabled == false && buttons[2].Enabled == false && buttons[3].Enabled == false && buttons[4].Enabled == false && buttons[5].Enabled == false && buttons[6].Enabled == false && buttons[7].Enabled == false && buttons[8].Enabled == false)
            {
                MessageBox.Show("Berabere !");
                Sifirla();
            }
        }

        public void Sifirla()
        {
            List<Button> buttons = new List<Button>();

            foreach (Control c in this.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {                 
                    b.BackColor = Color.White;
                    b.Text = "";
                    b.Enabled = true;
                    sira = !sira;
                }
            }
        }      
    }
}
