using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal class SmartHomeHub
    {
        public event EventHandler<HubEvent> OnEvent;

        protected void RaiseEvent(HubEvent e)
        {
            OnEvent?.Invoke(this, e);
        }

        public void TriggerFireAlarm()
        {
            var e = new HubEvent(HubEventType.FireAlarm);
            Console.WriteLine($"Вызвано событие: {e.ToString()}");
            RaiseEvent(e);
        }

        public void TriggerMotion()
        {
            var e = new HubEvent(HubEventType.MotionRoutine);
            Console.WriteLine($"Вызвано событие: {e.ToString()}");
            RaiseEvent(e);
        }
    }
}
