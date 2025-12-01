using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Surgeon : Doctor
    {
        public Surgeon(string name) : base(name, "Хирург") { }

        public override void Treat()
        {
            Console.WriteLine($"Доктор {Name} ({Specialization}): Провожу операцию");
            Console.WriteLine("  - Делаю разрез");
            Console.WriteLine("  - Устраняю проблему");
            Console.WriteLine("  - Накладываю швы");
            Console.WriteLine("  - Операция завершена успешно!\n");
        }
    }
}
