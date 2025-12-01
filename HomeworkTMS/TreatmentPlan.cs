using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class TreatmentPlan
    {
        public int Code { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public TreatmentPlan(int code, string diagnosis, string description)
        {
            Code = code;
            Diagnosis = diagnosis;
            Description = description;
            CreatedDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"План лечения:");
            Console.WriteLine($"  Код: {Code}");
            Console.WriteLine($"  Диагноз: {Diagnosis}");
            Console.WriteLine($"  Описание: {Description}");
            Console.WriteLine($"  Дата создания: {CreatedDate:dd.MM.yyyy}\n");
        }
    }
}
