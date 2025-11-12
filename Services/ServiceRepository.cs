using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    public static class ServiceRepository
    {
        public static ServiceRequestTree Tree = new ServiceRequestTree();
        public static ServiceRequestHeap Heap = new ServiceRequestHeap();
        public static ServiceRequestGraph Graph = new ServiceRequestGraph();
        public static List<ServiceRequest> AllRequests = new List<ServiceRequest>();

        static ServiceRepository()
        {
            PopulateSampleData();
        }

        private static void PopulateSampleData()
        {
            string[] cats = { "Water", "Electricity", "Roads", "Waste", "Housing", "Sewage", "Transport" };
            Random rnd = new Random();

            for (int i = 1; i <= 15; i++)
            {
                var req = new ServiceRequest(
                    i,
                    "Citizen " + i,
                    cats[rnd.Next(cats.Length)],
                    "Service issue " + i,
                    rnd.Next(1, 6)
                );
                AddRequest(req);
            }

            // Build Graph (Department connections)
            Graph.AddEdge("Water", "Electricity", 3);
            Graph.AddEdge("Water", "Roads", 4);
            Graph.AddEdge("Roads", "Waste", 2);
            Graph.AddEdge("Electricity", "Housing", 6);
            Graph.AddEdge("Waste", "Housing", 5);
            Graph.AddEdge("Transport", "Housing", 3);
        }

        public static void AddRequest(ServiceRequest req)
        {
            AllRequests.Add(req);
            Tree.Insert(req);
            Heap.Insert(req);
        }

        public static ServiceRequest FindById(int id)
        {
            return AllRequests.FirstOrDefault(r => r.RequestId == id);
        }

        public static List<ServiceRequest> GetAllTreeOrdered()
        {
            return Tree.InOrder().ToList();
        }

        public static List<ServiceRequest> GetAllHeapOrdered()
        {
            return Heap.ToList().ToList();
        }

        public static List<ServiceGraphEdge> GetMST()
        {
            return Graph.MinimumSpanningTree();
        }

        public static List<string> BFS(string start)
        {
            return Graph.BFS(start);
        }

        public static List<string> DFS(string start)
        {
            return Graph.DFS(start);
        }
    }
}
