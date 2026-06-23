🎮 GameHub – GameStore POS & Inventory System

GameHub is a desktop application built for managing retail gaming store operations, tracking inventory, and handling customer sales transactions smoothly. Designed specifically for gaming retailers, it streamlines the workflow of tracking video game titles, consoles, and accessories while logging financial sales in real time.

This project was developed as a 4th-year computer science school project by a team of two [cite: The user attends the Lyceum of Alabang within the College of Computer Studies., The user collaborates with fellow students on academic projects, specifically identifying himself as part of a group in a Computer Science section.], with the database architect taking charge of the relational data layer, connection binding, and backend query structures, while collaborating closely on the user interface forms.


✨ Features

-🔑 User authentication (secure login system for cashiers and administrators)

-📊 Interactive dashboard with high-level sales trends and real-time inventory notifications

-📋 Critical low-stock checklist panel to monitor inventory levels instantly

-📦 Complete Inventory Management (CRUD operations for games, consoles, and accessories)

-🔍 Smart filtering and advanced search utilities built directly into the data grids

-🛒 Fluid Point of Sale (POS) checkout interface with automated subtotaling

-🏷️ Categorization tools to sort inventory by platform, genre, or item type

-🎨 Custom modern dark-themed user interface utilizing optimized graphics and icons


🛠️ Tech Stack

| Layer | Technologies |
| --- | --- |
| **Front-End** | VB.NET (Windows Forms), Visual Studio Designer |
| **Back-End / Logic** | .NET Framework / .NET Core, ADO.NET |
| **Database** | Microsoft Access (`.accdb` / `.mdb`), OLEDB Provider |
| **Assets & Resources** | GDI+ Vector/Raster Graphics (`GameHub Logo.png`, `filter.png`) |

🚀 Getting Started

### Prerequisites

* Windows 10 / 11 Operating System
* Microsoft Visual Studio (2022 recommended) with the **.NET Desktop Development** workload installed
* **Microsoft Access Database Engine Redistributable** (Required if Microsoft Office/Access is not locally installed on your machine to register the `Microsoft.ACE.OLEDB` provider)

### Installation & Configuration

1. **Clone or Extract the Repository**
```bash
git clone https://github.com/your-username/GameStorePOSandInventorySystem.git
cd GameStorePOSandInventorySystem

```



```

2. **Open the Project in Visual Studio**
   * Launch Visual Studio.
   * Select **Open a project or solution**.
   * Navigate to the project root and select `GameStorePOSandInventorySystem.sln`.

3. **Configure the Database Connection String (Crucial Step)**
   Before running the app, you may need to update the connection string path depending on where your local MS Access database file resides. Open your connection module or `App.config` and check the `Data Source`:
   ```vb
   ' Standard relative path layout (expects database in the output directory)
   Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\GameStoreDB.accdb"
   
   ' If you encounter connection errors, change this to your absolute local file path:
   ' Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\YourFolder\GameStorePOSandInventorySystemWorkingNew\WinFormsApp1\GameStoreDB.accdb"

```

4. **Verify Database Table Architecture**
Ensure your Microsoft Access database contains the necessary tables (`Users`, `Inventory`, `Transactions`, `Categories`) with matching data types before executing queries to prevent runtime syntax exceptions.
5. **Build and Run**
* Set the startup form to your login or dashboard interface.
* Press `F5` or click the **Start** button in Visual Studio to compile and launch the application.



📁 Project Structure

```text
GameStorePOSandInventorySystemWorkingNew/
│
├── GameStorePOSandInventorySystem.sln   # Visual Studio Solution File
│
└── WinFormsApp1/                        # Main Application Project Folder
    ├── App.config                       # Application configurations and connection definitions
    ├── Form1.vb / Dashboard.vb          # Main Windows Forms UI and business logic
    ├── Form1.Designer.vb                # Auto-generated designer file for UI elements
    ├── GameStoreDB.accdb                # MS Access Database File (Backend)
    │
    └── Resources/                       # Local UI Graphic Assets
        ├── GameHub Logo.png             # Application branding logo
        ├── Login.png                    # Login module graphic
        ├── filter.png                   # Filter utility button icon
        └── checklist.png                # Dashboard checklist status icon

```

Contributions

* **Me** – Database Architect & Backend Developer
Designed the relational MS Access database schema, established the OLEDB connection layers, wrote SQL CRUD queries, handled dataset data-binding, and co-developed the core UI forms.


⚠️ Important Notes

* **Database Locking Issue:** Microsoft Access creates a temporary locking file (`.ldb` or `.laccdb`) while the application is running. Ensure your project directory has full read/write permissions, and avoid opening the database file manually in Microsoft Access at the same time you debug the application to prevent multi-user write conflict crashes.
* **Architecture Mismatch (x86 vs x64):** If you receive an error stating `The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine`, this is caused by a bitness mismatch. You must change your Visual Studio build target configuration (**Build > Configuration Manager**) from `Any CPU` to explicitly match your installed Office/Access Engine version (typically `x64` or `x86`).
* **Security Notice:** This app is created for educational purposes. Passwords in the MS Access database are stored in plain text configuration for demonstration simplicity; encryption should be integrated before any production retail deployment.

📜 License
This project is developed for educational and academic assessment purposes only. The source code is not licensed for commercial store distribution.

🙏 Acknowledgments

* The Microsoft .NET and Windows Forms documentation for interface controls.
* Our course instructors for structural development guidelines.

Happy gaming and tracking! 🎮
