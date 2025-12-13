using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class SecuritySiren : ISmartDevice
    {
        public string Name { get; set; }

        public SecuritySiren(string name, SmartHomeHub hub)
        {
            Name = name;
            hub.OnEvent += ReactToEvent;
        }

        public void ReactToEvent(object sender, HubEvent eventData)
        {
            if (eventData.Priority > 3)
            {
                Console.WriteLine($"[{this.Name}] Замечено событие с высоким приоритетом. Издаю неприятные для ушей звуки!!!");
            }
        }
    }
}
