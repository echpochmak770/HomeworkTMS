using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    internal static class DocumentIdGenerator
    {
        private static int _currentId = 0;

        public static int GetNextId()
        {
            _currentId++;
            return _currentId;
        }
    }
}
