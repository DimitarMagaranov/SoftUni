using System.Collections.Generic;

namespace Problem03.Queue
{
    public interface IAbstractQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        bool Contains(T item);

        T Dequeue();

        void Enqueue(T item);

        T Peek();
    }
}
