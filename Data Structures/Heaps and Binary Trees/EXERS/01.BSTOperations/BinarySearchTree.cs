namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => this.Root.Count;

        public bool Contains(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            var toInsert = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                this.InsertElementDfs(this.Root, null, toInsert);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return new BinarySearchTree<T>(current);
                }
            }

            return null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderDfs(this.Root, action);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            this.OrderLowerToUpperBfs(result, lower, upper);

            return result;
        }

        public void DeleteMin()
        {
            this.EnsureNotEmpty();

            var currentNode = this.Root;
            Node<T> previousNode = null;

            if (this.Root.LeftChild == null)
            {
                this.Root = this.Root.RightChild;
            }
            else
            {
                while (currentNode.LeftChild != null)
                {
                    currentNode.Count--;
                    previousNode = currentNode;
                    currentNode = currentNode.LeftChild;
                }

                previousNode.LeftChild = currentNode.RightChild;
            }
        }

        public void DeleteMax()
        {
            this.EnsureNotEmpty();

            var currentNode = this.Root;
            Node<T> previousNode = null;

            if (this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
            }
            else
            {
                while (currentNode.RightChild != null)
                {
                    currentNode.Count--;
                    previousNode = currentNode;
                    currentNode = currentNode.RightChild;
                }

                previousNode.RightChild = currentNode.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return this.GetRankDfs(this.Root, element);
        }

        

        private void InsertElementDfs(Node<T> current, Node<T> previous, Node<T> toInsert)
        {
            if (current == null && this.IsLess(toInsert.Value, previous.Value))
            {
                previous.LeftChild = toInsert;

                if (this.LeftChild == null)
                {
                    this.LeftChild = toInsert;
                }

                return;
            }

            if (current == null && this.IsGreater(toInsert.Value, previous.Value))
            {
                previous.RightChild = toInsert;

                if (this.RightChild == null)
                {
                    this.RightChild = toInsert;
                }

                return;
            }

            if (this.IsLess(toInsert.Value, current.Value))
            {
                this.InsertElementDfs(current.LeftChild, current, toInsert);
                current.Count++;
            }
            else if (this.IsGreater(toInsert.Value, current.Value))
            {
                this.InsertElementDfs(current.RightChild, current, toInsert);
                current.Count++;
            }
        }

        private bool IsLess(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }

        private bool IsGreater(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) > 0;
        }

        private bool AreEqual(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) == 0;
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                this.EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                this.EachInOrderDfs(current.RightChild, action);
            }
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }

        private void OrderLowerToUpperBfs(List<T> result, T lower, T upper)
        {
            var nodes = new Queue<Node<T>>();
            nodes.Enqueue(this.Root);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (this.IsLess(lower, currentNode.Value) && this.IsGreater(upper, currentNode.Value))
                {
                    result.Add(currentNode.Value);
                }
                else if (this.AreEqual(lower, currentNode.Value) || this.AreEqual(upper, currentNode.Value))
                {
                    result.Add(currentNode.Value);
                }

                if (currentNode.LeftChild != null)
                {
                    nodes.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    nodes.Enqueue(currentNode.RightChild);
                }
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("The binary search tree is empty!");
            }
        }

        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(element, current.Value))
            {
                return this.GetRankDfs(current.LeftChild, element);
            }
            else if (this.AreEqual(element, current.Value))
            {
                return this.GetNodeCount(current);
            }

            return this.GetNodeCount(current.LeftChild)
                + 1 + this.GetRankDfs(current.RightChild, element);
        }

        private int GetNodeCount(Node<T> current)
        {
            return current == null ? 0 : current.Count;
        }
    }
}
