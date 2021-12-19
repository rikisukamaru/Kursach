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
            emmiter.impactPoints.Add(new GravityPoint
            {
                X = picDisplay.Width / 2 + 190,
                Y = picDisplay.Height / 4,
            });


        }
      
        public void CreatKrug(Graphics g)
        {
            List<Particle> kk = new List<Particle>();
           
            foreach (var krug in kk)
            {
               g.FillEllipse(new SolidBrush(Color.Aquamarine), 480, 120, 80, 80);
                 kk.Add(krug);
            }

           
        }
       

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            emmiter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                g.Clear(Color.Black);
                CreatKrug(g);
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
