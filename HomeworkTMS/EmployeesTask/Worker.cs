using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.EmployeesTask
{
    internal class Worker : IEmployee
    {
        public void PrintJobTitle()
        {
            Console.WriteLine("Рабочий");
        }
    }
}
