using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    public static class EventRepository
    {
        // Primary storage
        public static SortedDictionary<string, Queue<Event>> EventsByCategory =
            new SortedDictionary<string, Queue<Event>>(StringComparer.OrdinalIgnoreCase);

        // Sets for unique categories and unique dates
        public static HashSet<string> Categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public static HashSet<DateTime> UniqueEventDates = new HashSet<DateTime>();

        // Stack and Queues
        public static Stack<Event> LastViewed = new Stack<Event>();
        public static Queue<Event> SubmissionQueue = new Queue<Event>();

        // Recommendation frequency
        private static Dictionary<string, int> CategorySearchFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        static EventRepository()
        {
            var samples = new List<Event>
            {
                new Event{Title="Community Clean-up", Category="Environment", Date=DateTime.Now.AddDays(3), Description="Join us for a clean-up drive in the central park."},
                new Event{Title="Youth Soccer Tournament", Category="Sports", Date=DateTime.Now.AddDays(7), Description="Local teams compete for the youth cup."},
                new Event{Title="Health Awareness Fair", Category="Health", Date=DateTime.Now.AddDays(5), Description="Free check-ups and wellness workshops."},
                new Event{Title="Town Hall Meeting", Category="Government", Date=DateTime.Now.AddDays(2), Description="Discuss municipal development plans."},
                new Event{Title="Recycling Workshop", Category="Environment", Date=DateTime.Now.AddDays(10), Description="Learn how to recycle properly."},
                new Event{Title="Adult Education Info Session", Category="Education", Date=DateTime.Now.AddDays(12), Description="Courses and registration details."},
                new Event{Title="Road Safety Campaign", Category="Safety", Date=DateTime.Now.AddDays(4), Description="Safety tips and helmet distribution."},
                new Event{Title="Community Market Day", Category="Economy", Date=DateTime.Now.AddDays(6), Description="Local sellers and crafts."},
                new Event{Title="Library Story Hour", Category="Education", Date=DateTime.Now.AddDays(1), Description="Children's story reading session."},
                new Event{Title="Senior Social", Category="Social", Date=DateTime.Now.AddDays(8), Description="Activities for seniors."},
                new Event{Title="Food Drive", Category="Charity", Date=DateTime.Now.AddDays(9), Description="Donate non-perishables to help families."},
                new Event{Title="Public Transport Forum", Category="Government", Date=DateTime.Now.AddDays(11), Description="Discuss bus routes and schedules."},
                new Event{Title="Beach Cleanup", Category="Environment", Date=DateTime.Now.AddDays(14), Description="Bring gloves and water."},
                new Event{Title="Local Musicians Night", Category="Culture", Date=DateTime.Now.AddDays(13), Description="Live performances by local artists."},
                new Event{Title="Free Dental Clinic", Category="Health", Date=DateTime.Now.AddDays(15), Description="Dental screenings and basic care."},
                new Event{Title="Coding Workshop for Teens", Category="Education", Date=DateTime.Now.AddDays(16), Description="Intro to Python and web dev."}
            };

            foreach (var ev in samples) AddEvent(ev);
        }

        public static void AddEvent(Event ev)
        {
            if (!EventsByCategory.ContainsKey(ev.Category))
                EventsByCategory[ev.Category] = new Queue<Event>();

            EventsByCategory[ev.Category].Enqueue(ev);
            Categories.Add(ev.Category);
            UniqueEventDates.Add(ev.Date.Date);
        }

        public static void SubmitNewEvent(Event ev)
        {
            SubmissionQueue.Enqueue(ev);
        }

        public static void ProcessSubmissions()
        {
            while (SubmissionQueue.Count > 0)
            {
                var ev = SubmissionQueue.Dequeue();
                AddEvent(ev);
            }
        }

        public static List<Event> SearchEvents(string keyword, string category, DateTime? date, bool useDateFilter = false)
        {
            var all = EventsByCategory.Values.SelectMany(q => q);

            var filtered = all.Where(ev =>
                (string.IsNullOrEmpty(keyword)
                    || ev.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                    || ev.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                && (string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase) || ev.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                && (!useDateFilter || (date.HasValue && ev.Date.Date >= date.Value.Date))
            ).ToList();

            if (!string.IsNullOrEmpty(category) && !string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase))
            {
                if (!CategorySearchFrequency.ContainsKey(category))
                    CategorySearchFrequency[category] = 0;
                CategorySearchFrequency[category]++;
            }

            if (filtered.Any())
                LastViewed.Push(filtered.First());

            return filtered.OrderBy(e => e.Date).ToList();
        }

        // Enhanced recommendation algorithm
        public static List<Event> GetSmartRecommendations(int take = 5)
        {
            var recs = new List<Event>();
            var topCategories = CategorySearchFrequency.OrderByDescending(c => c.Value).Select(c => c.Key).ToList();

            // From top searched categories
            foreach (var cat in topCategories)
            {
                if (EventsByCategory.ContainsKey(cat))
                {
                    var upcoming = EventsByCategory[cat].Where(e => e.Date >= DateTime.Now).Take(3);
                    recs.AddRange(upcoming);
                }
            }

            // From last viewed event category
            if (LastViewed.Any())
            {
                var lastCat = LastViewed.Peek().Category;
                if (EventsByCategory.ContainsKey(lastCat))
                {
                    var similar = EventsByCategory[lastCat]
                        .Where(e => e.Date >= DateTime.Now && !recs.Contains(e))
                        .Take(2);
                    recs.AddRange(similar);
                }
            }

            if (!recs.Any())
            {
                recs.AddRange(EventsByCategory.Values.SelectMany(q => q)
                    .Where(e => e.Date >= DateTime.Now)
                    .OrderBy(e => e.Date)
                    .Take(take));
            }

            return recs.Distinct().OrderBy(e => e.Date).Take(take).ToList();
        }

        public static List<Event> GetLastViewed(int top = 5)
        {
            return LastViewed.Take(top).ToList();
        }

        public static List<Event> GetAllEventsSorted(string sortBy = "Date", bool ascending = true)
        {
            var all = EventsByCategory.Values.SelectMany(q => q);
            IEnumerable<Event> ordered = all;

            switch (sortBy.ToLowerInvariant())
            {
                case "date":
                    ordered = ascending ? all.OrderBy(e => e.Date) : all.OrderByDescending(e => e.Date);
                    break;
                case "category":
                    ordered = ascending ? all.OrderBy(e => e.Category) : all.OrderByDescending(e => e.Category);
                    break;
                case "title":
                    ordered = ascending ? all.OrderBy(e => e.Title) : all.OrderByDescending(e => e.Title);
                    break;
            }

            return ordered.ToList();
        }
    }
}
