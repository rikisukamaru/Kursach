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
        }
    // а сюда по сути скопировали с минимальными правками то что было в UpdateState
    public override void ImpactParticle(Particle particle)
    {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            Color pp = Color.Purple;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < rad / 2) // если частица оказалось внутри окружности
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
            }
    }
  
   }
}
