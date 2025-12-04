using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.ComputerTask
{
    internal class HardDiskDrive
    {
        public string Name { get; set; }
        public int CapacityGigabytes { get; set; }
        public HardDiskDriveType Type { get; set; }

        public HardDiskDrive(string name, int capacityGigabytes, HardDiskDriveType type)
        {
            Name = name;
            CapacityGigabytes = capacityGigabytes;
            Type = type;
        }

        public HardDiskDrive() : this("Unknown", 0, HardDiskDriveType.NotSpecified) { }

        public void GetInfo()
        {
            Console.WriteLine($"Жёсткий диск" +
                $"\nИмя: {Name}" +
                $"\nОбъём: {CapacityGigabytes} Gb" +
                $"\nТип: {Type}");
        }
    }

    enum HardDiskDriveType
    {
        External,
        Internal,
        NotSpecified
    }
}
