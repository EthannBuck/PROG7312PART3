## Features

### User-Facing Features
- **Report Issues:** Submit issues with detailed fields including `Location`, `Category`, `Description`, and optional images/videos.  
- **Progress Tracking:** Visual feedback through a progress bar that reflects the total number of issues submitted.  
- **Welcome Dashboard:** A central dashboard with a personalized welcome message, latest announcements, and easy navigation.  
- **Category Selection:** Issues can be categorized into predefined categories (Roads, Water, Electricity, Sanitation, Other), ensuring proper routing and analysis.  
- **Announcements Panel:** Displays the latest municipal announcements in visually distinct info boxes for clarity.  

### Admin/Backend Features
- **Custom Data Structures:** Efficient handling of issues using a linked list, queue, and a category-based Binary Search Tree (BST).  
- **Repository Management:** A centralized static repository manages all submitted issues and maintains the data structures for fast retrieval.  
- **Queue Handling:** FIFO queue tracks pending issues in order of submission.  
- **Category Indexing:** BST keyed by category enables quick lookup and efficient organization of issues.  

---

## Architecture

The system follows a **modular design pattern** with clear separation of concerns:

1. **Forms/UI Layer**
   - `Form1` – Main application form with navigation panel, welcome dashboard, announcements, and summary statistics.  
   - `ReportIssueForm` – Dedicated form for submitting new issues with a consistent theme and layout.  
   - `LocalEventsForm` – Displays events and municipal notices in a visually appealing, scrollable panel.  

2. **Models**
   - `IssueReport` – Represents an individual issue with properties such as `Location`, `Category`, `Description`, `MediaPath`, and `Timestamp`.  

3. **Data Structures**
   - `IssueLinkedList` – Custom linked list storing all submitted issues.  
   - `IssueQueue` – FIFO queue for pending issues to maintain order.  
   - `CategoryIndexBST` – BST keyed by issue category, containing linked list buckets for categorized issues.  

4. **Repository**
   - `IssueRepository` – Static class managing all issues and interacting with data structures to support efficient CRUD operations.  

---

## Installation & Requirements

- **System Requirements:**
  - Windows 10 or later  
  - Visual Studio 2022 or higher  
  - .NET Framework 4.7.2 or higher  

- **Setup Instructions:**
  1. Clone or download the repository:  
     `git clone https://github.com/EthannBuck/PROG7312PART3.git`
  2. Open the solution file (`.sln`) in Visual Studio.  
  3. Build the solution to restore any dependencies.  
  4. Run the application using `F5` (Start Debugging) or `Ctrl + F5` (Run without Debugging).  

---

## Usage Guide

1. **Launch the Application**  
   - The welcome dashboard displays with the latest announcements, summary statistics, and navigation panel.

2. **Navigate to "Report an Issue"**  
   - Fill in `Location`, `Category`, `Description`, and optionally attach media.  

3. **Submit the Issue**  
   - Progress bars update automatically, reflecting total issues submitted.  

4. **Check Announcements**  
   - View the latest updates on municipal maintenance, events, and notices.  

5. **Future Functionality**  
   - The "Service Request Status" and "Events and Announcements" sections are placeholders for dynamic data integration.  

---

## UI & UX Design

- **Consistent Visual Theme:** Light blue backgrounds, soft borders, and modern typography (`Segoe UI`) for clarity.  
- **Announcements Panel:** Each announcement displayed in a separate info box with padding, background color, and italic font for emphasis.  
- **Navigation Panel:** Docked to the left with hover effects for interactive user experience.  
- **Summary Section:** Displays metrics like `Total Issues Reported`, `Pending Requests`, and `Categories Tracked` in visually distinct cards.  
- **Accessibility:** High-contrast text and intuitive layout to improve usability for all users.  

---

## Future Enhancements

- **Database Integration:** Connect issue reports to a SQL Server or Azure database for persistent storage and analytics.  
- **User Authentication:** Implement role-based login for citizens and municipal staff.  
- **Real-Time Status Updates:** Dynamically track the progress of submitted issues.  
- **Notification System:** Push notifications or emails for important municipal updates.  
- **Enhanced Analytics:** Provide charts and graphs for issue trends and category summaries.  

---

## Contributing

Contributions are welcome! To contribute:  

1. Fork the repository  
2. Create a feature branch:  
   `git checkout -b feature/new-feature`
3. Commit your changes:  
   `git commit -m 'Add new feature'`
4. Push to the branch:  
   `git push origin feature/new-feature`
5. Open a pull request for review.

---

## License

This project is licensed under the MIT License – see LICENSE for details.

## Author

Ethan Buck  
Computer Application Development Student  
Email: ST10250745@vcconnect.edu.za
GitHub: [https://github.com/EthannBuck/PROG7312PART3.git]
YOUTUBE LINK: https://youtu.be/hGVSAg9R55M 


