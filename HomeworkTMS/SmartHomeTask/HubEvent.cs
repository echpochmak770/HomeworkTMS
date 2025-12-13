using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class HubEvent
    {
        public HubEventType Type { get; init; }
        public DateTime TimeStamp { get; init; }
        public int Priority { 
            get;
            init
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Приоритет события может быть целым числом от 1 до 5");
                }
                field = value;
            }
        }

        public HubEvent(HubEventType type)
        {
            Type = type;
            TimeStamp = DateTime.Now;
            Priority = GetPriority(type);
        }

        private static int GetPriority(HubEventType type)
        {
            return type switch
            {
                HubEventType.FireAlarm => 5,
                HubEventType.GasLeak => 5,

                HubEventType.Intrusion => 4,

                HubEventType.TemperatureHigh => 3,
                HubEventType.HubOffline => 3,

                HubEventType.LowBattery => 2,
                HubEventType.DorbellPress => 2,

                HubEventType.MotionRoutine => 1,

                _ => 1
            };
        }

        public override string ToString()
        {
            return $"\nТип события: [{Type}]" +
                $"\nДата и время возникновения: [{TimeStamp.ToString()}]" +
                $"\nПриоритет: [{Priority}]";
        }
    }

    enum HubEventType
    {
        FireAlarm, 
        GasLeak,

        Intrusion, 

        TemperatureHigh, 
        HubOffline,

        LowBattery, 
        DorbellPress,

        MotionRoutine 
    }
}
