using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kursach
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g) // добавил слово virtual, ну чтобы override потом можно было юзать
        {
          
        }
    }
}
