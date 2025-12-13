using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class SmartThermostat : ISmartDevice
    {
        public string Name { get; set; }

        public SmartThermostat(string name, SmartHomeHub hub)
        {
            Name = name;
            hub.OnEvent += this.ReactToEvent;
        }

        public void ReactToEvent(object sender, HubEvent eventData)
        {
            if (eventData.Type == HubEventType.TemperatureHigh || eventData.Type == HubEventType.FireAlarm)
            {
                Console.WriteLine($"[{this.Name}] Становится подозрительно жарко");
            }
        }
    }
}
