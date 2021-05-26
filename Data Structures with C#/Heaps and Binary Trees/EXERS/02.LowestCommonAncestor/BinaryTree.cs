namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNode = this.FindNodeBfs(first, this);
            var secondNode = this.FindNodeBfs(second, this);

            var firstNodeAncestors = this.FindNodeAllAncestors(firstNode);
            var secondNodeAncestors = this.FindNodeAllAncestors(secondNode);

            var currentElement = firstNodeAncestors.Dequeue();

            while (firstNodeAncestors.Count > 0)
            {
                if (secondNodeAncestors.Contains(currentElement))
                {
                    return currentElement;
                }

                currentElement = firstNodeAncestors.Dequeue();
            }

            return currentElement;
        }

        private Queue<T> FindNodeAllAncestors(IAbstractBinaryTree<T> node)
        {
            var nodeAncestors = new Queue<T>();
            var current = node;

            while (current != null)
            {
                nodeAncestors.Enqueue(current.Value);
                current = current.Parent;
            }

            return nodeAncestors;
        }

        private IAbstractBinaryTree<T> FindNodeBfs(T element, IAbstractBinaryTree<T> tree)
        {
            var nodes = new Queue<IAbstractBinaryTree<T>>();
            nodes.Enqueue(tree);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (current.Value.Equals(element))
                {
                    return current;
                }

                if (current.LeftChild != null)
                {
                    nodes.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    nodes.Enqueue(current.RightChild);
                }
            }

            return null;
        }
    }
}
