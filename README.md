# 📝 Document Approval Workflow System

A professional **N-Tier Architecture** implementation for managing document metadata and sequential approval workflows, built with **.NET 8**.

---

## 🏗 Architecture Overview

The project is structured into three decoupled layers to ensure **Separation of Concerns (SoC)**:

* **`Task.NET` (Presentation Layer):** ASP.NET Core Web API handling HTTP requests, JWT Authentication, and Swagger documentation.
* **`BusinessLogic` (Service Layer):** Contains the core workflow logic, DTOs, and AutoMapper profiles.
* **`DataAccess` (Data Layer):** Handles database persistence using EF Core, Repository Pattern, and Fluent API configurations.

---

## 🚀 Key Features

* **Sequential Approval Engine:** Implements a strict order-based workflow (e.g., Employee 2 cannot approve before Employee 1).
* **Automated Status Transitions:** Document status automatically moves from `Pending` to `Approved` upon final signature.
* **Identity & Security:** Role-based access control (RBAC) using **ASP.NET Core Identity** and **JWT Bearer Tokens**.
* **Clean Data Handling:** Utilizes **AutoMapper** to decouple Domain Entities from API Responses (DTOs).
* **Result Pattern:** Uses a unified `ApprovalResult` object for consistent service-to-controller communication.

---

## 🛠 Tech Stack

| Technology | Purpose |
| :--- | :--- |
| **.NET 8** | Core Framework |
| **EF Core** | Object-Relational Mapper (ORM) |
| **SQL Server** | Database Engine |
| **AutoMapper** | Object-to-Object Mapping |
| **JWT** | Secure Authentication |
| **Swagger** | API Testing & Documentation |

---

## 📂 Design Patterns & Best Practices

1.  **Repository Pattern:** Abstracts data access logic for better testability.
2.  **DTO Pattern:** Prevents over-posting and secures internal entity structures.
3.  **Fluent API:** Cleanly defines database constraints and relationships (One-to-Many).
4.  **Generic Repository Overloading:** Added support for `.Include()` expressions to fetch related data (e.g., Approvals) dynamically.



---

## ⚙️ Setup & Installation

1.  **Clone the Repository:**
    ```bash
    git clone (https://github.com/MohamedHussine/NetTask8.git)
    ```

2.  **Configure Connection String:**
    Update `DefaultConnection` in `appsettings.json` within the **Task.NET** project.

3.  **Run Migrations:**
    Execute the following in the Package Manager Console:
    ```powershell
    Update-Database -Project DataAccess -StartupProject Task.NET
    ```

4.  **Run Application:**
    ```bash
    dotnet run --project Task.NET
    ```

---

## 📡 API Endpoints

### 📄 File Metadata
* `GET /api/FileMetadata/{id}` - Fetch document details with approval history.
* `POST /api/FileMetadata/{id}/approve` - Process a sequential approval step.

### 🔐 Authentication
* `POST /api/Account/Login` - Obtain a JWT Token for authorized requests.



---

## 📄 License
This project was developed as a technical assessment for a .NET Developer role.
