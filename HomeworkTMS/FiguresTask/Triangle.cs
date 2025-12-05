using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.FiguresTask
{
    internal class Triangle : Figure
    {
        public double FirstSide { 
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
        public double SecondSide { 
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
        public double ThirdSide { 
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

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public override double CalculateArea()
        {
            //Формула Герона
            double sidesHalfSum = (FirstSide + SecondSide + ThirdSide) / 2.0;
            return Math.Sqrt(sidesHalfSum * (sidesHalfSum - FirstSide) * (sidesHalfSum - SecondSide) * (sidesHalfSum - ThirdSide));
        }

        public override double CalculatePerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }
    }
}
