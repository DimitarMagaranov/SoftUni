namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value,
            IAbstractBinaryTree<T> leftChild,
            IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var result = new StringBuilder();
            this.AsIndentedPreOrderDfs(this, indent, result);

            return result.ToString().TrimEnd();
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            this.InOrderDfs(this, result);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            this.PostOrderDfs(this, result);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            this.PreOrderDfs(this, result);

            return result;
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        private void AsIndentedPreOrderDfs(IAbstractBinaryTree<T> current, int indent, StringBuilder result)
        {
            result.AppendLine(new string(' ', indent) + current.Value);

            if (current.LeftChild != null)
            {
                this.AsIndentedPreOrderDfs(current.LeftChild, indent + 2, result);
            }

            if (current.RightChild != null)
            {
                this.AsIndentedPreOrderDfs(current.RightChild, indent + 2, result);
            }
        }

        private void InOrderDfs(IAbstractBinaryTree<T> current, List<IAbstractBinaryTree<T>> result)
        {
            if (current.LeftChild != null)
            {
                this.InOrderDfs(current.LeftChild, result);
            }

            result.Add(current);

            if (current.RightChild != null)
            {
                this.InOrderDfs(current.RightChild, result);
            }
        }

        private void PostOrderDfs(IAbstractBinaryTree<T> current, List<IAbstractBinaryTree<T>> result)
        {
            if (current.LeftChild != null)
            {
                this.PostOrderDfs(current.LeftChild, result);
            }

            if (current.RightChild != null)
            {
                this.PostOrderDfs(current.RightChild, result);
            }

            result.Add(current);
        }

        private void PreOrderDfs(IAbstractBinaryTree<T> current, List<IAbstractBinaryTree<T>> result)
        {
            result.Add(current);

            if (current.LeftChild != null)
            {
                this.PreOrderDfs(current.LeftChild, result);
            }

            if (current.RightChild != null)
            {
                this.PreOrderDfs(current.RightChild, result);
            }
        }
    }
}
