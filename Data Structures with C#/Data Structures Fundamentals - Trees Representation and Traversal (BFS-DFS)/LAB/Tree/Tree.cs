namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);
                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            this.StartDfs(this, result);
            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentSubtree = this.FindWithBfs(parentKey);
            // var parentSubtree = this.FindWithDfs(parentKey, this);
            this.CheckEmptyNode(parentSubtree);

            parentSubtree._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindWithBfs(nodeKey);
            this.CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            var parentNode = searchedNode.Parent;

            // If parent node is null - remove root node
            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(searchedNode);
                parentNode = null;
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindWithBfs(firstKey);
            this.CheckEmptyNode(firstNode);

            var secondNode = this.FindWithBfs(secondKey);
            this.CheckEmptyNode(secondNode);

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            if (firstNodeParent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            if (secondNodeParent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            var indexOfFIrstNode = firstNodeParent._children.IndexOf(firstNode);
            var indexOfSecondNode = secondNodeParent._children.IndexOf(secondNode);

            firstNodeParent._children[indexOfFIrstNode] = secondNode;
            secondNodeParent._children[indexOfSecondNode] = firstNode;

            //firstNode.Parent = secondNodeParent;
            //secondNode.Parent = firstNodeParent;

            var tmp = firstNodeParent;
            firstNodeParent = secondNodeParent;
            secondNodeParent = tmp;
        }

        private void SwapRoot(Tree<T> node)
        {
            this.Value = node.Value;
            this._children.Clear();
            foreach (var child in node.Children)
            {
                this._children.Add(child);
            }
        }

        private void StartDfs(Tree<T> subtree, List<T> result)
        {
            foreach (var child in subtree.Children)
            {
                this.StartDfs(child, result);
            }

            result.Add(subtree.Value);
        }

        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);

            while (toTraverse.Count > 0)
            {
                var subtree = toTraverse.Pop();

                foreach (var child in subtree.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(subtree.Value);
            }

            return new List<T>(result);
        }

        private Tree<T> FindWithBfs(T value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(value))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindWithDfs(T value, Tree<T> subtree)
        {
            foreach (var child in subtree.Children)
            {
                var current = this.FindWithDfs(value, child);

                if (current != null && current.Value.Equals(value))
                {
                    return current;
                }
            }

            return subtree.Value.Equals(value) ? subtree : null;
        }

        private void CheckEmptyNode(Tree<T> parentSubtree)
        {
            if (parentSubtree is null)
            {
                throw new ArgumentNullException("The node is null!");
            }
        }
    }
}
