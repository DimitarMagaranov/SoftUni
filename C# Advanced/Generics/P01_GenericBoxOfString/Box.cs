using System;
using System.Collections.Generic;
using System.Text;

namespace P01_GenericBoxOfString
{
    public class Box<T>
    {
        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.Data[index1];
            this.Data[index1] = this.Data[index2];
            this.Data[index2] = temp;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var element in this.Data)
            {
                stringBuilder.AppendLine($"{element.GetType()}: {element}");
            }

            return stringBuilder.ToString();
        }
    }
}
