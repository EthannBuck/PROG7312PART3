using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    // ---------- Binary Search Tree ----------
    public class BSTNode<T>
    {
        public T Data;
        public BSTNode<T> Left, Right;
        public BSTNode(T data) { Data = data; }
    }

    public class BST<T> where T : IComparable<T>
    {
        public BSTNode<T> Root;

        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }

        private BSTNode<T> InsertRec(BSTNode<T> root, T value)
        {
            if (root == null) return new BSTNode<T>(value);
            if (value.CompareTo(root.Data) < 0)
                root.Left = InsertRec(root.Left, value);
            else
                root.Right = InsertRec(root.Right, value);
            return root;
        }

        public List<T> InOrder()
        {
            List<T> list = new List<T>();
            InOrderRec(Root, list);
            return list;
        }

        private void InOrderRec(BSTNode<T> node, List<T> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Data);
            InOrderRec(node.Right, list);
        }
    }

    // ---------- Min Heap ----------
    public class MinHeap<T> where T : IComparable<T>
    {
        private readonly List<T> _data = new List<T>();

        public void Insert(T item)
        {
            _data.Add(item);
            int i = _data.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (_data[i].CompareTo(_data[parent]) >= 0) break;
                Swap(i, parent);
                i = parent;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = _data[i];
            _data[i] = _data[j];
            _data[j] = temp;
        }

        public List<T> ToSortedList()
        {
            List<T> result = new List<T>(_data);
            result.Sort();
            return result;
        }
    }

    // ---------- Graph ----------
    public class Graph<T>
    {
        private readonly Dictionary<T, List<T>> _adjacency = new Dictionary<T, List<T>>();

        public void AddEdge(T from, T to)
        {
            if (!_adjacency.ContainsKey(from))
                _adjacency[from] = new List<T>();
            if (!_adjacency.ContainsKey(to))
                _adjacency[to] = new List<T>();
            _adjacency[from].Add(to);
            _adjacency[to].Add(from);
        }

        public List<T> BFS(T start)
        {
            List<T> visited = new List<T>();
            Queue<T> queue = new Queue<T>();
            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                T vertex = queue.Dequeue();
                foreach (T neighbor in _adjacency[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return visited;
        }

        public List<T> DFS(T start)
        {
            List<T> visited = new List<T>();
            Stack<T> stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                T vertex = stack.Pop();
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    foreach (T neighbor in _adjacency[vertex])
                        stack.Push(neighbor);
                }
            }
            return visited;
        }

        // ---------- Simple Minimum Spanning Tree (Prim-like) ----------
        public List<Tuple<T, T>> MinimumSpanningTree()
        {
            List<Tuple<T, T>> edges = new List<Tuple<T, T>>();
            if (_adjacency.Keys.Count == 0) return edges;

            HashSet<T> visited = new HashSet<T>();
            Queue<T> queue = new Queue<T>();

            T first = _adjacency.Keys.First();
            visited.Add(first);
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                foreach (T neighbor in _adjacency[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        edges.Add(new Tuple<T, T>(current, neighbor));
                    }
                }
            }
            return edges;
        }
    }
}
