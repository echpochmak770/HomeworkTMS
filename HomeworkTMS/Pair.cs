using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Pair<S, T>
    {
        private readonly S _first;
        private readonly T _second;

        public S First { get { return _first; } }
        public T Second { get { return _second; } }

        public Pair(S first, T second)
        {
            if (first is null || second is null)
            {
                throw new ArgumentNullException("Ни одно поле Pair не может быть null");
            }

            _first = first;
            _second = second;
        }
    }
}
