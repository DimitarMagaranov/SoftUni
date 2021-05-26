using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem04.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public SinglyLinkedList()
        {
            this.head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this.head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var toInsert = new Node<T>(item, this.head);
            this.head = toInsert;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var toInsert = new Node<T>(item);
            var current = this.head;

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

        public T GetFirst()
        {
            this.ValidateIfListIsNotEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.ValidateIfListIsNotEmpty();

            var current = this.head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.ValidateIfListIsNotEmpty();

            var toReturn = this.head;

            this.head = this.head.Next;

            this.Count--;
            return toReturn.Value;
        }

        public T RemoveLast()
        {
            this.ValidateIfListIsNotEmpty();

            Node<T> current = this.head;
            Node<T> last = null;

            if (current.Next == null)
            {
                last = this.head;
                this.head = null;
            }
            else
            {
                while (current != null)
                {
                    if (current.Next.Next == null)
                    {
                        last = current.Next;
                        current.Next = null;
                        break;
                    }

                    current = current.Next;
                }
            }

            this.Count--;
            return last.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIfListIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The linked list is empty!");
            }
        }
    }
}
