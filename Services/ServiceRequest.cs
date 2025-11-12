namespace WindowsFormApp1
{
    public class ServiceRequest
    {
        public int RequestId { get; set; }
        public string CitizenName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; } = "Pending";
        public int Progress { get; set; } = 0;

        public ServiceRequest(int id, string citizen, string cat, string desc, int priority)
        {
            RequestId = id;
            CitizenName = citizen;
            Category = cat;
            Description = desc;
            Priority = priority;
        }

        public override string ToString()
        {
            return "[" + RequestId + "] " + Category + " - " + CitizenName +
                   " (Priority: " + Priority + ", Status: " + Status + ")";
        }
    }
}
