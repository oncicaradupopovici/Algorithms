using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTraversal
{
    public class Algorithm<T>
    {
        public IEnumerable<GraphNode<T>> DfsTraverse(GraphNode<T> root)
        {
            var stackHistory = new HashSet<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();

            stack.Push(root);
            stackHistory.Add(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node;

                var ienumerable = node.AdjNodes.Reverse<GraphNode<T>>();
                foreach (var adjNode in ienumerable)
                {
                    if (!stackHistory.Contains(adjNode))
                    {
                        stack.Push(adjNode);
                        stackHistory.Add(adjNode);
                    }
                }
            }

        }

        public IEnumerable<GraphNode<T>> BfsTraverse(GraphNode<T> root)
        {
            var queueHistory = new HashSet<GraphNode<T>>();
            var queue = new Queue<GraphNode<T>>();

            queue.Enqueue(root);
            queueHistory.Add(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node;

                foreach (var adjNode in node.AdjNodes)
                {
                    if (!queueHistory.Contains(adjNode))
                    {
                        queue.Enqueue(adjNode);
                        queueHistory.Add(adjNode);
                    }
                }
            }
        }
    }


    public class GraphNode<T>
    {
        public T Value { get; set; }
        public List<GraphNode<T>> AdjNodes { get; set; }

        public GraphNode(T value)
        {
            Value = value;
            AdjNodes = new List<GraphNode<T>>();
        }
    }
}
