using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Dentist : Doctor
    {
        public Dentist(string name) : base(name, "Стоматолог") { }

        public override void Treat()
        {
            Console.WriteLine($"Доктор {Name} ({Specialization}): Лечу зубы");
            Console.WriteLine("  - Проверяю полость рта");
            Console.WriteLine("  - Провожу лечение кариеса");
            Console.WriteLine("  - Чищу зубы");
            Console.WriteLine("  - Лечение зубов завершено!\n");
        }
    }
}
