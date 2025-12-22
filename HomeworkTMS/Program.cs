using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComparablePair<double, string> firstComparablePair = new(new Pair<double, string>(12.0, "bbbb"));
            ComparablePair<double, string> secondComparablePair = new(new Pair<double, string>(10.0, "bbbb"));
            ComparablePair<double, string> thirdComparablePair = new(new Pair<double, string>(15.0, "bbbb"));
            ComparablePair<double, string> fourthComparablePair = new(new Pair<double, string>(12.0, "aaaa"));
            ComparablePair<double, string> fifthComparablePair = new(new Pair<double, string>(12.0, "cccc"));
            ComparablePair<double, string> sixthComparablePair = new(new Pair<double, string>(12.0, "bbbb"));

            Console.WriteLine($"Первое сравнение (ожидается 1): {firstComparablePair.CompareTo(secondComparablePair)}" +
                $"\nВторое сравнение (ожидается -1): {firstComparablePair.CompareTo(thirdComparablePair)}" +
                $"\nТретье сравнение (ожидается 1): {firstComparablePair.CompareTo(fourthComparablePair)}" +
                $"\nЧетвёртое сравнение (ожидается -1): {firstComparablePair.CompareTo(fifthComparablePair)}" +
                $"\nПятое сравнение (ожидается 0): {firstComparablePair.CompareTo(sixthComparablePair)}");
        }
    }
}
