using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Tree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public IEnumerable<T> OrderTreeViaDfs() 
        {
            var list = new List<T>();
            this.Dfs(this, list);
            return list;
        }

        public IEnumerable<T> OrderThreeViaBfs() 
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.value);

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public void AddChild(T parentalKey, Tree<T> child)
        {
            var parentalNode = this.FindNode(parentalKey);

            if (parentalNode == null)
            {
                throw new ArgumentNullException("Parental object was not found");
            }

            parentalNode.children.Add(child);
            child.parent = parentalNode;
        }

        public void RemoveNode(T keyOfNode)
        {
            var nodeForRemove = FindNode(keyOfNode);

            if (nodeForRemove == null)
            {
                throw new ArgumentNullException("The object was not found.");
            }

            var parentNode = nodeForRemove.parent;

            if (parentNode == null)
            {
                throw new ArgumentException("The parental object was not found.");
            }

            parentNode.children.Remove(nodeForRemove);
        }

        private Tree<T> FindNode(T parentalKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.value.Equals(parentalKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.value);
        }
    }
}
