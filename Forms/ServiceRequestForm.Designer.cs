using System.Drawing;

namespace WindowsFormApp1
{
    partial class ServiceRequestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstRequests;
        private System.Windows.Forms.ListBox lstPriority;
        private System.Windows.Forms.ListBox lstMST;

        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;

        private System.Windows.Forms.TextBox txtCitizen;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Button btnAddRequest;

        private System.Windows.Forms.Button btnMST;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnDFS;

        private System.Windows.Forms.Label lblDetails;

        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblMST;

        private System.Windows.Forms.Label lblSearchId;
        private System.Windows.Forms.Label lblCitizen;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblPriorityLabel;

        private System.Windows.Forms.GroupBox grpLists;
        private System.Windows.Forms.GroupBox grpAddRequest;
        private System.Windows.Forms.GroupBox grpSearch;

        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            var primaryColor = System.Drawing.Color.FromArgb(72, 181, 163);
            var secondaryColor = System.Drawing.Color.FromArgb(252, 163, 17);
            var buttonTextColor = System.Drawing.Color.White;
            var backgroundColor = System.Drawing.Color.White;
            var defaultFont = new System.Drawing.Font("Segoe UI", 10F);
            var groupBoxFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // Instantiate controls explicitly
            this.grpLists = new System.Windows.Forms.GroupBox();
            this.grpAddRequest = new System.Windows.Forms.GroupBox();
            this.grpSearch = new System.Windows.Forms.GroupBox();

            this.lblRequests = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblMST = new System.Windows.Forms.Label();

            this.lstRequests = new System.Windows.Forms.ListBox();
            this.lstPriority = new System.Windows.Forms.ListBox();
            this.lstMST = new System.Windows.Forms.ListBox();

            this.lblSearchId = new System.Windows.Forms.Label();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();

            this.lblCitizen = new System.Windows.Forms.Label();
            this.txtCitizen = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblPriorityLabel = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.btnAddRequest = new System.Windows.Forms.Button();

            this.btnMST = new System.Windows.Forms.Button();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();

            this.lblDetails = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            // Form settings
            this.SuspendLayout();
            this.Text = "Service Request Status";
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = backgroundColor;
            this.Font = defaultFont;

            // GroupBoxes properties
            this.grpLists.Location = new System.Drawing.Point(10, 10);
            this.grpLists.Size = new System.Drawing.Size(1120, 320);
            this.grpLists.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.grpLists.Font = groupBoxFont;
            this.grpLists.ForeColor = primaryColor;

            this.grpAddRequest.Text = "Add New Service Request";
            this.grpAddRequest.Location = new System.Drawing.Point(10, 450);
            this.grpAddRequest.Size = new System.Drawing.Size(520, 230);
            this.grpAddRequest.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.grpAddRequest.Font = groupBoxFont;
            this.grpAddRequest.ForeColor = primaryColor;

            this.grpSearch.Text = "Search Service Request by ID";
            this.grpSearch.Location = new System.Drawing.Point(10, 340);
            this.grpSearch.Size = new System.Drawing.Size(520, 100);
            this.grpSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.grpSearch.Font = groupBoxFont;
            this.grpSearch.ForeColor = primaryColor;

            // Labels for lists inside grpLists
            this.lblRequests.Text = "All Requests (Tree InOrder)";
            this.lblRequests.Location = new System.Drawing.Point(20, 20);
            this.lblRequests.Size = new System.Drawing.Size(200, 20);
            this.lblRequests.ForeColor = System.Drawing.Color.Black;
            this.lblRequests.Font = defaultFont;

            this.lblPriority.Text = "Priority Queue (Heap)";
            this.lblPriority.Location = new System.Drawing.Point(400, 20);
            this.lblPriority.Size = new System.Drawing.Size(200, 20);
            this.lblPriority.ForeColor = System.Drawing.Color.Black;
            this.lblPriority.Font = defaultFont;

            this.lblMST.Text = "Service Network MST";
            this.lblMST.Location = new System.Drawing.Point(780, 20);
            this.lblMST.Size = new System.Drawing.Size(200, 20);
            this.lblMST.ForeColor = System.Drawing.Color.Black;
            this.lblMST.Font = defaultFont;

