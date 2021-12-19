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
        public List<ImpactPoint> impactPoints = new List<ImpactPoint>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0;
        public int ParticlesCount = 1000;
        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public virtual void ResetParticle(Particle particle)
        {
            
            particle.Life = Particle.rnd.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rnd.Next(Spreading)
                - Spreading / 2;

           var speed = Particle.rnd.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rnd.Next(RadiusMin, RadiusMax);
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
                   
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }


                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
               
            }

        }

        // функция рендеринга
        public virtual void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints) // тут теперь  impactPoints
            {
                point.Render(g);
            }
        }
    }
}
