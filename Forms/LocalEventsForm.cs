using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class LocalEventsForm : Form
    {
        private HomePage parentForm;

        public LocalEventsForm(HomePage parent)
        {
            InitializeComponent();
            parentForm = parent;

            // Hook up events here if not hooked in Designer
            this.Load += LocalEventsForm_Load;
            lstEvents.SelectedIndexChanged += lstEvents_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;
            btnSubmitEvent.Click += btnSubmitEvent_Click;
            btnProcessSubmissions.Click += btnProcessSubmissions_Click;
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 650);
            this.StartPosition = FormStartPosition.CenterParent;

            // Populate dropdowns
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            cmbCategory.Items.AddRange(EventRepository.Categories.ToArray());
            cmbCategory.SelectedIndex = 0;

            cmbSortBy.Items.Clear();
            cmbSortBy.Items.AddRange(new string[] { "Date", "Category", "Title" });
            cmbSortBy.SelectedIndex = 0;

            cmbSortOrder.Items.Clear();
            cmbSortOrder.Items.AddRange(new string[] { "Ascending", "Descending" });
            cmbSortOrder.SelectedIndex = 0;

            // Initialize placeholders 
            InitializePlaceholder(txtSearch, "Search events...");
            InitializePlaceholder(txtNewTitle, "Enter event title...");
            InitializePlaceholder(txtNewCategory, "Enter event category...");
            InitializePlaceholder(txtNewDesc, "Enter event description...");

            // Load initial data
            DisplayAllEvents();
            DisplayRecommendations();
            DisplayLastViewed();
            UpdateSubmissionQueueCount();

            // Show/hide placeholder labels
            txtSearch.TextChanged += (s, ev) => lblSearchHint.Visible = string.IsNullOrWhiteSpace(txtSearch.Text);
            txtSearch.GotFocus += (s, ev) => lblSearchHint.Visible = false;
            txtSearch.LostFocus += (s, ev) => lblSearchHint.Visible = string.IsNullOrWhiteSpace(txtSearch.Text);

            txtNewTitle.TextChanged += (s, ev) => lblNewTitleHint.Visible = string.IsNullOrWhiteSpace(txtNewTitle.Text);
            txtNewCategory.TextChanged += (s, ev) => lblNewCatHint.Visible = string.IsNullOrWhiteSpace(txtNewCategory.Text);
            txtNewDesc.TextChanged += (s, ev) => lblNewDescHint.Visible = string.IsNullOrWhiteSpace(txtNewDesc.Text);

            lblRecommendations.Location = new Point(800, lblRecommendations.Location.Y);
            lblLastViewed.Location = new Point(800, lblLastViewed.Location.Y);

        }

        private void InitializePlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();
            var allEvents = EventRepository.GetAllEventsSorted("Date", true);
            foreach (var ev in allEvents)
                lstEvents.Items.Add(ev.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search events...") keyword = "";

            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All Categories";
            DateTime? selectedDate = dtDate.Value.Date;

            bool useDateFilter = chkUseDate.Checked;

            var results = EventRepository.SearchEvents(keyword, selectedCategory, selectedDate, useDateFilter);

            lstEvents.Items.Clear();
            if (results.Any())
            {
                foreach (var ev in results)
                    lstEvents.Items.Add(ev.ToString());
            }
            else
            {
                lstEvents.Items.Add("No matching events found.");
            }

            DisplayRecommendations();
            DisplayLastViewed();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search events...";
            txtSearch.ForeColor = Color.Gray;
            cmbCategory.SelectedIndex = 0;
            cmbSortBy.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            chkUseDate.Checked = false;

            DisplayAllEvents();
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1) return;
            var selectedText = lstEvents.SelectedItem.ToString();
            var all = EventRepository.EventsByCategory.Values.SelectMany(q => q);
            var ev = all.FirstOrDefault(x => x.ToString() == selectedText);

            if (ev != null)
            {
                EventRepository.LastViewed.Push(ev);
                DisplayLastViewed();

                MessageBox.Show($"{ev.Title}\n\nCategory: {ev.Category}\nDate: {ev.Date:d}\n\n{ev.Description}",
                    "Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayRecommendations()
        {
            var recs = EventRepository.GetSmartRecommendations(5);
            lstRecommendations.Items.Clear();
            if (recs.Any())
            {
                lblRecommendations.Text = "Recommended Events (based on your searches):";
                foreach (var ev in recs)
                    lstRecommendations.Items.Add(ev.ToString());
            }
            else
            {
                lblRecommendations.Text = "No recommendations yet.";
            }
        }

        private void DisplayLastViewed()
        {
            lstLastViewed.Items.Clear();
            var last = EventRepository.GetLastViewed(5);
            if (last.Any())
            {
                lblLastViewed.Text = "Last viewed:";
                foreach (var ev in last)
                    lstLastViewed.Items.Add(ev.Title);
            }
            else
            {
                lblLastViewed.Text = "Last viewed: (none)";
            }
        }

        private void btnSubmitEvent_Click(object sender, EventArgs e)
        {
            var title = txtNewTitle.Text.Trim();
            var cat = txtNewCategory.Text.Trim();
            var desc = txtNewDesc.Text.Trim();
            var date = dtNewDate.Value.Date;

            if (title == "Enter event title..." || cat == "Enter event category..." || desc == "Enter event description...")
            {
                MessageBox.Show("Please fill in all fields before submitting.");
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(cat))
            {
                MessageBox.Show("Please enter both Title and Category.");
                return;
            }

            var newEvent = new Event { Title = title, Category = cat, Date = date, Description = desc };
            EventRepository.SubmitNewEvent(newEvent);
            UpdateSubmissionQueueCount();

            MessageBox.Show("Event added to queue. Click 'Process Submissions' to finalize.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset placeholders
            txtNewTitle.Text = "Enter event title...";
            txtNewTitle.ForeColor = Color.Gray;
            txtNewCategory.Text = "Enter event category...";
            txtNewCategory.ForeColor = Color.Gray;
            txtNewDesc.Text = "Enter event description...";
            txtNewDesc.ForeColor = Color.Gray;
        }

        private void btnProcessSubmissions_Click(object sender, EventArgs e)
        {
            if (EventRepository.SubmissionQueue.Count == 0)
            {
                MessageBox.Show("No pending submissions to process.");
                return;
            }

            EventRepository.ProcessSubmissions();
            DisplayAllEvents();
            UpdateSubmissionQueueCount();

            MessageBox.Show("All submissions processed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateSubmissionQueueCount()
        {
            lblQueueCount.Text = $"Pending submissions: {EventRepository.SubmissionQueue.Count}";
        }
    }
}