            // ListBoxes inside grpLists
            this.lstRequests.Location = new System.Drawing.Point(20, 45);
            this.lstRequests.Size = new System.Drawing.Size(350, 250);
            this.lstRequests.TabIndex = 0;
            this.lstRequests.Font = defaultFont;
            this.lstRequests.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lstPriority.Location = new System.Drawing.Point(400, 45);
            this.lstPriority.Size = new System.Drawing.Size(350, 250);
            this.lstPriority.TabIndex = 1;
            this.lstPriority.Font = defaultFont;
            this.lstPriority.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lstMST.Location = new System.Drawing.Point(780, 45);
            this.lstMST.Size = new System.Drawing.Size(320, 250);
            this.lstMST.TabIndex = 2;
            this.lstMST.Font = defaultFont;
            this.lstMST.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstMST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Add labels and listboxes to grpLists
            this.grpLists.Controls.Add(this.lblRequests);
            this.grpLists.Controls.Add(this.lblPriority);
            this.grpLists.Controls.Add(this.lblMST);

            this.grpLists.Controls.Add(this.lstRequests);
            this.grpLists.Controls.Add(this.lstPriority);
            this.grpLists.Controls.Add(this.lstMST);

            // Search group controls
            this.lblSearchId.Text = "Request ID:";
            this.lblSearchId.Location = new System.Drawing.Point(15, 40);
            this.lblSearchId.Size = new System.Drawing.Size(75, 20);
            this.lblSearchId.ForeColor = System.Drawing.Color.Black;
            this.lblSearchId.Font = defaultFont;

            this.txtSearchId.Location = new System.Drawing.Point(95, 38);
            this.txtSearchId.Size = new System.Drawing.Size(150, 25);
            this.txtSearchId.TabIndex = 3;
            this.txtSearchId.Font = defaultFont;
            this.txtSearchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnSearch.Location = new System.Drawing.Point(260, 35);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.TabIndex = 4;
            this.btnSearch.BackColor = primaryColor;
            this.btnSearch.ForeColor = buttonTextColor;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            this.btnClearSearch.Location = new System.Drawing.Point(370, 35);
            this.btnClearSearch.Size = new System.Drawing.Size(100, 30);
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.TabIndex = 5;
            this.btnClearSearch.BackColor = secondaryColor;
            this.btnClearSearch.ForeColor = buttonTextColor;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSearch.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.Click += new System.EventHandler(this.BtnClearSearch_Click);

