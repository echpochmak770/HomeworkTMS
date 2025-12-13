using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.SmartHomeTask
{
    internal interface ISmartDevice
    {
        string Name { get; set; }
        void ReactToEvent(object sender, HubEvent eventData);

    }
}
