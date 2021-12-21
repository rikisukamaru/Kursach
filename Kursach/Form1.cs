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
                Y = picDisplay.Height / 4f,
                color = Color.Purple

            };
            point2 = new Kruglishok
            {
                X = picDisplay.Width / 2 - 80,
                Y = picDisplay.Height / 2f,
                color = Color.Aqua
            };
            point3 = new Kruglishok
            {
                X = picDisplay.Width / 2 + 50,
                Y = picDisplay.Height / 3f,
                color = Color.Violet
            };
            point4 = new Kruglishok
            {
                X = picDisplay.Width / 2 - 200,
                Y = 260,
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
                emmiter.Render(g); // рендерим систему

            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove_1(object sender, MouseEventArgs e)
        {


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
                if (p is Kruglishok)
                {
                    (p as Kruglishok).rad = trackBar1.Value;
                }
            }
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                emmiter.impactPoints.Add(new Kruglishok
                {
                    X = e.X,
                    Y = e.Y,
                    color = Color.Red
                });
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (var impactPoint in emmiter.impactPoints)
                {
                    if (!(impactPoint is Kruglishok kruglishok)) continue;
                    if (!(impactPoint.color == Color.Red)) continue;
                    if (!(Math.Abs(kruglishok.X - e.X) <= kruglishok.rad) || !(Math.Abs(kruglishok.Y - e.Y) <= kruglishok.rad))
                        continue;
                    emmiter.impactPoints.Remove(kruglishok);
                    break;
                }
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            point1.X = trackBar2.Value;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            point3.X = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            point2.X = trackBar4.Value;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            point4.X = trackBar5.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            point1.color = Color.Pink;
            point2.color = Color.Tomato;
            point3.color = Color.CadetBlue;
            point4.color = Color.YellowGreen;
            label4.Text = "Pink";
            label5.Text = "CadetBlue";
            label6.Text = "Tomato";
            label7.Text = "YellowGreen";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            point1.color = Color.Purple;
            point2.color = Color.Aqua;
            point3.color = Color.Violet;
            point4.color = Color.Aquamarine;
            label4.Text = "Purple";
            label5.Text = "Aqua";
            label6.Text = "Violet";
            label7.Text = "Aquamarine";
        }
    }
}
