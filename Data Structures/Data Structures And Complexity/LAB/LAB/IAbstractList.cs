using System.Collections.Generic;

namespace LAB
{
    public interface IAbstractList<T> : IEnumerable<T>
    {
        void Add(T element);

        void RemoveAt(T element);

        void Remove(T element);

        bool Contains(T element);
    }
}
