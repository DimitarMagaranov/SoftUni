namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this._children = new List<Tree<T>>();

            this.Key = key;

            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            child.Parent = this;
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var result = new StringBuilder();

            int depth = 0;
            this.OrderDfsForString(depth, result, this);

            return result.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsLeaf(node);

            var leafNodes = this.OrderBfsNodes(predicate);

            int deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                int currentDept = this.GetDepthFromLeafToParent(node);

                if (currentDept > deepestNodeDepth)
                {
                    deepestNodeDepth = currentDept;
                    deepestNode = node;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> leafKeysPredicate = (node) => this.IsLeaf(node);

            return this.OrderBfs(leafKeysPredicate);
        }

        public List<T> GetMiddleKeys()
        {
            Func<Tree<T>, bool> middleKeysPredicate = (node) => this.IsMiddleNode(node);

            return this.OrderBfs(middleKeysPredicate);
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestLeftomostNode();
            var result = new Stack<T>();

            var current = deepestNode;

            while (current != null)
            {
                result.Push(current.Key);
                current = current.Parent;
            }

            return new List<T>(result);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentPath = new List<T>();
            currentPath.Add(this.Key);
            var currentSum = Convert.ToInt32(this.Key);

            this.GetPathsWithSumDfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            Func<Tree<T>, int, bool> subtreeSumPredicate = (currentNode, wantedSum) => this.HasGivenSum(currentNode, wantedSum);

            return this.OrderBfsNodes(subtreeSumPredicate, sum);
        }

        private void OrderDfsForString(int depth, StringBuilder result, Tree<T> subtree)
        {
            result.AppendLine(new string(' ', depth) + subtree.Key);

            foreach (var child in subtree.Children)
            {
                this.OrderDfsForString(depth + 2, result, child);
            }
        }

        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (predicate.Invoke(current))
                {
                    result.Add(current.Key);
                }

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfsNodes(Func<Tree<T>, bool> predicate)
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (predicate.Invoke(current))
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfsNodes(Func<Tree<T>, int, bool> predicate, int sum)
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (predicate.Invoke(currentNode, sum))
                {
                    result.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private bool IsLeaf(Tree<T> node)
        {
            return node.Children.Count == 0;
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.Parent == null;
        }

        private bool IsMiddleNode(Tree<T> node)
        {
            return node.Parent != null && node.Children.Count > 0;
        }

        private int GetDepthFromLeafToParent(Tree<T> node)
        {
            var depth = 0;
            var current = node;

            while (current.Parent != null)
            {
                current = current.Parent;
                depth++;
            }

            return depth;
        }

        private void GetPathsWithSumDfs(Tree<T> current, List<List<T>> wantedPaths, List<T> currentPath, ref int currentSum, int wantedSum)
        {
            foreach (var child in current.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathsWithSumDfs(child, wantedPaths, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                wantedPaths.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(current.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private bool HasGivenSum(Tree<T> currentNode, int sum)
        {
            int actualSum = this.GetSubtreeSumDfs(currentNode);

            return actualSum == sum;
        }

        private int GetSubtreeSumDfs(Tree<T> node)
        {
            var currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                this.GetSubtreeSumDfs(child);
                currentSum += Convert.ToInt32(child.Key);
            }

            return currentSum;
        }
    }
}
