# Meal Order Collection System

A web-based university cafeteria meal order and pickup tracking application built with **ASP.NET Core MVC**.

Developed as Homework 1 for the **SWE 203: Web Programming** course at Sakarya University. It simulates the workflow of distributing prepared meals to students, allowing them to track collection statuses and collect their orders using unique Order IDs.

---

## Key Features

- **Dashboard / Home View (`Home/Index`):**
  - Displays today's date and the designated cafeteria name dynamically.
  - Real-time counter for the total number of collected meal orders.
  - Lists already collected meal orders in a structured table.
  - Direct navigation links to the full order list and pickup page via the shared navbar.
  - Centralized footer displaying developer details across all pages.

- **Order Catalog (`Order/Index`):**
  - Complete list of all meal orders (both collected and pending).
  - Displays `Order ID`, `Student Name`, `Meal Name`, and `Status` (Picked Up / Not Picked Up).
  - Shows the total count of registered meal orders.
  - Action link for each record navigating to the order details page using ASP.NET Core Tag Helpers.

- **Order Details (`Order/Info/{id}`):**
  - Accepts an order ID via route parameter.
  - Displays detailed meal and student information.
  - Shows the exact collection timestamp or indicates that the meal is pending collection.

- **Meal Pickup (`Pickup/Index`):**
  - Interactive form accepting an `OrderID`.
  - Updates the order status to `Collected = true` and logs the pickup timestamp (`DateTime.Now`).
  - Handles validation feedback for missing or invalid orders.
  - Implements the **Post/Redirect/Get (PRG)** pattern to prevent duplicate form submissions by redirecting directly to the order details page.

---

## Technical Details & Architecture

The application is built following the **Model-View-Controller (MVC)** architectural pattern:

- **Framework:** .NET Core / ASP.NET Core MVC
- **State Management / In-Memory Data:** Static data repository (`Repository.cs`) maintaining pre-seeded meal records.
- **Data Transfer & Model Binding:**
  - `[HttpGet]` and `[HttpPost]` action separation for form handling.
  - Strongly-typed models (`MealOrder.cs`) for view rendering.
  - Dynamic data passing via `ViewBag` (cafeteria name, date, counters, error messages).
  - Route parameter binding (`id`) and Form parameter binding (`orderId`).
- **Tag Helpers & View Engine:**
  - Built-in Tag Helpers (`asp-controller`, `asp-action`, `asp-route-id`) enabled via `_ViewImports.cshtml`.
  - Post/Redirect/Get (PRG) pattern implemented using `RedirectToAction`.
- **Layout System:** Unified layout management with `_Layout.cshtml`, `_ViewStart.cshtml`, and Bootstrap 5.

---

## Project Structure

```text
MealOrderCollection/
├── Controllers/
│   ├── HomeController.cs        # Dashboard metrics & collected orders summary
│   ├── OrderController.cs       # Full orders list and order details (Info)
│   └── PickupController.cs      # Pickup form logic & collection handler
├── Models/
│   ├── MealOrder.cs             # Domain entity (OrderID, StudentName, MealName, etc.)
│   └── Repository.cs            # In-memory data store with seed records
├── Views/
│   ├── Home/
│   │   └── Index.cshtml         # Home dashboard
│   ├── Order/
│   │   ├── Index.cshtml         # All orders overview
│   │   └── Info.cshtml          # Specific order details
│   ├── Pickup/
│   │   └── Index.cshtml         # Meal collection form
│   ├── Shared/
│   │   └── _Layout.cshtml       # Global layout & shared navigation/footer
│   ├── _ViewImports.cshtml      # Tag Helper registration
│   └── _ViewStart.cshtml        # Default layout configuration
├── appsettings.json
├── Program.cs
├── README.md
└── MealOrderCollection.csproj
```
