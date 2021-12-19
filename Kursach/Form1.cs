using System;
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
        List<Emmiter> emmiters = new List<Emmiter>();
        Emmiter emmiter;
        List<ImpactPoint> impactPoints = new List<ImpactPoint>();
        GravityPoint point1; // добавил поле под первую точку
        GravityPoint point2;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            
            emmiter = new LinEmmiter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f,
                 SpeedMin = 1,
                SpeedMax = 30
            };
            emmiters.Add(emmiter);
         

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 190,
                Y = picDisplay.Height / 4,
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emmiter.impactPoints.Add(point1);
            emmiter.impactPoints.Add(point2);

        }
      
       
       

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            emmiter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                g.Clear(Color.Black);
               
              //  g.DrawEllipse(new Pen(Color.Aquamarine, 3), 480, 120, 80,80);
                emmiter.Render(g); // рендерим систему
                
            }

            picDisplay.Invalidate();
        }
     
        private void picDisplay_MouseMove_1(object sender, MouseEventArgs e)
        {

            emmiter.MousePositionX = e.X;
            emmiter.MousePositionY = e.Y;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
         emmiter.SpeedMin = TBSpeedPart.Value;
         label1.Text = $"{TBSpeedPart.Value}";
        }
    }
}
