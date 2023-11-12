using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyWeightL;

namespace Clouds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }
        Cloud[] clouds = new Cloud[20];
        Graphics g;

        ParamBigCloud p1 = new ParamBigCloud();
        ParamMediumCloud p2 = new ParamMediumCloud();
        ParamSmallCloud p3 = new ParamSmallCloud();
    
        Random r = new Random();
        int[] ways = {0, 60, 120, 180, 240, 300, 360, 420};
        private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < clouds.Length; i++)
            {  
                switch (r.Next(0, 3)) {
                    case 0: clouds[i] = new Cloud(r.Next(0, 450),  p1, r, ways); break;
                    case 1: clouds[i] = new Cloud(r.Next(0, 450),  p2, r, ways); break;
                    case 2: clouds[i] = new Cloud(r.Next(0, 450),  p3, r, ways); break;
                }
            }
            timer1.Start();
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < clouds.Length; i++)
            {
               g.FillRectangle(Brushes.White, clouds[i].x, clouds[i].y, clouds[i].param.w, clouds[i].param.h);
               clouds[i].respawn();
               g.DrawImage(clouds[i].param.picture, new Rectangle(clouds[i].x, clouds[i].y, clouds[i].param.w, clouds[i].param.h));
            }  
        }
    }
}

