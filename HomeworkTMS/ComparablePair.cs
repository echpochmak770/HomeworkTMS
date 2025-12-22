using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class ComparablePair<T, U> : IComparable<ComparablePair<T, U>> 
        where T : IComparable<T>
        where U : IComparable<U>
    {
        private readonly Pair<T, U> _pair;

        public Pair<T, U> Pair { get { return _pair; } }

        public ComparablePair(Pair<T, U> pair)
        {
            _pair = pair;
        }

        public int CompareTo(ComparablePair<T, U> other)
        {
            var firstValueComparison = this.Pair.First.CompareTo(other.Pair.First);
            if (firstValueComparison != 0)
            {
                return firstValueComparison;
            }

            var secondValueComparison = this.Pair.Second.CompareTo(other.Pair.Second);
            return secondValueComparison;
        }
    }
}
