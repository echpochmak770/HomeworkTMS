using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class WrongLoginException : Exception
    {
        public LoginFailureReason Reason { get; }

        public WrongLoginException() { }

        public WrongLoginException(string message) : base(message) { }

        public WrongLoginException(string message, Exception inner, LoginFailureReason reason) : base(message, inner)
        {
            this.Reason = reason;
        }

        public WrongLoginException(string message, LoginFailureReason reason) : base(message)
        {
            this.Reason = reason;
        }
    }
}
