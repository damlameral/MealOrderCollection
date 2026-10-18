# Meal Order Collection System

A web-based university cafeteria meal order and pickup tracking application built with **ASP.NET Core MVC**.

Developed as Homework 1 for the **SWE 203: Web Programming** course at Sakarya University. It simulates the workflow of distributing prepared meals to students, allowing them to track collection statuses and collect their orders using unique Order IDs.

---

## Key Features

- **Dashboard / Home View (`Home/Index`):**
  - Displays today's date and the designated cafeteria name dynamically.
  - Real-time counter for the total number of collected meal orders.
  - Lists already collected meal orders.
  - Direct navigation links to the full order list and pickup page.
  - Centralized footer displaying developer details across all pages.

- **Order Catalog (`Order/Index`):**
  - Complete list of all meal orders (both collected and pending).
  - Displays `Order ID`, `Student Name`, `Meal Name`, and `Status` (Collected / Not Collected).
  - Shows the total count of registered meal orders.
  - Action link for each record navigating to the order details page.

- **Order Details (`Order/Info/{id}`):**
  - Accepts an order ID via route/parameter.
  - Displays detailed meal and student information.
  - Shows the exact collection timestamp or indicates that the meal is pending collection.

- **Meal Pickup (`Pickup/Index`):**
  - Interactive form accepting an `OrderID`.
  - Updates the order status to `Collected = true` and logs the pickup timestamp (`DateTime.Now`).
  - Handles validation feedback for invalid or previously collected orders.

---

## Technical Details & Architecture

The application is built following the **Model-View-Controller (MVC)** architectural pattern:

- **Framework:** .NET Core / ASP.NET Core MVC
- **State Management / In-Memory Data:** Static data repository (`Repository.cs`) maintaining pre-seeded meal records.
- **Data Transfer & Binding:**
  - `[HttpGet]` and `[HttpPost]` action separation for form handling.
  - Strongly-typed models (`MealOrder.cs`) for view rendering.
  - `ViewBag` / `ViewData` for metadata passing (cafeteria name, date, counters).
- **Layout System:** Unified layout management with `_Layout.cshtml` and `_ViewStart.cshtml`.

---

## Project Structure

```text
MealOrderCollection/
├── Controllers/
│   ├── HomeController.cs       # Dashboard metrics & collected orders summary
│   ├── OrderController.cs      # Full orders list and order details (Info)
│   └── PickupController.cs     # Pickup form and collection action logic
├── Models/
│   ├── MealOrder.cs            # Domain entity (OrderID, StudentName, MealName, etc.)
│   └── Repository.cs           # In-memory data store with seed records
├── Views/
│   ├── Home/
│   │   └── Index.cshtml        # Home dashboard
│   ├── Order/
│   │   ├── Index.cshtml        # All orders overview
│   │   └── Info.cshtml         # Specific order information
│   └── Pickup/
│       └── Index.cshtml        # Meal collection form
├── Shared/
│   ├── _Layout.cshtml          # Global layout & shared navigation/footer
│   └── _ViewStart.cshtml
├── appsettings.json
├── Program.cs
└── MealOrderCollection.csproj
```
