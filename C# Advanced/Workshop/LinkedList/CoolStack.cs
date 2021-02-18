using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public class CoolStack
    {
        private object[] values;
        private int count;

        public CoolStack()
            :this(16)
        {
        }

        public CoolStack(int InitialCapacity)
        {
            this.values = new object[InitialCapacity];
            this.count = 0;
        }

        public int Count
        {
            get => this.count;
        }

        public void Push(object value)
        {
            if (this.count == this.values.Length)
            {
                object[] nextValues = new object[this.values.Length * 2];

                for (int i = 0; i < this.values.Length; i++)
                {
                    nextValues[i] = this.values[i];
                }

                this.values = nextValues;
            }

            this.values[this.count] = value;
            count++;
        }

        public object Pop(object value)
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty.");
            }

            int lastIndex = this.count - 1;
            object last = this.values[lastIndex];
            this.values = this.values.Where(x => x != last).ToArray();
            return last;
        }

        public object Peek(object value)
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty.");
            }

            int lastIndex = this.count - 1;
            object last = this.values[lastIndex];
            return last;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count - 1; i++)
            {
                action(this.values[i]);
            }
        }
    }
}
