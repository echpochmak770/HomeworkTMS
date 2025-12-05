using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.FiguresTask
{
    internal class Rectangle : Figure
    {
        public double Length { 
            get;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина не может быть меньше или равен 0");
                }

                field = value;
            }
        }
        public double Width { 
            get; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина не может быть меньше или равен 0");
                }

                field = value;
            }
        }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }
    }
}
