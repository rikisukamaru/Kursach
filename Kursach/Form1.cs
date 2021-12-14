﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form1 : Form
    {
        Emmiter emmiter = new Emmiter();
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            emmiter = new LinEmmiter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
        }
      

       

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            emmiter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emmiter.Render(g); // рендерим систему
            }

            picDisplay.Invalidate();
        }
        private int MousePositionX = 0;
        private int MousePositionY = 0;
        private void picDisplay_MouseMove_1(object sender, MouseEventArgs e)
        {
            emmiter.MousePositionX = e.X;
            emmiter.MousePositionY = e.Y;
        }
    }
}
