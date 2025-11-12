using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    public class ServiceGraphEdge
    {
        public string A;
        public string B;
        public int Weight;
        public ServiceGraphEdge(string a, string b, int w)
        {
            A = a; B = b; Weight = w;
        }
    }

    public class ServiceRequestGraph
    {
        private Dictionary<string, List<ServiceGraphEdge>> adj = new Dictionary<string, List<ServiceGraphEdge>>();

        public void AddEdge(string a, string b, int w)
        {
            if (!adj.ContainsKey(a)) adj[a] = new List<ServiceGraphEdge>();
            if (!adj.ContainsKey(b)) adj[b] = new List<ServiceGraphEdge>();
            adj[a].Add(new ServiceGraphEdge(a, b, w));
            adj[b].Add(new ServiceGraphEdge(b, a, w));
        }

        public bool HasAnyNodes()
        {
            return adj.Count > 0;
        }

        public string GetFirstNode()
        {
            return adj.Keys.FirstOrDefault();
        }


        // Breadth-First Search (BFS)
        public List<string> BFS(string start)
        {
            List<string> visited = new List<string>();
            if (!adj.ContainsKey(start)) return visited;

            Queue<string> queue = new Queue<string>();
            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                foreach (ServiceGraphEdge edge in adj[node])
                {
                    if (!visited.Contains(edge.B))
                    {
                        visited.Add(edge.B);
                        queue.Enqueue(edge.B);
                    }
                }
            }

            return visited;
        }

        // Depth-First Search (DFS)
        public List<string> DFS(string start)
        {
            List<string> visited = new List<string>();
            if (!adj.ContainsKey(start)) return visited;

            Stack<string> stack = new Stack<string>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                string node = stack.Pop();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach (ServiceGraphEdge edge in adj[node])
                    {
                        if (!visited.Contains(edge.B))
                            stack.Push(edge.B);
                    }
                }
            }

            return visited;
        }

        // Minimum Spanning Tree (Prim-like)
        public List<ServiceGraphEdge> MinimumSpanningTree()
        {
            List<ServiceGraphEdge> mst = new List<ServiceGraphEdge>();
            if (adj.Count == 0) return mst;

            HashSet<string> visited = new HashSet<string>();
            List<ServiceGraphEdge> edges = new List<ServiceGraphEdge>();

            string start = adj.Keys.First();
            visited.Add(start);
            edges.AddRange(adj[start]);

            while (edges.Count > 0)
            {
                ServiceGraphEdge minEdge = null;
                foreach (ServiceGraphEdge e in edges)
                {
                    if (minEdge == null || e.Weight < minEdge.Weight)
                        minEdge = e;
                }

                edges.Remove(minEdge);
                if (visited.Contains(minEdge.B)) continue;

                visited.Add(minEdge.B);
                mst.Add(minEdge);

                foreach (ServiceGraphEdge next in adj[minEdge.B])
                {
                    if (!visited.Contains(next.B)) edges.Add(next);
                }
            }

            return mst;
        }
    }
}
