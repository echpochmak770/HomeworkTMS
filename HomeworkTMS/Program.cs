using System;
using HomeworkTMS;

namespace HomeworkTMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Системная регистрация ===");

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Console.Write("Подтвердите пароль: ");
            string confirmPassword = Console.ReadLine();

            Console.WriteLine("\nПроверка данных...");

            try
            {
                bool isSuccess = AuthService.CheckCredentials(login, password, confirmPassword);

                if (isSuccess)
                {
                    Console.WriteLine("Успех! Данные валидны.");
                }
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine($"Ошибка в логине: {ex.Message}");
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine($"Ошибка в пароле: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}