            this.grpSearch.Controls.Add(this.lblSearchId);
            this.grpSearch.Controls.Add(this.txtSearchId);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnClearSearch);

            // Add Request group controls
            this.lblCitizen.Text = "Citizen Name:";
            this.lblCitizen.Location = new System.Drawing.Point(15, 30);
            this.lblCitizen.Size = new System.Drawing.Size(100, 20);
            this.lblCitizen.ForeColor = System.Drawing.Color.Black;
            this.lblCitizen.Font = defaultFont;

            this.txtCitizen.Location = new System.Drawing.Point(130, 28);
            this.txtCitizen.Size = new System.Drawing.Size(200, 25);
            this.txtCitizen.TabIndex = 6;
            this.txtCitizen.Font = defaultFont;
            this.txtCitizen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(15, 70);
            this.lblCategory.Size = new System.Drawing.Size(100, 20);
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Font = defaultFont;

            this.txtCategory.Location = new System.Drawing.Point(130, 68);
            this.txtCategory.Size = new System.Drawing.Size(200, 25);
            this.txtCategory.TabIndex = 7;
            this.txtCategory.Font = defaultFont;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblDesc.Text = "Description:";
            this.lblDesc.Location = new System.Drawing.Point(15, 110);
            this.lblDesc.Size = new System.Drawing.Size(100, 20);
            this.lblDesc.ForeColor = System.Drawing.Color.Black;
            this.lblDesc.Font = defaultFont;

            this.txtDesc.Location = new System.Drawing.Point(130, 108);
            this.txtDesc.Size = new System.Drawing.Size(350, 25);
            this.txtDesc.TabIndex = 8;
            this.txtDesc.Font = defaultFont;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblPriorityLabel.Text = "Priority (1-5):";
            this.lblPriorityLabel.Location = new System.Drawing.Point(15, 150);
            this.lblPriorityLabel.Size = new System.Drawing.Size(100, 20);
            this.lblPriorityLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPriorityLabel.Font = defaultFont;

            this.txtPriority.Location = new System.Drawing.Point(130, 148);
            this.txtPriority.Size = new System.Drawing.Size(80, 25);
            this.txtPriority.TabIndex = 9;
            this.txtPriority.Font = defaultFont;
            this.txtPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnAddRequest.Location = new System.Drawing.Point(130, 190);
            this.btnAddRequest.Size = new System.Drawing.Size(150, 30);
            this.btnAddRequest.Text = "Add Request";
            this.btnAddRequest.TabIndex = 10;
            this.btnAddRequest.BackColor = primaryColor;
            this.btnAddRequest.ForeColor = buttonTextColor;
            this.btnAddRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRequest.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnAddRequest.FlatAppearance.BorderSize = 0;
            this.btnAddRequest.Click += new System.EventHandler(this.BtnAddRequest_Click);

            this.grpAddRequest.Controls.Add(this.lblCitizen);
            this.grpAddRequest.Controls.Add(this.txtCitizen);
            this.grpAddRequest.Controls.Add(this.lblCategory);
            this.grpAddRequest.Controls.Add(this.txtCategory);
            this.grpAddRequest.Controls.Add(this.lblDesc);
            this.grpAddRequest.Controls.Add(this.txtDesc);
            this.grpAddRequest.Controls.Add(this.lblPriorityLabel);
            this.grpAddRequest.Controls.Add(this.txtPriority);
            this.grpAddRequest.Controls.Add(this.btnAddRequest);

            // MST button
            this.btnMST.Location = new System.Drawing.Point(550, 520);
            this.btnMST.Size = new System.Drawing.Size(150, 50);
            this.btnMST.Text = "Generate MST";
            this.btnMST.TabIndex = 11;
            this.btnMST.BackColor = primaryColor;
            this.btnMST.ForeColor = buttonTextColor;
            this.btnMST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMST.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMST.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnMST.FlatAppearance.BorderSize = 0;
            this.btnMST.Click += new System.EventHandler(this.BtnMST_Click);

            // BFS button
            this.btnBFS.Location = new System.Drawing.Point(550, 590);
            this.btnBFS.Size = new System.Drawing.Size(150, 50);
            this.btnBFS.Text = "Run BFS Traversal";
            this.btnBFS.BackColor = primaryColor;
            this.btnBFS.ForeColor = buttonTextColor;
            this.btnBFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBFS.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnBFS.TabIndex = 12;
            this.btnBFS.FlatAppearance.BorderSize = 0;
            this.btnBFS.Click += new System.EventHandler(this.BtnBFS_Click);

            // DFS button
            this.btnDFS.Location = new System.Drawing.Point(550, 660);
            this.btnDFS.Size = new System.Drawing.Size(150, 50);
            this.btnDFS.Text = "Run DFS Traversal";
            this.btnDFS.BackColor = secondaryColor;
            this.btnDFS.ForeColor = buttonTextColor;
            this.btnDFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDFS.Font = new System.Drawing.Font(defaultFont, System.Drawing.FontStyle.Bold);
            this.btnDFS.TabIndex = 13;
            this.btnDFS.FlatAppearance.BorderSize = 0;
            this.btnDFS.Click += new System.EventHandler(this.BtnDFS_Click);

            // Details label
            this.lblDetails.Location = new System.Drawing.Point(720, 450);
            this.lblDetails.Size = new System.Drawing.Size(400, 220);
            this.lblDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetails.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblDetails.Text = "Select or search a request to see details here.";
            this.lblDetails.AutoEllipsis = true;
            this.lblDetails.BackColor = System.Drawing.Color.White;
            this.lblDetails.ForeColor = System.Drawing.Color.Black;

            // Progress bar
            this.progressBar.Location = new System.Drawing.Point(720, 680);
            this.progressBar.Size = new System.Drawing.Size(400, 25);
            this.progressBar.TabIndex = 14;

            // Add controls to Form
            this.Controls.Add(this.grpLists);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpAddRequest);
            this.Controls.Add(this.btnMST);
            this.Controls.Add(this.btnBFS);
            this.Controls.Add(this.btnDFS);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.progressBar);

            this.ResumeLayout(false);
        }
    }
}
