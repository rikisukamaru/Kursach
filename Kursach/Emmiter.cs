using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kursach
{
   public class Emmiter
    {
        List<Particle> particles = new List<Particle>();
        public List<Point> gravityPoints = new List<Point>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0;
        public int ParticlesCount = 1000;


        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rnd.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rnd.Next(360);
            var speed = 10 + Particle.rnd.Next(30);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rnd.Next(10);
        }

        public void UpdateState()
        {
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = new ParticleColor();
                    particle.FromColor = Color.White;
                    particle.ToColor = Color.FromArgb(0, Color.Black);

                    ResetParticle(particle); // добавили вызов ResetParticle

                    particles.Add(particle);
                }
                else
                {
                    break;
                }

            }

            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                    /* // восстанавливаю здоровье
                     particle.Life = 20 + Particle.rnd.Next(100);
                     // перемещаю частицу в центр
                     particle.X = MousePositionX;
                     particle.Y = MousePositionY;
                     var direction = (double)Particle.rnd.Next(360);
                     var speed = 1 + Particle.rnd.Next(10);

                     particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                     particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                     particle.Radius = 2 + Particle.rnd.Next(10);
                    */
                }
                else
                {
                    foreach (var point in gravityPoints)
                    {
                        float gX = point.X - particle.X;
                        float gY = point.Y - particle.Y;
                        float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                        float M = 100;

                        particle.SpeedX += (gX) * M / r2;
                        particle.SpeedY += (gY) * M / r2;
                    }


                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
               
            }

        }

        // функция рендеринга
      public void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in gravityPoints)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Blue),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
            }
        }
    }
}
