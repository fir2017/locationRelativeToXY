using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace locationRelativeToXY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int mouseposx, mouseposy;
        Graphics g;
        /*
         * imparte ecranul in mici patrate de 10x10 pixeli
         * calculeaza pozitia mouse xy
         * calculeaza patratul in care este mouseul
         * algoritm bun pentru jocuri precum puzzle
         * unde trebuei calculat coltul cel mai apropriat 
         * unde poate fi lasata o piesa de joc
         * in cazul de fata este folosit pentru a caroia fundalul 
         * pentru a masura distantele din alte aplicatii
         */
        public void drawGrila()
        {
            
            for (int i = 0; i < Width; i += 10)
            {
                for (int j = 0; j < Height; j += 10)
                {
                    g.DrawLine(new Pen(Color.Silver), i, 0, i, Height);
                    g.DrawLine(new Pen(Color.Silver), 0, j, Width, j);

                }
            }
        }

        public void publishMousePosXY()
        {
            //Text = mouseposx.ToString() + " : " + mouseposy.ToString();
            label1.Text = mouseposx.ToString() + " : " + mouseposy.ToString();
            label1.Text += "\r\n";
            label1.Text += ((mouseposx) / 10).ToString() + " : " + ((mouseposy) / 10).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseposx = e.X;
            mouseposy = e.Y;
            publishMousePosXY();

          
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            g = CreateGraphics();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            drawGrila();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //colectia Controls inregistreaza se pare urmatorul
            //control index in Count er si nu ultimul control
            int k = Controls.Count;
            Controls.Add(new Label());
            Controls[k].Left = (mouseposx / 10)*10;
            Controls[k].Top = (mouseposy / 10)*10;
            Controls[k].Width = 50;
            Controls[k].Text = ((mouseposx) / 10).ToString() + " : " + ((mouseposy) / 10).ToString();
            Controls[k].Show();
            //puneti in locul Label un control cu o imagine si realizati
            //astfel un joc de puzzel cu imagini
            // nu uitati sa creati o matrice in care sa inregistrati pozitiile ocrecte ale tuturor 
            //piesele de joc car evor contine imaginile


        }
    }
}
