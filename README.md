# Support Desk Application

A modern, responsive support ticket management system built with ASP.NET Core MVC and SQLite.

## Demo

https://github.com/user-attachments/assets/a21df82f-6f97-48b3-9f3d-e419d5eeb8f2

## Additional Screenshots
<img width="1898" height="854" alt="Screenshot 2025-09-13 103756" src="https://github.com/user-attachments/assets/736ecae0-efa5-4ed5-a577-aa5196476cef" />

### Priority Filter
<img width="1893" height="276" alt="Priority Filer" src="https://github.com/user-attachments/assets/b2598ad2-7851-4aad-b393-a4d35290a4fa" />

### Status Info
<img width="1898" height="265" alt="Status filter" src="https://github.com/user-attachments/assets/7142b19b-d8a4-4e13-8447-f229bcab30f7" />

## Ticket Info
<img width="1262" height="857" alt="Ticket INFO" src="https://github.com/user-attachments/assets/b7996127-5bef-4c86-955f-de6a49e7a10b" />

## Features

### 🎯 Core Functionality
- **Create Tickets** - Submit support requests with title, description, and priority
- **View All Tickets** - Dashboard with statistics and ticket overview
- **Edit Tickets** - Update ticket details and status
- **Delete Tickets** - Remove tickets with confirmation
- **Ticket Details** - Comprehensive view with metadata and quick actions

### 🔍 Advanced Features
- **Search & Filter** - Find tickets by title, description, status, or priority
- **Sortable Columns** - Click headers to sort by title, status, priority, or date
- **Quick Status Updates** - Change ticket status without full page reload
- **Responsive Design** - Works perfectly on desktop, tablet, and mobile
- **Real-time Feedback** - Toast notifications and loading states

### 📊 Dashboard Statistics
- Total tickets count
- Open tickets counter
- In-progress tickets tracker
- Closed tickets summary

## Technology Stack

- **Backend**: ASP.NET Core MVC (.NET 6+)
- **Database**: SQLite with Entity Framework Core
- **Frontend**: Bootstrap 5, Font Awesome, Vanilla JavaScript
- **UI/UX**: Modern responsive design with animations

## Project Structure

```
SupportDeskAppNew/
├── Controllers/
│   └── TicketsController.cs          # Main controller with CRUD operations
├── Models/
│   └── Ticket.cs                     # Ticket entity model
├── Data/
│   └── AppDbContext.cs               # Database context
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml            # Main layout with navigation
│   └── Tickets/
│       ├── Index.cshtml              # Dashboard and ticket list
│       ├── Create.cshtml             # New ticket form
│       ├── Edit.cshtml               # Edit ticket form
│       └── Details.cshtml            # Ticket detail view
├── Program.cs                        # App configuration
└── appsettings.json                  # Application settings
```

## Quick Start

### Prerequisites
- .NET 6 SDK or higher
- Visual Studio 2022 or VS Code

### Installation

1. **Clone or download** the project files
2. **Navigate** to the project directory:
   ```bash
   cd SupportDeskAppNew
   ```
3. **Restore packages**:
   ```bash
   dotnet restore
   ```
4. **Build the project**:
   ```bash
   dotnet build
   ```
5. **Run the application**:
   ```bash
   dotnet run
   ```
6. **Open your browser** and go to `https://localhost:5001` or `http://localhost:5000`

## Usage

### Creating a New Ticket
1. Click **"Create New Ticket"** button
2. Fill in the title and description
3. Select priority level (Low, Medium, High)
4. Click **"Submit Ticket"**

### Managing Tickets
- **View**: Click the eye icon to see full ticket details
- **Edit**: Click the edit icon to modify ticket information
- **Delete**: Click the trash icon and confirm deletion
- **Quick Status**: Use the status dropdown directly in the table

### Filtering & Searching
- Use the search box to find tickets by title or description
- Filter by status: All, Open, In Progress, Closed
- Filter by priority: All, Low, Medium, High
- Click column headers to sort results

## Database

The application uses SQLite database (`supportdesk.db`) which is automatically created when you first run the app. The database includes:

### Ticket Table
- **Id**: Primary key (auto-increment)
- **Title**: Required ticket title
- **Description**: Optional detailed description
- **Status**: Open, In Progress, or Closed
- **Priority**: Low, Medium, or High
- **Created**: Auto-generated timestamp

## Customization

### Styling
- Modify CSS in `Views/Shared/_Layout.cshtml`
- Bootstrap 5 classes are used throughout
- Custom CSS variables for easy color scheme changes

### Business Logic
- Edit `Controllers/TicketsController.cs` for functionality changes
- Modify `Models/Ticket.cs` for data structure updates
- Update `Data/AppDbContext.cs` for database changes

## Browser Support

- Chrome 90+
- Firefox 88+
- Safari 14+
- Edge 90+
- Mobile browsers (iOS Safari, Chrome Mobile)

## License

This project is open source and available under the [MIT License](LICENSE).

## Support

For questions or issues:
- Check the code comments for implementation details
- Review the browser console for any JavaScript errors
- Ensure all NuGet packages are properly restored

---

**Built with ❤️ using ASP.NET Core MVC**
