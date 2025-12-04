using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeworkTMS.CreditCardTask
{
    internal class CreditCard
    {
        private static readonly Regex AllowedChars = new Regex(@"^[0-9\s-]+$");

        public string AccountNumber {
            get;
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Номер карты не может быть пустым");
                }

                if (!AllowedChars.IsMatch(value))
                {
                    throw new ArgumentException("В номере банковской карты могут быть только цифры, пробелы и \'-\'");
                }

                var digitsOnly = Regex.Replace(value, @"\D", "");

                if (digitsOnly.Length < 13 || digitsOnly.Length > 19)
                {
                    throw new ArgumentException("В номере банковской карты должно быть от 13 до 19 цифр");
                }

                if (!IsValidLuhn(digitsOnly))
                {
                    throw new ArgumentException("Номер карты не прошёл проверку алгоритмом Луна");
                }

                field = digitsOnly;
            }
        }

        public double CurrentAmount { get; set; }

        public CreditCard(string accountNumber, double startAmount)
        {
            this.AccountNumber = accountNumber;
            this.CurrentAmount = startAmount;
        }

        public CreditCard(string accountNumber) : this(accountNumber, 0) { }

        public void Withdraw(double amount)
        {
            if (amount <= 5)
            {
                throw new ArgumentException("Нельзя вывести сумму меньшую или равную 5 белорусским рублям");
            }

            if (amount % 5 != 0)
            {
                throw new ArgumentException("Нельзя вывести сумму не кратную 5 белорусским рублям");
            }

            if (amount > CurrentAmount)
            {
                throw new ArgumentException("Нельзя вывести сумму больше всей суммы текущего баланса");
            }

            this.CurrentAmount -= amount;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Нельзя положить на карту отрицательную или нулевую сумму");
            }

            this.CurrentAmount += amount;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Номер карточки: {AccountNumber}" +
                $"\nСумма на счёте: {CurrentAmount}");
        }

        /// <summary>
        /// Проверка валидности номера банковской карты алгоритмом Луна
        /// </summary>
        private static bool IsValidLuhn(string digits)
        {
            int sum = 0;
            bool doubleDigit = false;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int d = digits[i] - '0';
                if (doubleDigit)
                {
                    d *= 2;
                    if (d > 9) d -= 9;
                }
                sum += d;
                doubleDigit = !doubleDigit;
            }
            return (sum % 10 == 0);
        }
    }
}
