namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return this.GetById(entity.Id) != null;
        }

        public IEntity Extract(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.entities.Remove(entity);
            }

            return entity;
        }

        public IEntity Find(IEntity entity)
        {
            return this.GetById(entity.Id);
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.entities);
        }

        public void RemoveSold()
        {
            this.entities.RemoveAll(x => x.Status == BaseEntityStatus.Sold);
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            var indexOfEntity = this.entities.IndexOf(oldEntity);

            this.ValidateEntity(indexOfEntity);

            this.entities[indexOfEntity] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var result = new List<IEntity>(this.EntitiesCount);

            int lowerBoundIndex = (int)lowerBound;
            int upperBoundIndex = (int)upperBound;

            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var currentEntity = this.entities[i];
                var entityStatusIndex = (int)currentEntity.Status;

                if (lowerBoundIndex <= entityStatusIndex && entityStatusIndex <= upperBoundIndex)
                {
                    result.Add(currentEntity);
                }
            }

            return result;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this.entities.IndexOf(first);
            this.ValidateEntity(indexOfFirst);

            var indexOfSecond = this.entities.IndexOf(second);
            this.ValidateEntity(indexOfSecond);

            var temp = this.entities[indexOfFirst];
            this.entities[indexOfFirst] = this.entities[indexOfSecond];
            this.entities[indexOfSecond] = temp;
        }

        public IEntity[] ToArray()
        {
            return this.entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var currentEntity = this.entities[i];

                if (currentEntity.Status == oldStatus)
                {
                    currentEntity.Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }




        private IEntity GetById(int id)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var currentEntity = this.entities[i];

                if (currentEntity.Id == id)
                {
                    return currentEntity;
                }
            }

            return null;
        }

        private void ValidateEntity(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
