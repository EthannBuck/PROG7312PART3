using System.Windows.Forms;

namespace WindowsFormApp1
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox lstEvents;
        private ListBox lstRecommendations;
        private ListBox lstLastViewed;

        private ComboBox cmbCategory;
        private ComboBox cmbSortBy;
        private ComboBox cmbSortOrder;

        private DateTimePicker dtDate;
        private DateTimePicker dtNewDate;

        private TextBox txtSearch;
        private TextBox txtNewTitle;
        private TextBox txtNewCategory;
        private TextBox txtNewDesc;

        private Label lblRecommendations;
        private Label lblLastViewed;
        private Label lblQueueCount;

        private Label lblSearchHint;
        private Label lblNewTitleHint;
        private Label lblNewCatHint;
        private Label lblNewDescHint;

        private Button btnSearch;
        private Button btnClearSearch;
        private Button btnSubmitEvent;
        private Button btnProcessSubmissions;

        private CheckBox chkUseDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.Text = "Local Events";
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;

            // ListBox Events
            this.lstEvents = new ListBox();
            this.lstEvents.Location = new System.Drawing.Point(20, 70);
            this.lstEvents.Size = new System.Drawing.Size(700, 250);
            this.lstEvents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.lstEvents);

            // ListBox Recommendations
            this.lstRecommendations = new ListBox();
            this.lstRecommendations.Location = new System.Drawing.Point(750, 70);
            this.lstRecommendations.Size = new System.Drawing.Size(400, 120);
            this.lstRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.lstRecommendations);

            // ListBox Last Viewed
            this.lstLastViewed = new ListBox();
            this.lstLastViewed.Location = new System.Drawing.Point(750, 250);
            this.lstLastViewed.Size = new System.Drawing.Size(400, 120);
            this.lstLastViewed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.lstLastViewed);

            // ComboBox Category
            this.cmbCategory = new ComboBox();
            this.cmbCategory.Location = new System.Drawing.Point(20, 30);
            this.cmbCategory.Size = new System.Drawing.Size(200, 25);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.cmbCategory);

            // ComboBox SortBy
            this.cmbSortBy = new ComboBox();
            this.cmbSortBy.Location = new System.Drawing.Point(240, 30);
            this.cmbSortBy.Size = new System.Drawing.Size(120, 25);
            this.cmbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.cmbSortBy);

            // ComboBox SortOrder
            this.cmbSortOrder = new ComboBox();
            this.cmbSortOrder.Location = new System.Drawing.Point(370, 30);
            this.cmbSortOrder.Size = new System.Drawing.Size(120, 25);
            this.cmbSortOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSortOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.cmbSortOrder);

            // DateTimePicker Date
            this.dtDate = new DateTimePicker();
            this.dtDate.Location = new System.Drawing.Point(510, 30);
            this.dtDate.Size = new System.Drawing.Size(150, 25);
            this.dtDate.Format = DateTimePickerFormat.Short;
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.dtDate);

            // CheckBox UseDate
            this.chkUseDate = new CheckBox();
            this.chkUseDate.Text = "Use Date Filter";
            this.chkUseDate.Location = new System.Drawing.Point(670, 30);
            this.chkUseDate.Size = new System.Drawing.Size(130, 25);
            this.chkUseDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.chkUseDate);

            // TextBox Search
            this.txtSearch = new TextBox();
            this.txtSearch.Location = new System.Drawing.Point(20, 340);
            this.txtSearch.Size = new System.Drawing.Size(400, 25);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.txtSearch);

            // Label Search Placeholder
            this.lblSearchHint = new Label();
            this.lblSearchHint.Text = "Search events...";
            this.lblSearchHint.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchHint.Location = new System.Drawing.Point(24, 342);
            this.lblSearchHint.AutoSize = true;
            this.lblSearchHint.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblSearchHint);

            // Button Search
            this.btnSearch = new Button();
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(440, 335);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(72, 181, 163);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(this.btnSearch);

            // Button Clear Search
            this.btnClearSearch = new Button();
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.Location = new System.Drawing.Point(550, 335);
            this.btnClearSearch.Size = new System.Drawing.Size(100, 30);
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(252, 163, 17);
            this.btnClearSearch.ForeColor = System.Drawing.Color.White;
            this.btnClearSearch.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(this.btnClearSearch);

            // New event inputs: Title
            this.txtNewTitle = new TextBox();
            this.txtNewTitle.Location = new System.Drawing.Point(20, 410);
            this.txtNewTitle.Size = new System.Drawing.Size(400, 25);
            this.txtNewTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.txtNewTitle);

            this.lblNewTitleHint = new Label();
            this.lblNewTitleHint.Text = "Enter event title...";
            this.lblNewTitleHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewTitleHint.Location = new System.Drawing.Point(24, 412);
            this.lblNewTitleHint.AutoSize = true;
            this.Controls.Add(this.lblNewTitleHint);

            // New event inputs: Category
            this.txtNewCategory = new TextBox();
            this.txtNewCategory.Location = new System.Drawing.Point(20, 450);
            this.txtNewCategory.Size = new System.Drawing.Size(400, 25);
            this.txtNewCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.txtNewCategory);

            this.lblNewCatHint = new Label();
            this.lblNewCatHint.Text = "Enter event category...";
            this.lblNewCatHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewCatHint.Location = new System.Drawing.Point(24, 452);
            this.lblNewCatHint.AutoSize = true;
            this.Controls.Add(this.lblNewCatHint);

            // New event inputs: Description
            this.txtNewDesc = new TextBox();
            this.txtNewDesc.Location = new System.Drawing.Point(20, 490);
            this.txtNewDesc.Size = new System.Drawing.Size(400, 25);
            this.txtNewDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.txtNewDesc);

            this.lblNewDescHint = new Label();
            this.lblNewDescHint.Text = "Enter event description...";
            this.lblNewDescHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewDescHint.Location = new System.Drawing.Point(24, 492);
            this.lblNewDescHint.AutoSize = true;
            this.Controls.Add(this.lblNewDescHint);

            // New event date picker
            this.dtNewDate = new DateTimePicker();
            this.dtNewDate.Location = new System.Drawing.Point(440, 450);
            this.dtNewDate.Size = new System.Drawing.Size(150, 25);
            this.dtNewDate.Format = DateTimePickerFormat.Short;
            this.dtNewDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.dtNewDate);

            // Submit event button
            this.btnSubmitEvent = new Button();
            this.btnSubmitEvent.Text = "Submit Event";
            this.btnSubmitEvent.Location = new System.Drawing.Point(440, 490);
            this.btnSubmitEvent.Size = new System.Drawing.Size(150, 30);
            this.btnSubmitEvent.BackColor = System.Drawing.Color.FromArgb(72, 181, 163);
            this.btnSubmitEvent.ForeColor = System.Drawing.Color.White;
            this.btnSubmitEvent.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(this.btnSubmitEvent);

            // Process submissions button
            this.btnProcessSubmissions = new Button();
            this.btnProcessSubmissions.Text = "Process Submissions";
            this.btnProcessSubmissions.Location = new System.Drawing.Point(440, 530);
            this.btnProcessSubmissions.Size = new System.Drawing.Size(150, 30);
            this.btnProcessSubmissions.BackColor = System.Drawing.Color.FromArgb(252, 163, 17);
            this.btnProcessSubmissions.ForeColor = System.Drawing.Color.White;
            this.btnProcessSubmissions.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(this.btnProcessSubmissions);

            // Pending submissions label
            this.lblQueueCount = new Label();
            this.lblQueueCount.Text = "Pending submissions: 0";
            this.lblQueueCount.Location = new System.Drawing.Point(20, 530);
            this.lblQueueCount.Size = new System.Drawing.Size(400, 25);
            this.lblQueueCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.lblQueueCount);

            // Recommendations label
            this.lblRecommendations = new Label();
            this.lblRecommendations.Text = "Recommended Events:";
            this.lblRecommendations.Location = new System.Drawing.Point(750, 40);
            this.lblRecommendations.Size = new System.Drawing.Size(400, 25);
            this.lblRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(this.lblRecommendations);

            // Last viewed label
            this.lblLastViewed = new Label();
            this.lblLastViewed.Text = "Last viewed:";
            this.lblLastViewed.Location = new System.Drawing.Point(750, 220);
            this.lblLastViewed.Size = new System.Drawing.Size(400, 25);
            this.lblLastViewed.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(this.lblLastViewed);
        }
    }
}
