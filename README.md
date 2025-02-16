# Full-Stack Seller Report Application

## Project Overview

This project implements a full-stack solution that displays a report of the top-performing sellers by month. Users can filter the report by branch. The frontend is built using Angular, and it interacts with a .NET Core backend to read data from a provided CSV file.

## Technologies Used

- **Frontend**: Angular (TypeScript)
- **Backend**: .NET 8 (C#)
- **Data Source**: CSV (orders.csv)

## Features

- Display top-performing sellers by month.
- Filter results by branch.
- Responsive design for a better user experience.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (with npm)
- Angular CLI (Install globally using `npm install -g @angular/cli`)

### Setting Up the Backend

1. Navigate to the backend directory:
   ```bash
   cd backend

2. Run the backend API:
    dotnet run

### Setting Up the Frontend

- Navigate to the frontend directory: frontend
- Install dependencies: npm install
- Run the Angular application: ng serve
- The frontend will be available at http://localhost:4200.

### Usage

- Open your browser and navigate to http://localhost:4200.
- Select a branch from the dropdown menu.
- The table will display the top-performing sellers for each month.