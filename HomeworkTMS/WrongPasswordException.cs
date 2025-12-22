using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class WrongPasswordException : Exception
    {
        public PasswordFailureReason Reason { get; }

        public WrongPasswordException() { }

        public WrongPasswordException(string message) : base(message) { }

        public WrongPasswordException(string message, Exception inner, PasswordFailureReason reason) : base(message, inner)
        {
            this.Reason = reason;
        }

        public WrongPasswordException(string message, PasswordFailureReason reason) : base(message)
        {
            this.Reason = reason;
        }
    }
}
