using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.ComputerTask
{
    internal class Computer
    {
        public string Model { get; set; }
        public HardDiskDrive HDD { get; set; }
        public RandomAccessMemory RAM { get; set; }
        public double Price { get; set; }

        public Computer(double price, string model, HardDiskDrive hDD, RandomAccessMemory rAM)
        {
            Price = price;
            Model = model;
            HDD = hDD;
            RAM = rAM;
        }

        public Computer(double price, string model) : this(price, model, new HardDiskDrive(), new RandomAccessMemory()) { }

        public void GetInfo()
        {
            Console.WriteLine($"Модель компьютера: {Model}");
            this.HDD.GetInfo();
            this.RAM.GetInfo();
            Console.WriteLine($"Цена: {Price}");
        }
    }
}
