using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Panel panelInputs;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblCategory;
        private ComboBox comboBoxCategory;
        private Label lblDescription;
        private RichTextBox richTextBoxDescription;
        private Button btnAttachMedia;
        private Label lblAttachment;
        private Button btnSubmit;
        private ProgressBar progressBarEngagement;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new Label();
            this.panelInputs = new Panel();
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblCategory = new Label();
            this.comboBoxCategory = new ComboBox();
            this.lblDescription = new Label();
            this.richTextBoxDescription = new RichTextBox();
            this.btnAttachMedia = new Button();
            this.lblAttachment = new Label();
            this.btnSubmit = new Button();
            this.progressBarEngagement = new ProgressBar();
            this.btnBack = new Button();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(900, 600);
            this.Text = "Report an Issue";
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10F);

            // lblHeader
            this.lblHeader.Text = "Report an Issue";
            this.lblHeader.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.Black;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new Point(30, 30);

            // panelInputs
            this.panelInputs.Location = new Point(30, 90);
            this.panelInputs.Size = new Size(840, 470);
            this.panelInputs.BackColor = Color.White;
            this.panelInputs.BorderStyle = BorderStyle.FixedSingle;

            // lblLocation
            this.lblLocation.Text = "Location:";
            this.lblLocation.Location = new Point(20, 20);
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new Font("Segoe UI", 12F);
            this.lblLocation.ForeColor = Color.FromArgb(72, 181, 163); 

            // txtLocation
            this.txtLocation.Location = new Point(140, 17);
            this.txtLocation.Size = new Size(650, 34);
            this.txtLocation.Font = new Font("Segoe UI", 12F);
            this.txtLocation.BorderStyle = BorderStyle.FixedSingle;

            // lblCategory
            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new Point(20, 70);
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 12F);
            this.lblCategory.ForeColor = Color.FromArgb(72, 181, 163);

            // comboBoxCategory
            this.comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Location = new Point(140, 67);
            this.comboBoxCategory.Size = new Size(350, 34);
            this.comboBoxCategory.Font = new Font("Segoe UI", 12F);
            this.comboBoxCategory.FlatStyle = FlatStyle.Flat;

            // lblDescription
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new Point(20, 120);
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 12F);
            this.lblDescription.ForeColor = Color.FromArgb(72, 181, 163);

            // richTextBoxDescription
            this.richTextBoxDescription.Location = new Point(140, 117);
            this.richTextBoxDescription.Size = new Size(650, 160);
            this.richTextBoxDescription.Font = new Font("Segoe UI", 12F);
            this.richTextBoxDescription.BorderStyle = BorderStyle.FixedSingle;

            // btnAttachMedia
            this.btnAttachMedia.Text = "Attach Media";
            this.btnAttachMedia.Location = new Point(140, 290);
            this.btnAttachMedia.Size = new Size(160, 45);
            this.btnAttachMedia.BackColor = Color.FromArgb(72, 181, 163); 
            this.btnAttachMedia.ForeColor = Color.White;
            this.btnAttachMedia.FlatStyle = FlatStyle.Flat;
            this.btnAttachMedia.Font = new Font("Segoe UI", 12F);
            this.btnAttachMedia.FlatAppearance.BorderSize = 0;
            this.btnAttachMedia.Click += new EventHandler(this.btnAttachMedia_Click);

            // lblAttachment
            this.lblAttachment.Text = "No file attached";
            this.lblAttachment.Location = new Point(320, 300);
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Font = new Font("Segoe UI", 11F);
            this.lblAttachment.ForeColor = Color.Gray;

            // btnSubmit
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new Point(140, 350);
            this.btnSubmit.Size = new Size(160, 50);
            this.btnSubmit.BackColor = Color.FromArgb(252, 163, 23);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Font = new Font("Segoe UI", 12F);
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // btnBack
            this.btnBack.Text = "Back";
            this.btnBack.Location = new Point(320, 350);
            this.btnBack.Size = new Size(160, 50);
            this.btnBack.BackColor = Color.FromArgb(72, 181, 163);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Font = new Font("Segoe UI", 12F);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // progressBarEngagement
            this.progressBarEngagement.Location = new Point(140, 420);
            this.progressBarEngagement.Size = new Size(650, 30);
            this.progressBarEngagement.ForeColor = Color.FromArgb(252, 163, 23);
            this.progressBarEngagement.Maximum = 4;
            this.progressBarEngagement.Value = 0;

            // Add controls to panelInputs
            this.panelInputs.Controls.Add(this.lblLocation);
            this.panelInputs.Controls.Add(this.txtLocation);
            this.panelInputs.Controls.Add(this.lblCategory);
            this.panelInputs.Controls.Add(this.comboBoxCategory);
            this.panelInputs.Controls.Add(this.lblDescription);
            this.panelInputs.Controls.Add(this.richTextBoxDescription);
            this.panelInputs.Controls.Add(this.btnAttachMedia);
            this.panelInputs.Controls.Add(this.lblAttachment);
            this.panelInputs.Controls.Add(this.btnSubmit);
            this.panelInputs.Controls.Add(this.btnBack);
            this.panelInputs.Controls.Add(this.progressBarEngagement);

            // Add panel and header to form
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelInputs);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
