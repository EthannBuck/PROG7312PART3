using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class ReportIssueForm : Form
    {
        private string _attachedFilePath;
        private HomePage _parentForm;

        public ReportIssueForm(HomePage parent)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10F);

            _parentForm = parent;

            // Setup placeholders on load
            SetupPlaceholders();

            // Populate categories on load
            LoadCategories();

            // Hook up text changed events for progress bar updates
            txtLocation.TextChanged += (s, e) => UpdateProgressBarDynamic();
            richTextBoxDescription.TextChanged += (s, e) => UpdateProgressBarDynamic();
            comboBoxCategory.SelectedIndexChanged += (s, e) => UpdateProgressBarDynamic();
        }

        private void SetupPlaceholders()
        {
            txtLocation.ForeColor = Color.Gray;
            txtLocation.Text = "Enter location of the issue...";
            txtLocation.Enter += (s, e) =>
            {
                if (txtLocation.Text == "Enter location of the issue...")
                {
                    txtLocation.Text = "";
                    txtLocation.ForeColor = Color.Black;
                }
            };
            txtLocation.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    txtLocation.Text = "Enter location of the issue...";
                    txtLocation.ForeColor = Color.Gray;
                }
            };

            richTextBoxDescription.ForeColor = Color.Gray;
            richTextBoxDescription.Text = "Describe the issue in detail...";
            richTextBoxDescription.Enter += (s, e) =>
            {
                if (richTextBoxDescription.Text == "Describe the issue in detail...")
                {
                    richTextBoxDescription.Text = "";
                    richTextBoxDescription.ForeColor = Color.Black;
                }
            };
            richTextBoxDescription.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(richTextBoxDescription.Text))
                {
                    richTextBoxDescription.Text = "Describe the issue in detail...";
                    richTextBoxDescription.ForeColor = Color.Gray;
                }
            };
        }

        private void LoadCategories()
        {
            comboBoxCategory.Items.Clear();

            string[] categories = new string[] { "Roads", "Water", "Electricity", "Sanitation", "Other" };

            foreach (var cat in categories)
                comboBoxCategory.Items.Add(cat);

            if (comboBoxCategory.Items.Count > 0)
                comboBoxCategory.SelectedIndex = 0;
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images and Video|*.jpg;*.jpeg;*.png;*.bmp;*.mp4;*.mov|All files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _attachedFilePath = dlg.FileName;
                    lblAttachment.Text = System.IO.Path.GetFileName(_attachedFilePath);
                    UpdateProgressBarDynamic();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var location = txtLocation.Text?.Trim();
            var category = (comboBoxCategory.SelectedItem ?? "").ToString().Trim();
            var description = richTextBoxDescription.Text?.Trim();

            if (string.IsNullOrEmpty(location) || location == "Enter location of the issue..." ||
                string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(description) || description == "Describe the issue in detail...")
            {
                MessageBox.Show("Please complete Location, Category, and Description before submitting.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var issue = new IssueReport()
            {
                Location = location,
                Category = category,
                Description = description,
                MediaPath = _attachedFilePath,
                SubmittedAt = DateTime.Now
            };

            IssueRepository.Add(issue);

            MessageBox.Show("Your issue has been submitted. Thank you.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            txtLocation.Text = "Enter location of the issue...";
            txtLocation.ForeColor = Color.Gray;

            richTextBoxDescription.Text = "Describe the issue in detail...";
            richTextBoxDescription.ForeColor = Color.Gray;

            comboBoxCategory.SelectedIndex = 0;

            _attachedFilePath = null;
            lblAttachment.Text = "No file attached";

            progressBarEngagement.Value = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parentForm.ShowWelcomeScreen();
            this.Close();
        }

        private void UpdateProgressBarDynamic()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text) && txtLocation.ForeColor != Color.Gray)
                progress++;

            if (!string.IsNullOrWhiteSpace(richTextBoxDescription.Text) && richTextBoxDescription.ForeColor != Color.Gray)
                progress++;

            if (comboBoxCategory.SelectedIndex > 0)
                progress++;

            if (!string.IsNullOrEmpty(_attachedFilePath))
                progress++;

            progressBarEngagement.Maximum = 4;
            progressBarEngagement.Value = progress;
        }
    }
}
