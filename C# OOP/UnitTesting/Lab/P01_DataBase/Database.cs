using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_DataBase
{
    public class Database
    {
        private List<Person> people;
        private const int DefaultSize = 16;
        private int[] database;
        private int index;

        public Database(params int[] collection)
            : this(collection.ToList())
        {
        }

        public Database(ICollection<int> collection)
        {
            this.ValidateCollectionSize(collection.ToArray());
            this.database = new int[DefaultSize];
            this.index = 0;
            this.DatabaseElements = collection.ToArray();
        }

        public int[] DatabaseElements
        {
            get
            {
                List<int> numbers = new List<int>();

                for (int i = 0; i < index; i++)
                {
                    numbers.Add(this.database[i]);
                }

                return numbers.ToArray();
            }
            set
            {
                if (value.Length > DefaultSize || value.Length < 1)
                {
                    throw new InvalidOperationException("Invalid collection size!");
                }

                this.database = new int[DefaultSize];

                for (int i = 0; i < value.Length; i++)
                {
                    this.database[this.index] = value[i];
                    this.index++;
                }
            }
        }

        public void Add(int number)
        {
            if (this.index >= 16)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.database[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.database[this.index - 1] = default(int);
            this.index--;
        }

        public int[] Fetch()
        {
            int[] arrayToExpose = new int[this.index];

            for (int i = 0; i < this.index; i++)
            {
                arrayToExpose[i] = this.database[i];
            }

            return arrayToExpose;
        }

        public void ValidateCollectionSize(int[] value)
        {
            if (value.Length > DefaultSize || value.Length < 1)
            {
                throw new InvalidOperationException("Invalid collection size!");
            }
        }
    }
}
