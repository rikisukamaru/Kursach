﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class LinEmmiter : Emmiter
    {
        public int Width; // длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое
            
            // а теперь тут уже подкручиваем параметры движения
            particle.X = Particle.rnd.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;  // ноль -- это верх экрана 
            var direction = Direction
               + (double)Particle.rnd.Next(Spreading)
               - Spreading / 2;

            var speed = Particle.rnd.Next(SpeedMin);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed); // падаем вниз по умолчанию
            particle.SpeedX = Particle.rnd.Next(-2, 2); // разброс влево и вправа у частиц 
        }


    }
}
