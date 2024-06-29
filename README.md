# Star Wars Data Retriever
This project is a C# console application that:
  1. Retrieves information from a Star Wars database using an API
  2. Map the data to corresponding C# classes
  3. Save the retrieved data into CSV files for further analysis and use

## Introduction
Welcome to the Star Wars Data Retriever project!
This C# application leverages the Star Wars API [SWAPI](https://swapi.dev/) to fetch comprehensive information about the Star Wars universe.
The application maps this data into structured C# classes and exports it into user-friendly CSV files, making it easy to explore and analyze the vast Star Wars dataset.
Users are also able to view individual records on the console.

## Features
1. API:
  - Retrieve data from all available SWAPI endpoints
  - Supports all key Star Wars data points, including:
    - People,
    - Films,
    - Planets,
    - Species,
    - Starships and
    - Vehicles

2. Model Mapping:
  - Full response from endpoint -> data model -> store in CSV file
  - Single response from endpoint -> data model -> colourful display on console

3. CSV Mapping:
  -  Combining records from each endpoint with a ClassMap

## Install dependencies
The folowing packages are installed from the NuGet Package Manager:
  - CsvHelper
  - Newtonsoft.Json

## Usage
- The application will connect to the SWAPI, retrieve data from various endpoints, map the data to C# objects and save the results as CSV files in the *CSV_Files* directory
