# Energy App

A Blazor application for exploring and analyzing electricity prices using data from the Energy-Charts API.

The project is built as a learning and portfolio project with a focus on full-stack development, API integration, data visualization, and eventually data analytics.

## Current Features

- Integration with the Energy-Charts API
- Fetch day-ahead electricity prices by bidding zone and date range
- Models for electricity price data
- Configured typed `HttpClient` for the Energy-Charts API

## Tech Stack

- C#
- .NET / Blazor
- ASP.NET Core
- Energy-Charts API

## Project Structure

The application follows a feature-based structure:

    Features/
    └── EnergyCharts/
        ├── Models/
        │   ├── ElectricityPrice.cs
        │   └── EnergyPricePoint.cs
        └── Services/
            └── EnergyChartService.cs

## Roadmap

The next steps for the project include:

- Display electricity price data in the Blazor UI
- Add price charts and key statistics
- Compare bidding zones such as DK1 and DK2
- Add historical price analysis
- Persist historical data
- Explore forecasting and other data science features

## Data Source

Electricity market data is provided by the Energy-Charts API from Fraunhofer ISE.