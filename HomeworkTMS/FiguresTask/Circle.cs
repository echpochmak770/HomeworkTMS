using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.FiguresTask
{
    internal class Circle : Figure
    {
        public double Radius { 
            get; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Радиус не может быть меньше или равен 0");
                }
                field = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
