using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTMS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PhoneTaskDemo();
            ClinicTaskDemo();
        }

        static void PhoneTaskDemo()
        {
            Phone phone1 = new Phone("375291112233", "Samsung", 150);
            Phone phone2 = new Phone("375447778899", "iPhone");
            Phone phone3 = new Phone();

            Console.WriteLine("Демонстрация объектов Phone:");
            Console.WriteLine($"Телефон 1: номер = {phone1.GetNumber()}");
            Console.WriteLine($"Телефон 2: номер = {phone2.GetNumber()}");
            Console.WriteLine($"Телефон 3: номер = {phone3.GetNumber()}");

            Console.WriteLine();

            Console.WriteLine("Демонстрация receiveCall:");
            phone1.ReceiveCall("Андрей");
            phone2.ReceiveCall("Мария");
            phone3.ReceiveCall("Неизвестный");

            Console.WriteLine();

            Console.WriteLine("Демонстрация перегруженного receiveCall:");
            phone1.ReceiveCall("Олег", "375331234567");

            Console.WriteLine();

            Console.WriteLine("Демонстрация sendMessage:");
            phone1.SendMessage("111", "222", "333", "444");

            Console.WriteLine();

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ClinicTaskDemo()
        {
            Console.WriteLine("=== ПРОГРАММА ИМИТАЦИИ РАБОТЫ КЛИНИКИ ===\n");

            Clinic clinic = new Clinic();

            Patient patient1 = new Patient("Смирнов Алексей Петрович", 45, "MC-2024-001");
            Patient patient2 = new Patient("Ковалева Мария Ивановна", 32, "MC-2024-002");
            Patient patient3 = new Patient("Николаев Дмитрий Сергеевич", 28, "MC-2024-003");
            Patient patient4 = new Patient("Орлова Екатерина Викторовна", 55, "MC-2024-004");

            TreatmentPlan plan1 = new TreatmentPlan(1, "Аппендицит", "Требуется срочная операция по удалению аппендикса");
            TreatmentPlan plan2 = new TreatmentPlan(2, "Кариес", "Лечение кариеса на 3-х зубах, профессиональная чистка");
            TreatmentPlan plan3 = new TreatmentPlan(3, "Грипп", "Острое респираторное вирусное заболевание");
            TreatmentPlan plan4 = new TreatmentPlan(0, "Общее обследование", "Плановый медицинский осмотр");

            clinic.AddPatient(patient1);
            clinic.AddPatient(patient2);
            clinic.AddPatient(patient3);
            clinic.AddPatient(patient4);

            Console.WriteLine("=== НАЗНАЧЕНИЕ ПЛАНОВ ЛЕЧЕНИЯ ===\n");
            patient1.AddTreatmentPlan(plan1);
            patient2.AddTreatmentPlan(plan2);
            patient3.AddTreatmentPlan(plan3);
            patient4.AddTreatmentPlan(plan4);

            clinic.DisplayAllPatients();

            clinic.ProcessAllPatients();

            Console.WriteLine("\n=== ДОПОЛНИТЕЛЬНАЯ ДЕМОНСТРАЦИЯ ===\n");

            Patient patient5 = new Patient("Безплановый Пациент", 30, "MC-2024-005");
            clinic.AddPatient(patient5);

            Console.WriteLine("Демонстрация: пациент без плана лечения");
            patient5.AssignDoctor();

            Console.WriteLine("Демонстрация: попытка лечения без врача");
            patient5.PerformTreatment();

            Console.WriteLine("\n=== РАБОТА КЛИНИКИ ЗАВЕРШЕНА ===");
            Console.ReadKey();
        }
    }
}