using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.EmployeesTask
{
    internal class Accountant : IEmployee
    {
        public void PrintJobTitle()
        {
            Console.WriteLine("Бухгалтер");
        }
    }
}
