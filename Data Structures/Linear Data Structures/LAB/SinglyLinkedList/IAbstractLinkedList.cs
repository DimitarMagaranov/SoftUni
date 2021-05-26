using System.Collections.Generic;

namespace Problem04.SinglyLinkedList
{
    public interface IAbstractLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; }

        void AddFirst(T item);

        void AddLast(T item);

        T GetFirst();

        T GetLast();

        T RemoveFirst();

        T RemoveLast();
    }
}
