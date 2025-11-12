using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1660, 920);
            this.MinimumSize = new Size(1000, 600);
            this.Font = new Font("Segoe UI", 10);

            // Style nav buttons
            StyleButton(navHomeBtn);
            StyleButton(navReportBtn);
            StyleButton(navEventsBtn);
            StyleButton(navStatusBtn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowWelcomeScreen();
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(240, 240, 250);
            btn.ForeColor = Color.FromArgb(40, 40, 80);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(220, 230, 250);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(240, 240, 250);
        }

        public void ShowWelcomeScreen()
        {
            contentPanel.Controls.Clear();

            int margin = 20;
            int panelWidth = contentPanel.Width - 2 * margin;

            // Greeting label 
            Label welcomeLabel = new Label
            {
                Text = $"{GetTimeBasedGreeting()}\nWelcome to the Municipality Help System!\n\nStay informed and involved in your community.",
                Location = new Point(margin, margin),
                Size = new Size(panelWidth, 100),
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                ForeColor = Color.FromArgb(40, 60, 110),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(welcomeLabel);

            // Announcements Panel 
            Panel announcementsPanel = new Panel
            {
                Size = new Size((panelWidth / 2) - margin, 150),
                Location = new Point(margin, welcomeLabel.Bottom + margin),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            Label announcementsTitle = new Label
            {
                Text = "Announcements",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(40, 60, 110)
            };
            ListBox announcementsList = new ListBox
            {
                Location = new Point(10, 45),
                Size = new Size(announcementsPanel.Width - 25, announcementsPanel.Height - 55),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.None,
                BackColor = announcementsPanel.BackColor,
                SelectionMode = SelectionMode.None
            };
            announcementsList.Items.Add("Water maintenance scheduled for Nov 15, 8AM - 2PM");
            announcementsList.Items.Add("Community meeting on Dec 1 at Town Hall");
            announcementsList.Items.Add("Road repairs on Main Street starting Nov 20");
            announcementsPanel.Controls.Add(announcementsTitle);
            announcementsPanel.Controls.Add(announcementsList);
            contentPanel.Controls.Add(announcementsPanel);

            // Weather Panel 
            Panel weatherPanel = new Panel
            {
                Size = new Size((panelWidth / 2) - margin, 150),
                Location = new Point(announcementsPanel.Right + margin, welcomeLabel.Bottom + margin),
                BackColor = Color.FromArgb(230, 245, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Label weatherTitle = new Label
            {
                Text = "Local Weather",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(40, 60, 110)
            };
            Label weatherDesc = new Label
            {
                Text = "Sunny, 25°C\nHumidity: 40%\nWind: 12 km/h NW",
                Font = new Font("Segoe UI", 12),
                Location = new Point(10, 50),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 60)
            };
            weatherPanel.Controls.Add(weatherTitle);
            weatherPanel.Controls.Add(weatherDesc);
            contentPanel.Controls.Add(weatherPanel);

            // Stats Panel 
            Panel statsPanel = new Panel
            {
                Location = new Point(margin, weatherPanel.Bottom + margin),
                Size = new Size(panelWidth, 120),
                BackColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            int statBoxWidth = 250;
            int statBoxSpacing = 30;
            int totalWidth = (statBoxWidth * 3) + (statBoxSpacing * 2);
            int startX = (statsPanel.Width - totalWidth) / 2;

            statsPanel.Controls.Add(CreateStatBox("Open Service Requests", "27", Color.FromArgb(252, 163, 23), new Point(startX, 10), statBoxWidth));
            statsPanel.Controls.Add(CreateStatBox("Upcoming Events", "5", Color.FromArgb(72, 181, 163), new Point(startX + statBoxWidth + statBoxSpacing, 10), statBoxWidth));
            statsPanel.Controls.Add(CreateStatBox("Reports Submitted This Month", "124", Color.FromArgb(40, 60, 110), new Point(startX + 2 * (statBoxWidth + statBoxSpacing), 10), statBoxWidth));

            contentPanel.Controls.Add(statsPanel);
        }

        // Helper method: greeting based on time
        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning!";
            if (hour < 18) return "Good afternoon!";
            return "Good evening!";
        }

        // Helper method: create summary stat box (panel with label and big number)
        private Panel CreateStatBox(string title, string number, Color color, Point location, int width)
        {
            Panel box = new Panel
            {
                Size = new Size(width, 100),
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            Label lblNumber = new Label
            {
                Text = number,
                Font = new Font("Segoe UI", 30, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 15),
                AutoSize = true
            };
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 70, 100),
                Location = new Point(15, 65),
                AutoSize = true
            };
            box.Controls.Add(lblNumber);
            box.Controls.Add(lblTitle);
            return box;
        }

   
        // Navigation button click handlers

        private void navHomeBtn_Click(object sender, EventArgs e)
        {
            ShowWelcomeScreen();
        }

        private void navReportBtn_Click(object sender, EventArgs e)
        {
            ShowFormInContent(new ReportIssueForm(this));
        }

        private void navEventsBtn_Click(object sender, EventArgs e)
        {
            ShowFormInContent(new LocalEventsForm(this));
        }

        private void navStatusBtn_Click(object sender, EventArgs e)
        {
            ShowFormInContent(new ServiceRequestForm());
        }

        private void ShowFormInContent(Form form)
        {
            contentPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}