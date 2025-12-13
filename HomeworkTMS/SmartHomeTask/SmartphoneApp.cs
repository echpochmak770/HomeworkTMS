using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class SmartphoneApp : ISmartDevice
    {
        public string Name { get; set; }
        public int MinimalNotifiablePriority { 
            get;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Приоритет события может быть только целым числом от 1 до 5");
                }
                field = value;
            }
        }

        public SmartphoneApp(string name, SmartHomeHub hub)
        {
            Name = name;
            hub.OnEvent += this.ReactToEvent;
        }

        public void ReactToEvent(object sender, HubEvent eventData)
        {
            if (eventData.Priority >= MinimalNotifiablePriority)
            {
                Console.WriteLine($"[{this.Name}] Произошло событие с указанным приоритетом или выше");
            }
        }
    }
}
