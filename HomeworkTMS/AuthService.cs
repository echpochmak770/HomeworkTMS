using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal static class AuthService
    {
        public static bool CheckCredentials(string login, string password, string confirmPassword)
        {
            if (login is null)
            {
                throw new ArgumentNullException("Логин не может быть null");
            }

            if (password is null)
            {
                throw new ArgumentNullException("Пароль не может быть null");
            }

            if (confirmPassword is null)
            {
                throw new ArgumentNullException("Подтверждение пароля не может быть null");
            }

            if (login.Length > 20)
            {
                throw new WrongLoginException("Длина логина не может превышать 20", LoginFailureReason.LengthBiggerThan20);
            }

            if (login.Any(char.IsWhiteSpace))
            {
                throw new WrongLoginException("Логин не может содержать пробелы", LoginFailureReason.HasWhitespaces);
            }

            if (password.Length > 20)
            {
                throw new WrongPasswordException("Длина пароля не может превышать 20", PasswordFailureReason.LengthBiggerThan20);
            }

            if (password.Any(char.IsWhiteSpace))
            {
                throw new WrongPasswordException("Пароль не может одержать пробелы", PasswordFailureReason.HasWhiteSpaces);
            }

            if (!password.Any(char.IsDigit))
            {
                throw new WrongPasswordException("В пароле должна быть хотя бы одна цифра", PasswordFailureReason.HasNoDigits);
            }

            if (!password.Equals(confirmPassword))
            {
                throw new WrongPasswordException("Пароли не совпадают", PasswordFailureReason.ConfirmPasswordMismatch);
            }

            return true;
        }
    }
}
