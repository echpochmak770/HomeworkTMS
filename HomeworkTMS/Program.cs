using System;
using HomeworkTMS.SmartHomeTask;

namespace HomeworkTMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. Инициализация Умного Дома ---\n");
            SmartHomeHub hub = new SmartHomeHub();

            SmartLamp lamp = new SmartLamp("SmartLamp-1", hub);
            SecuritySiren siren = new SecuritySiren("SecuritySiren-1", hub);
            SmartThermostat thermostat = new SmartThermostat("SmartThermostat-1", hub);
            SmartphoneApp phoneApp = new SmartphoneApp("UserPhone-1", hub)
            {
                MinimalNotifiablePriority = 3
            };

            Console.WriteLine("Устройства зарегистрированы в хабе." +
                "\n\n--- --------------------------------- ---\n");

            Console.WriteLine("--- 2. Демонстрация: ПОЖАРНАЯ ТРЕВОГА (FireAlarm) ---");
            hub.TriggerFireAlarm();
            Console.WriteLine("\n--- --------------------------------- ---\n");

            Console.WriteLine("--- 3. Демонстрация: ОБЫЧНОЕ ДВИЖЕНИЕ (MotionRoutine) ---");
            hub.TriggerMotion();
            Console.WriteLine("\n--- --------------------------------- ---\n");

            Console.WriteLine("--- 4. Изменение приоритета уведомлений в приложении на 1 ---");
            phoneApp.MinimalNotifiablePriority = 1;

            Console.WriteLine($"Приложение [{phoneApp.Name}] будет уведомлять о событиях с приоритетом 1 и выше.");
            hub.TriggerMotion();
            Console.WriteLine("\n--- --------------------------------- ---\n");

            Console.ReadKey();
        }
    }
}