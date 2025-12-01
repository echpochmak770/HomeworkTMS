using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    /*Создать программу для имитации работы клиники.
    Пусть в клинике будет три врача: хирург, терапевт и дантист.
    Каждый врач имеет метод «лечить», но каждый врач лечит по-своему.
    Так же предусмотреть класс «Пациент» и класс «План лечения».
    Создать объект класса «Пациент» и добавить пациенту план лечения.
    Так же создать метод, который будет назначать врача пациенту согласно
    плану лечения.
    Если план лечения имеет код 1 – назначить хирурга и выполнить метод
    лечить.
    Если план лечения имеет код 2 – назначить дантиста и выполнить метод
    лечить.
    Если план лечения имеет любой другой код – назначить терапевта и
    выполнить метод лечить.*/

    internal class Clinic
    {
        private List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
            Console.WriteLine($"Пациент {patient.FullName} добавлен в клинику.\n");
        }

        public void ProcessAllPatients()
        {
            Console.WriteLine("=== ОБРАБОТКА ВСЕХ ПАЦИЕНТОВ ===\n");

            foreach (var patient in patients)
            {
                Console.WriteLine($"Обработка пациента: {patient.FullName}");
                Console.WriteLine("----------------------------------------");

                if (patient.TreatmentPlan == null)
                {
                    Console.WriteLine("Пропускаем - нет плана лечения\n");
                    continue;
                }

                patient.AssignDoctor();
                patient.PerformTreatment();
            }
        }

        public void DisplayAllPatients()
        {
            Console.WriteLine("=== СПИСОК ПАЦИЕНТОВ КЛИНИКИ ===\n");

            foreach (var patient in patients)
            {
                patient.DisplayInfo();
            }
        }
    }
}
