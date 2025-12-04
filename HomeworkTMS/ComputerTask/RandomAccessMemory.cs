using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.ComputerTask
{
    internal class RandomAccessMemory
    {
        public string Name  { get; set; }
        public int CapacityGigabytes { get; set; }

        public RandomAccessMemory(string name, int capacityGigabytes)
        {
            Name = name;
            CapacityGigabytes = CapacityGigabytes;
        }

        public RandomAccessMemory() : this("Unknown", 0) { }

        public void GetInfo()
        {
            Console.WriteLine($"Оперативная память" +
                $"\nИмя: {Name}" +
                $"\nОбъём: {CapacityGigabytes} Gb");
        }
    }
}
