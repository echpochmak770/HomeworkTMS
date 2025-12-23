using System;
using System.Linq;

namespace HomeworkTMS
{
    internal static class AuthService
    {
        private static readonly Action<string>[] LoginRules =
        {
            value =>
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value), "Логин не может быть null");
            },
            value =>
            {
                if (value.Length > 20)
                    throw new WrongLoginException(
                        "Длина логина не может превышать 20",
                        LoginFailureReason.LengthBiggerThan20);
            },
            value =>
            {
                if (value.Any(char.IsWhiteSpace))
                    throw new WrongLoginException(
                        "Логин не может содержать пробелы",
                        LoginFailureReason.HasWhitespaces);
            }
        };

        private static readonly Action<string>[] PasswordRules =
        {
            value =>
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value), "Пароль не может быть null");
            },
            value =>
            {
                if (value.Length > 20)
                    throw new WrongPasswordException(
                        "Длина пароля не может превышать 20",
                        PasswordFailureReason.LengthBiggerThan20);
            },
            value =>
            {
                if (value.Any(char.IsWhiteSpace))
                    throw new WrongPasswordException(
                        "Пароль не может содержать пробелы",
                        PasswordFailureReason.HasWhiteSpaces);
            },
            value =>
            {
                if (!value.Any(char.IsDigit))
                    throw new WrongPasswordException(
                        "В пароле должна быть хотя бы одна цифра",
                        PasswordFailureReason.HasNoDigits);
            }
        };

        public static bool CheckCredentials(string login, string password, string confirmPassword)
        {
            foreach (var rule in LoginRules)
            {
                rule(login);
            }

            foreach (var rule in PasswordRules)
            {
                rule(password);
            }

            if (confirmPassword is null)
            {
                throw new ArgumentNullException(nameof(confirmPassword),
                    "Подтверждение пароля не может быть null");
            }

            if (!password.Equals(confirmPassword))
            {
                throw new WrongPasswordException(
                    "Пароли не совпадают",
                    PasswordFailureReason.ConfirmPasswordMismatch);
            }

            return true;
        }
    }
}
