using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kursach
{
    class Audi : Emmiter
    {

        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Blue, 4), 450, 150, 70, 70);
        }
    }

}
