using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class ServiceRequestForm : Form
    {
        private ServiceRequestTree requestTree = new ServiceRequestTree();
        private ServiceRequestHeap requestHeap = new ServiceRequestHeap();
        private ServiceRequestGraph requestGraph = new ServiceRequestGraph();
        private List<ServiceRequest> allRequests = new List<ServiceRequest>();
        private Random rnd = new Random();

        public ServiceRequestForm()
        {
            InitializeComponent();
            this.Load += ServiceRequestForm_Load;

            PopulateSampleData();
            DisplayAllRequests();
        }

        private void ServiceRequestForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1150, 700);

            InitializePlaceholder(txtSearchId, "Enter Request ID...");
            InitializePlaceholder(txtCitizen, "Enter Citizen Name...");
            InitializePlaceholder(txtCategory, "Enter Category...");
            InitializePlaceholder(txtDesc, "Enter Description...");
            InitializePlaceholder(txtPriority, "Enter Priority (1-5)...");

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;

            // Tooltips for buttons
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnSearch, "Search for a request by ID");
            tt.SetToolTip(btnAddRequest, "Add a new service request");
            tt.SetToolTip(btnMST, "Generate Minimum Spanning Tree for service network");
            tt.SetToolTip(btnClearSearch, "Clear search input and results");
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

        private void PopulateSampleData()
        {
            string[] cats = { "Water", "Electricity", "Roads", "Waste", "Housing", "Sewage", "Parks", "Transport" };

            for (int i = 1; i <= 15; i++)
            {
                int priority = rnd.Next(1, 6);
                var req = new ServiceRequest(
                    i,
                    "Citizen " + i,
                    cats[rnd.Next(cats.Length)],
                    "Service issue number " + i,
                    priority
                );

                allRequests.Add(req);
                requestTree.Insert(req);
                requestHeap.Insert(req);
            }

            // Create realistic service network (Graph)
            requestGraph.AddEdge("Water", "Electricity", 3);
            requestGraph.AddEdge("Water", "Roads", 4);
            requestGraph.AddEdge("Roads", "Waste", 2);
            requestGraph.AddEdge("Electricity", "Housing", 6);
            requestGraph.AddEdge("Waste", "Housing", 5);
            requestGraph.AddEdge("Parks", "Transport", 3);
            requestGraph.AddEdge("Sewage", "Water", 2);
        }

        private void DisplayAllRequests()
        {
            lstRequests.Items.Clear();
            foreach (ServiceRequest r in requestTree.InOrder())
                lstRequests.Items.Add(r.ToString());

            lstPriority.Items.Clear();
            foreach (ServiceRequest r in requestHeap.ToList())
                lstPriority.Items.Add(r.ToString());
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchId.Text == "Enter Request ID..." || string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                MessageBox.Show("Please enter a valid Request ID to search.", "Input Error");
                return;
            }

            if (!int.TryParse(txtSearchId.Text, out int id))
            {
                MessageBox.Show("Enter a valid numeric ID.", "Input Error");
                return;
            }

            ServiceRequest found = allRequests.FirstOrDefault(r => r.RequestId == id);
            if (found == null)
            {
                MessageBox.Show($"No request found with ID {id}.", "Not Found");
                lblDetails.Text = "";
                progressBar.Value = 0;
                return;
            }

            // Simulate progress tracking
            found.Progress = rnd.Next(0, 101);
            progressBar.Value = found.Progress;

            if (found.Progress < 30) found.Status = "Pending";
            else if (found.Progress < 80) found.Status = "In Progress";
            else found.Status = "Completed";

            lblDetails.Text =
                $"Request ID: {found.RequestId}\n" +
                $"Citizen: {found.CitizenName}\n" +
                $"Category: {found.Category}\n" +
                $"Description: {found.Description}\n" +
                $"Priority: {found.Priority}\n" +
                $"Status: {found.Status}\n" +
                $"Progress: {found.Progress}%";

            HighlightRequestInLists(found);
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchId.Text = "Enter Request ID...";
            progressBar.Value = 0;
            lblDetails.Text = "";
        }

        private void HighlightRequestInLists(ServiceRequest found)
        {
            // Select in lstRequests
            for (int i = 0; i < lstRequests.Items.Count; i++)
            {
                if (lstRequests.Items[i].ToString().Contains($"ID: {found.RequestId}"))
                {
                    lstRequests.SelectedIndex = i;
                    break;
                }
            }
            // Select in lstPriority
            for (int i = 0; i < lstPriority.Items.Count; i++)
            {
                if (lstPriority.Items[i].ToString().Contains($"ID: {found.RequestId}"))
                {
                    lstPriority.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnAddRequest_Click(object sender, EventArgs e)
        {
            // Validate citizen name
            if (string.IsNullOrWhiteSpace(txtCitizen.Text) || txtCitizen.Text == "Enter Citizen Name...")
            {
                MessageBox.Show("Please enter a valid Citizen Name.", "Input Error");
                txtCitizen.Focus();
                return;
            }

            // Validate category
            if (string.IsNullOrWhiteSpace(txtCategory.Text) || txtCategory.Text == "Enter Category...")
            {
                MessageBox.Show("Please enter a valid Category.", "Input Error");
                txtCategory.Focus();
                return;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(txtDesc.Text) || txtDesc.Text == "Enter Description...")
            {
                MessageBox.Show("Please enter a Description.", "Input Error");
                txtDesc.Focus();
                return;
            }

            // Validate priority
            if (!int.TryParse(txtPriority.Text, out int priority) || priority < 1 || priority > 5)
            {
                MessageBox.Show("Please enter a valid Priority between 1 and 5.", "Input Error");
                txtPriority.Focus();
                return;
            }

            int id = allRequests.Count + 1;
            ServiceRequest newRequest = new ServiceRequest(id, txtCitizen.Text.Trim(), txtCategory.Text.Trim(), txtDesc.Text.Trim(), priority);

            allRequests.Add(newRequest);
            requestTree.Insert(newRequest);
            requestHeap.Insert(newRequest);

            DisplayAllRequests();

            MessageBox.Show("Request added successfully!", "Success");

            ClearAddRequestInputs();
        }

        private void ClearAddRequestInputs()
        {
            txtCitizen.Text = "Enter Citizen Name...";
            txtCitizen.ForeColor = Color.Gray;

            txtCategory.Text = "Enter Category...";
            txtCategory.ForeColor = Color.Gray;

            txtDesc.Text = "Enter Description...";
            txtDesc.ForeColor = Color.Gray;

            txtPriority.Text = "Enter Priority (1-5)...";
            txtPriority.ForeColor = Color.Gray;
        }

        private void BtnMST_Click(object sender, EventArgs e)
        {
            lstMST.Items.Clear();

            List<ServiceGraphEdge> mst = requestGraph.MinimumSpanningTree();

            if (mst.Count == 0)
            {
                lstMST.Items.Add("No network connections found.");
                return;
            }

            foreach (var edge in mst)
            {
                lstMST.Items.Add($"{edge.A} ↔ {edge.B} (Weight {edge.Weight})");
            }
        }

        private void BtnBFS_Click(object sender, EventArgs e)
        {
            lstMST.Items.Clear();

            if (!requestGraph.HasAnyNodes())
            {
                lstMST.Items.Add("No network data available.");
                return;
            }

            // Start BFS from first department (e.g., "Water")
            string startNode = requestGraph.GetFirstNode();
            var bfsOrder = requestGraph.BFS(startNode);

            lstMST.Items.Add("BFS Traversal Order:");
            lstMST.Items.Add("--------------------------");

            foreach (var node in bfsOrder)
                lstMST.Items.Add("→ " + node);

            lstMST.Items.Add("--------------------------");
            lstMST.Items.Add($"Total Visited Nodes: {bfsOrder.Count}");
        }

        private void BtnDFS_Click(object sender, EventArgs e)
        {
            lstMST.Items.Clear();

            if (!requestGraph.HasAnyNodes())
            {
                lstMST.Items.Add("No network data available.");
                return;
            }

            string startNode = requestGraph.GetFirstNode();
            var dfsOrder = requestGraph.DFS(startNode);

            lstMST.Items.Add("DFS Traversal Order:");
            lstMST.Items.Add("--------------------------");

            foreach (var node in dfsOrder)
                lstMST.Items.Add("→ " + node);

            lstMST.Items.Add("--------------------------");
            lstMST.Items.Add($"Total Visited Nodes: {dfsOrder.Count}");
        }
    }
}
