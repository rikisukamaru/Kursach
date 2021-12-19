using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kursach
{
   public class GravityPoint : ImpactPoint
  {
        int rad = 80;
        public override void Render(Graphics g)
        {

            g.DrawEllipse(
               new Pen(Color.Red),
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
          
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < rad/2 ) // если частица оказалось внутри окружности
           {

                if (particle is ParticleColor particleColor)
                {
                    particleColor.FromColor = Color.Red;
                    particleColor.ToColor = Color.FromArgb(0,Color.Red);
                }

            }
    }
  
}
}
