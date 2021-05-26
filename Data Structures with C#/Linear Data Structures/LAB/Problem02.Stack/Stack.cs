using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02.Stack
{
    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public Stack()
        {
            this.top = null;
            this.Count = 0;
        }

        public Stack(Node<T> top)
        {
            this.top = top;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var tempEl = this.top;

            while (tempEl != null)
            {
                if (tempEl.Value.Equals(item))
                {
                    return true;
                }

                tempEl = tempEl.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.ValidateIfEmpty();

            return this.top.Value;
        }

        public T Pop()
        {
            this.ValidateIfEmpty();

            var toReturn = this.top;
            this.top = this.top.Next;
            this.Count--;

            return toReturn.Value;
        }

        public void Push(T item)
        {
            var toInsert = new Node<T>(item);
            toInsert.Next = this.top;
            this.top = toInsert;
            this.Count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tempEl = this.top;

            while (tempEl != null)
            {
                yield return tempEl.Value;
                tempEl = tempEl.Next;
            }
        }

        private void ValidateIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}
