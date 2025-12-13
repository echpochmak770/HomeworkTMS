using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class SmartLamp : ISmartDevice
    {
        public string Name { get; set; }

        public SmartLamp(string name, SmartHomeHub hub)
        {
            Name = name;
            hub.OnEvent += this.ReactToEvent;
        }

        public void ReactToEvent(object sender, HubEvent eventData)
        {
            if (eventData.Type == HubEventType.MotionRoutine)
            {
                Console.WriteLine($"[{this.Name}] Замечено рутинное движение. Включаю свет");
            }
            else if (eventData.Type == HubEventType.FireAlarm)
            {
                Console.WriteLine($"[{this.Name}] Пожарная тревога. Мигаю красным");
            }
            
        }
    }
}
