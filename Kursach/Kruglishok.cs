using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kursach
{
   public class Kruglishok : ImpactPoint
  {
       public int rad = 80;
       
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
               new Pen(color),
               X - rad/2,
               Y - rad/2,
               rad,
              rad
           );
            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

            if (color == Color.Red)
            {
                if (schet >= 250)
                {
                    g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - rad / 2,
                    Y - rad / 2,
                    rad,
                    rad);
                    g.DrawString(
                    $"{schet}",
                    new Font("Verdana", 14),
                    new SolidBrush(Color.DeepSkyBlue),
                    X,
                    Y,
                    stringFormat
                     );
                }
                else
                {
                    g.DrawString(
                     $"{schet}",
                     new Font("Verdana", 10),
                     new SolidBrush(Color.DeepSkyBlue),
                     X,
                     Y,
                     stringFormat
                      );
                }
            }
            
        }
       
    
    public override void ImpactParticle(Particle particle)
    {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            Color pp = Color.Purple;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius <rad/2) // если частица оказалось внутри окружности
            {
                if (color == Color.Aqua)
                {
                    if (particle is ParticleColor particleColor)
                    {
                        particleColor.FromColor = Color.Aqua;
                        particleColor.ToColor = Color.FromArgb(0, Color.Aqua);
                    }

                }
                else if (color == Color.Purple)
                {
                    if (particle is ParticleColor particleColor)
                    {
                        particleColor.FromColor = Color.Purple;
                        particleColor.ToColor = Color.FromArgb(0, Color.Purple);
                    }
                }
                else if(color == Color.Violet)
                {
                    if (particle is ParticleColor particleColor)
                    {
                        particleColor.FromColor = Color.Violet;
                        particleColor.ToColor = Color.FromArgb(0, Color.Violet);
                    }
                }
                else if(color == Color.Aquamarine)
                {
                    if (particle is ParticleColor particleColor)
                    {
                        particleColor.FromColor = Color.Aquamarine;
                        particleColor.ToColor = Color.FromArgb(0, Color.Aquamarine);
                    }
                }
                else if(color == Color.Red)
                {
                    schet++;                  
                    particle.Life = 0;
                }
            }
    }
  
   }
}
