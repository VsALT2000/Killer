using System.Collections;
using System.Collections.Generic;

namespace Killer.Architecture
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public readonly T Value;
        private readonly SinglyLinkedList<T> _previous;

        public SinglyLinkedList(T value, SinglyLinkedList<T> previous = null)
        {
            Value = value;
            _previous = previous;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            var pathItem = _previous;
            while (pathItem != null)
            {
                yield return pathItem.Value;
                pathItem = pathItem._previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}