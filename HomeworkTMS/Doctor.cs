using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal abstract class Doctor
    {
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Doctor(string name, string specialization)
        {
            Name = name;
            Specialization = specialization;
        }

        public abstract void Treat();
    }
}
