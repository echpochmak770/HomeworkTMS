using System;
using System.Collections.Generic;
using System.Text;
using HomeworkTMS.EmployeesTask;
using HomeworkTMS.FiguresTask;
using HomeworkTMS.DocumentAccounting;

namespace HomeworkTMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo_FiguresTask();
            Demo_EmployeesTask();
            Demo_DocumentAccounting();
        }

        static void WaitForContinue()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }

        static void Demo_FiguresTask()
        {
            var list = new List<Figure>();

            list.Add(new Circle(12));
            list.Add(new Circle(24));
            list.Add(new Triangle(13, 14, 15));
            list.Add(new Triangle(3, 4, 5));
            list.Add(new Rectangle(15, 20));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Фигура {i + 1}:" +
                    $"\nПлощадь = {list[i].CalculateArea()}" +
                    $"\nПериметр = {list[i].CalculatePerimeter()}");
            }

            WaitForContinue();
        }

        static void Demo_EmployeesTask()
        {
            var employees = new List<IEmployee>();
            employees.Add(new Director());
            employees.Add(new Worker());
            employees.Add(new Accountant());

            foreach (var employee in employees)
            {
                employee.PrintJobTitle();
            }

            WaitForContinue();
        }

        static void Demo_DocumentAccounting()
        {
            var register = new Register();
            register.AddDocument(new ProductSupplyAgreement(10, ProductType.Clothing));
            register.AddDocument(new EmployeeContract(1, "Артемий"));
            register.AddDocument(new FinancialInvoice(10000, Departments.IT));

            register.GetInfoAt(1);
            register.GetInfoAt(2);
            register.GetInfoAt(3);
            register.GetInfoAt(4);
        }
    }
}
