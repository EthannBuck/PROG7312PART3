using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label headerTitle;
        private Panel navPanel;
        private Button navHomeBtn;    
        private Button navReportBtn;
        private Button navEventsBtn;
        private Button navStatusBtn;
        private Panel contentPanel;
        private Panel footerPanel;
        private Label footerLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.headerPanel = new Panel();
            this.headerTitle = new Label();
            this.navPanel = new Panel();
            this.navHomeBtn = new Button();
            this.navReportBtn = new Button();
            this.navEventsBtn = new Button();
            this.navStatusBtn = new Button();
            this.contentPanel = new Panel();
            this.footerPanel = new Panel();
            this.footerLabel = new Label();

            this.SuspendLayout();

            // headerPanel
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 70;
            this.headerPanel.BackColor = Color.FromArgb(25, 42, 86);
            this.headerPanel.Controls.Add(this.headerTitle);

            // headerTitle
            this.headerTitle.Dock = DockStyle.Fill;
            this.headerTitle.Text = "Municipality Help System";
            this.headerTitle.ForeColor = Color.White;
            this.headerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.headerTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.headerTitle.Padding = new Padding(20, 0, 0, 0);
            this.headerTitle.AutoSize = false;

            // navPanel
            this.navPanel.Dock = DockStyle.Left;
            this.navPanel.Width = 220;
            this.navPanel.BackColor = Color.FromArgb(240, 243, 250);
            this.navPanel.Padding = new Padding(10);

            // navHomeBtn
            this.navHomeBtn.Name = "navHomeBtn";
            this.navHomeBtn.Text = "Home Page";
            this.navHomeBtn.Dock = DockStyle.Top;
            this.navHomeBtn.Height = 55;
            this.navHomeBtn.FlatStyle = FlatStyle.Flat;
            this.navHomeBtn.FlatAppearance.BorderSize = 0;
            this.navHomeBtn.Margin = new Padding(0, 6, 0, 0);
            this.navHomeBtn.Click += new System.EventHandler(this.navHomeBtn_Click);

            // navReportBtn
            this.navReportBtn.Name = "navReportBtn";
            this.navReportBtn.Text = "Report an Issue";
            this.navReportBtn.Dock = DockStyle.Top;
            this.navReportBtn.Height = 55;
            this.navReportBtn.FlatStyle = FlatStyle.Flat;
            this.navReportBtn.FlatAppearance.BorderSize = 0;
            this.navReportBtn.Margin = new Padding(0, 6, 0, 0);
            this.navReportBtn.Click += new System.EventHandler(this.navReportBtn_Click);

            // navEventsBtn
            this.navEventsBtn.Name = "navEventsBtn";
            this.navEventsBtn.Text = "Events and Announcements";
            this.navEventsBtn.Dock = DockStyle.Top;
            this.navEventsBtn.Height = 55;
            this.navEventsBtn.FlatStyle = FlatStyle.Flat;
            this.navEventsBtn.FlatAppearance.BorderSize = 0;
            this.navEventsBtn.Margin = new Padding(0, 6, 0, 0);
            this.navEventsBtn.Click += new System.EventHandler(this.navEventsBtn_Click);

            // navStatusBtn
            this.navStatusBtn.Name = "navStatusBtn";
            this.navStatusBtn.Text = "Service Request Status";
            this.navStatusBtn.Dock = DockStyle.Top;
            this.navStatusBtn.Height = 55;
            this.navStatusBtn.FlatStyle = FlatStyle.Flat;
            this.navStatusBtn.FlatAppearance.BorderSize = 0;
            this.navStatusBtn.Margin = new Padding(0, 6, 0, 0);
            this.navStatusBtn.Click += new System.EventHandler(this.navStatusBtn_Click);

            // Add nav buttons to navPanel (order matters: last added is top)
            this.navPanel.Controls.Add(this.navStatusBtn);
            this.navPanel.Controls.Add(this.navEventsBtn);
            this.navPanel.Controls.Add(this.navReportBtn);
            this.navPanel.Controls.Add(this.navHomeBtn);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Color.FromArgb(225, 245, 255);

            // footerPanel
            this.footerPanel.Dock = DockStyle.Bottom;
            this.footerPanel.Height = 30;
            this.footerPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.footerPanel.Controls.Add(this.footerLabel);

            // footerLabel
            this.footerLabel.Dock = DockStyle.Fill;
            this.footerLabel.Text = "© 2025 Municipality Help System";
            this.footerLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Main Form
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.navPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.Name = "HomePage";
            this.Text = "Municipality Help System";

            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
        }
    }
}
