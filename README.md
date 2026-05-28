# Rent-a-Car Service

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-SQLite-512BD4)
![SQLite](https://img.shields.io/badge/SQLite-MeurentDb.db-003B57?logo=sqlite&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-2EA44F)

Rent-a-Car Service is an ASP.NET Core MVC web application for browsing cars
and making rental reservations online.

The application provides a public storefront where customers can explore the
available fleet, view car details, and create reservations with pickup and
return dates. An admin panel allows managing cars, customers, reservations,
and viewing revenue data.

## Visual Overview

![Rent-a-Car Service workflow](assets/diagrams/rent-a-car-workflow.jpg)

## About

This project focuses on a simple rental question: which cars are available,
and how can a customer reserve one?

Instead of showing raw database records, it turns the fleet and reservation
data into a clean interface with:

- Featured car listings on the homepage
- Detailed car pages with image galleries
- Reservation form with date and location selection
- Reservation confirmation summary
- Admin dashboard with fleet, customer, and revenue overview
- Session-based admin authentication

## How It Works

1. `Program.cs` configures the SQLite database, session middleware, and seeds
   the initial fleet and province data.
2. `HomeController` displays featured cars and a search form on the homepage.
3. `CarsController` lists all available cars and shows detailed car pages with
   image galleries.
4. `ReservationsController` handles reservation creation with date validation
   and automatic customer registration.
5. `AdminController` provides a dashboard with fleet management, customer
   listing, reservation status updates, and revenue tracking.
6. `AccountController` manages admin login and logout through session-based
   authentication.
7. `SampleDataService` acts as the data access layer between controllers and
   the Entity Framework Core `ApplicationDbContext`.

## Features

- Car fleet browsing with details and images
- Online reservation with pickup and return date selection
- Automatic customer creation on reservation
- Province-based pickup location selection
- Admin dashboard with revenue and reservation overview
- Fleet management (add, edit, delete cars)
- Reservation status management (pending, confirmed, completed, cancelled)
- Session-based admin authentication
- SQLite database with Entity Framework Core migrations
- Automatic database migration and seed data on startup

## Preview

<p align="center">
  <img src="assets/previews/rent-a-car-homepage.png" alt="Rent-a-Car Service homepage" width="600">
</p>

## Getting Started

### Prerequisites

- .NET 10 SDK
- A web browser

### Installation

Clone the repository and open the project directory:

```bash
git clone https://github.com/clssadik/rent-a-car-service.git
cd rent-a-car-service
```

Restore dependencies:

```bash
dotnet restore
```

## Configuration

The application uses a SQLite database configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=MeurentDb.db"
  }
}
```

The database is created and migrated automatically on startup. Sample cars and
Turkish provinces are seeded if they do not already exist.

The default admin credentials are configured in `AccountController`:

- **Email:** `admin@meurent.com`
- **Password:** `123456`

## Run

Run the application from the project root:

```bash
dotnet run
```

When the application starts, it applies pending migrations, seeds sample data,
and opens the website at the configured URL.

## Project Structure

```text
.
|-- Controllers/
|   |-- HomeController.cs          # Homepage and about page
|   |-- CarsController.cs          # Car listing, details, and reviews
|   |-- ReservationsController.cs  # Reservation creation and confirmation
|   |-- AdminController.cs         # Admin dashboard and fleet management
|   `-- AccountController.cs       # Admin login and logout
|-- Data/
|   `-- ApplicationDbContext.cs    # EF Core DbContext with model configuration
|-- Models/
|   |-- Car.cs                     # Car entity
|   |-- Customer.cs                # Customer entity
|   |-- Reservation.cs             # Reservation entity
|   |-- Revenue.cs                 # Revenue tracking entity
|   `-- Province.cs                # Turkish province entity
|-- Services/
|   `-- SampleDataService.cs       # Data access layer for all entities
|-- ViewModels/
|   |-- AdminCarFormViewModel.cs
|   |-- AdminCarsViewModel.cs
|   |-- AdminCustomersViewModel.cs
|   |-- AdminDashboardViewModel.cs
|   |-- AdminReservationsViewModel.cs
|   |-- CarsIndexViewModel.cs
|   |-- LoginViewModel.cs
|   |-- ReservationCreateViewModel.cs
|   |-- ReservationSuccessViewModel.cs
|   `-- ReservationSummaryViewModel.cs
|-- Views/
|   |-- Home/                      # Homepage and about views
|   |-- Cars/                      # Car listing and detail views
|   |-- Reservations/              # Reservation form and success views
|   |-- Admin/                     # Admin panel views
|   |-- Account/                   # Login view
|   `-- Shared/                    # Layout and partial views
|-- wwwroot/
|   |-- css/                       # Stylesheets
|   `-- images/                    # Static images and car photos
|-- Program.cs                     # Application entry point and configuration
|-- appsettings.json               # Database connection string
|-- rent-a-car-service.csproj      # Project file and package references
`-- README.md
```

## License

This project is licensed under the MIT License. See `LICENSE` for details.
