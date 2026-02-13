# Salary Manager
Salary Manager
## Overview

This project is a Salary Manager written in C#. It processes employee data and calculates the total earnings for each employee based on their working hours.

## How to Run

1. Clone the repository
2. Navigate to the project directory
3. Run the command `dotnet Program.cs` followed by the path to your employee data file. For example: `dotnet run Program.cs  data/employee_data.txt`

## Employee Data File Format

The employee data file should be a text file where each line represents an employee's work schedule. The format of each line should be as follows:

`EMPLOYEE_NAME=DAYHH:MM-HH:MM,DAYHH:MM-HH:MM,...`

Where:
- `EMPLOYEE_NAME` is the name of the employee
- `DAY` is a two-letter representation of the day of the week (MO, TU, WE, TH, FR, SA, SU)
- `HH:MM-HH:MM` represents the start and end time of the employee's work hours for that day
