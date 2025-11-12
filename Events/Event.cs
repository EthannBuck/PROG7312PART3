using System;

namespace WindowsFormApp1
{
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Title} | {Category} | {Date:dd MMM yyyy}";
        }
    }
}
