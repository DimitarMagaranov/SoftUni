using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03.Queue
{
    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        public Queue()
        {
            this.head = null;
            this.Count = 0;
        }

        public Queue(Node<T> head)
        {
            this.head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var tempEl = this.head;

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

        public T Dequeue()
        {
            this.ValidateIfEmpty();

            var current = this.head;
            this.head = this.head.Next;
            this.Count--;
            return current.Value;
        }

        public void Enqueue(T item)
        {
            var current = this.head;
            var toInsert = new Node<T>(item);

            if (current == null)
            {
                this.head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toInsert;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.ValidateIfEmpty();

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}
