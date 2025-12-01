using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Therapist : Doctor
    {
        public Therapist(string name) : base(name, "Терапевт") { }

        public override void Treat()
        {
            Console.WriteLine($"Доктор {Name} ({Specialization}): Провожу общее лечение");
            Console.WriteLine("  - Измеряю давление и температуру");
            Console.WriteLine("  - Слушаю легкие");
            Console.WriteLine("  - Выписываю рецепт");
            Console.WriteLine("  - Назначаю постельный режим");
            Console.WriteLine("  - Общее лечение завершено!\n");
        }
    }
}
