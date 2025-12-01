using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Patient
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string MedicalCardNumber { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public Doctor AssignedDoctor { get; set; }
        public Patient(string fullName, int age, string medicalCardNumber)
        {
            FullName = fullName;
            Age = age;
            MedicalCardNumber = medicalCardNumber;
        }

        public void AddTreatmentPlan(TreatmentPlan plan)
        {
            TreatmentPlan = plan;
            Console.WriteLine($"Пациенту {FullName} назначен план лечения:");
            plan.DisplayInfo();
        }

        public void AssignDoctor()
        {
            if (TreatmentPlan == null)
            {
                Console.WriteLine($"Ошибка: Для пациента {FullName} не назначен план лечения!\n");
                return;
            }

            Console.WriteLine($"Назначаю врача для пациента {FullName}:");

            switch (TreatmentPlan.Code)
            {
                case 1:
                    AssignedDoctor = new Surgeon("Иванов А.С.");
                    Console.WriteLine($"  Назначен: {AssignedDoctor.Name} ({AssignedDoctor.Specialization})");
                    Console.WriteLine($"  Причина: План лечения код {TreatmentPlan.Code} - требуется операция\n");
                    break;

                case 2:
                    AssignedDoctor = new Dentist("Петрова Е.В.");
                    Console.WriteLine($"  Назначен: {AssignedDoctor.Name} ({AssignedDoctor.Specialization})");
                    Console.WriteLine($"  Причина: План лечения код {TreatmentPlan.Code} - стоматологическое лечение\n");
                    break;

                default:
                    AssignedDoctor = new Therapist("Сидоров П.И.");
                    Console.WriteLine($"  Назначен: {AssignedDoctor.Name} ({AssignedDoctor.Specialization})");
                    Console.WriteLine($"  Причина: План лечения код {TreatmentPlan.Code} - общее лечение\n");
                    break;
            }
        }

        public void PerformTreatment()
        {
            if (AssignedDoctor == null)
            {
                Console.WriteLine($"Ошибка: Пациенту {FullName} не назначен врач!\n");
                return;
            }

            Console.WriteLine($"Начинаем лечение пациента {FullName}:");
            Console.WriteLine($"Врач: {AssignedDoctor.Name}");
            Console.WriteLine($"План лечения код: {TreatmentPlan.Code} ({TreatmentPlan.Diagnosis})");
            Console.WriteLine("----------------------------------------");

            AssignedDoctor.Treat();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Пациент: {FullName}");
            Console.WriteLine($"  Возраст: {Age} лет");
            Console.WriteLine($"  Номер медкарты: {MedicalCardNumber}");

            if (TreatmentPlan != null)
            {
                Console.WriteLine($"  План лечения код: {TreatmentPlan.Code}");
                Console.WriteLine($"  Диагноз: {TreatmentPlan.Diagnosis}");
            }
            else
            {
                Console.WriteLine($"  План лечения: не назначен");
            }

            if (AssignedDoctor != null)
            {
                Console.WriteLine($"  Лечащий врач: {AssignedDoctor.Name} ({AssignedDoctor.Specialization})");
            }
            else
            {
                Console.WriteLine($"  Лечащий врач: не назначен");
            }
            Console.WriteLine();
        }
    }
}
