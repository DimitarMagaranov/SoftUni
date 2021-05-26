﻿namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Data : IRepository
    {
        private OrderedBag<IEntity> entities;

        public Data()
        {
            this.entities = new OrderedBag<IEntity>();
        }

        public Data(Data copy)
        {
            this.entities = copy.entities;
        }

        public int Size => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
            var parentNode = this.GetById((int)entity.ParentId);

            if (parentNode != null)
            {
                parentNode.Children.Add(entity);
            }
        }

        public IRepository Copy()
        {
            var copy = (Data)this.MemberwiseClone();

            return new Data(copy);
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.entities);
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (type != typeof(Invoice).Name && type != typeof(StoreClient).Name && type != typeof(User).Name)
            {
                throw new InvalidOperationException($"Invalid type: {type}");
            }

            var result = new List<IEntity>(this.Size);

            for (int i = 0; i < this.Size; i++)
            {
                var current = this.entities[i];

                if (current.GetType().Name == type)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public IEntity GetById(int id)
        {
            if (id < 0 || id >= this.Size)
            {
                return null;
            }

            return this.entities[this.Size - 1 - id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            var parentNode = this.GetById(parentId);

            return parentNode != null ? parentNode.Children : new List<IEntity>();
        }

        public IEntity PeekMostRecent()
        {
            this.EnsureNotEmpty();

            return this.entities.GetFirst();
        }

        public IEntity DequeueMostRecent()
        {
            this.EnsureNotEmpty();

            return this.entities.RemoveFirst();
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
        }
    }
}
