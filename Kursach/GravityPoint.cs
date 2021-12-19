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
        
        public override void Render(Graphics g)
        {
       
            g.DrawEllipse(
               new Pen(Color.Red),X,Y, 80, 80
           );
        }
    // а сюда по сути скопировали с минимальными правками то что было в UpdateState
    public override void ImpactParticle(Particle particle)
    {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            List<Particle> particles = new List<Particle>();
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < X || r + particle.Radius < Y) // если частица оказалось внутри окружности
           {
                particles.Add(particle.Color = Color.Red);

           }
    }
  
}
}
