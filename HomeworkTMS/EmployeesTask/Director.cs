using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.EmployeesTask
{
    internal class Director : IEmployee
    {
        public void PrintJobTitle()
        {
            Console.WriteLine("Директор");
        }
    }
}
