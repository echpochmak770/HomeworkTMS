using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintResult(string title, object data)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- {title.ToUpper()} ---");
            Console.ResetColor();

            if (data is IEnumerable<object> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(data?.ToString() ?? "Данные не найдены");
            }
            Console.WriteLine(new string('-', title.Length + 8));
        }
    }
}
