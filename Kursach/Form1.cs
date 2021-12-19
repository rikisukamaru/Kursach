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
        Kruglishok point1; // добавил поле под первую точку
        Kruglishok point2;
        Kruglishok point3;
        Kruglishok point4;
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


            point1 = new Kruglishok
            {
                X = picDisplay.Width / 2 + 190,
                Y = picDisplay.Height / 4,
                color = Color.Purple
                
            };
            point2 = new Kruglishok
            {
                X = picDisplay.Width / 2 - 80,
                Y = picDisplay.Height / 2,
                color = Color.Aqua
            };
            point3 = new Kruglishok
            {
                X = picDisplay.Width / 2 + 50,
                Y = picDisplay.Height / 3,
                color = Color.Violet
            };
            point4 = new Kruglishok
            {
                X = picDisplay.Width / 2 - 200,
                Y = 260 ,
                color = Color.Aquamarine
            };

            // привязываем поля к эмиттеру
            emmiter.impactPoints.Add(point1);
            emmiter.impactPoints.Add(point2);
            emmiter.impactPoints.Add(point3);
            emmiter.impactPoints.Add(point4);
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

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            foreach (var p in emmiter.impactPoints)
            {
                if (p is Kruglishok) // так как impactPoints не обязательно содержит поле Power, надо проверить на тип 
                {
                    // если гравитон то меняем силу
                    (p as Kruglishok).rad = trackBar1.Value;
                }
            }
        }
    }
}
