using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    public enum PasswordFailureReason
    {
        LengthBiggerThan20,
        HasWhiteSpaces,
        HasNoDigits,
        ConfirmPasswordMismatch,
        Default
    }
}
