using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    // Min-heap based on ServiceRequest.Priority
    public class ServiceRequestHeap
    {
        private List<ServiceRequest> heap = new List<ServiceRequest>();

        // Insert a new request and bubble it up to maintain heap property
        public void Insert(ServiceRequest r)
        {
            heap.Add(r);
            int i = heap.Count - 1;
            while (i > 0 && heap[(i - 1) / 2].Priority > heap[i].Priority)
            {
                ServiceRequest temp = heap[i];
                heap[i] = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = temp;
                i = (i - 1) / 2;
            }
        }

        // Return heap elements ordered by Priority (not necessarily heap order)
        public IEnumerable<ServiceRequest> ToList()
        {
            return heap.OrderBy(r => r.Priority);
        }
    }
}
