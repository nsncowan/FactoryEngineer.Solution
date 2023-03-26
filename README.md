# Eau Claire's Salon

#### MVC web application for a hair salon - manage stylists and clients!

## Authored by: 

Noah Cowan, March 2023

***

## Description:

This is an MVC web application writted in C#, using the ASP.NET core framework. The app uses Entity Framework Core migrations to build a SQL database. Upon launching the app, a browser window will open to a splash page where a user can follow links to create engineers and machines to populate a factory management app. Using a many-to-many database relationship, the user can assign engineers to any number of machines to maintain, and conversly, assign machines to be maintained by any number of engineers. Engineers and Machines can also be created and deleted. 
***

## Technologies Used

- C#
- .NET
- ASP.NET Core
- Entity Framework Core
- Razor
- MySQL Workbench
- Git
- Github
- Markdown
***

## Setup/Installation Requirements

### Installation Steps
1. Install a compatible version of .NET 6. An installation link can be found [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
2. In the terminal, install dotnet-script by runing the following command
```bash
$ dotnet tool install -g dotnet-script
```
3. Configure your local environment to use this. Instructions [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-dotnet-script).
4. Then, install MySQL. Instructions [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).

### Repository Setup
1. Clone this repository.
2. Open your terminal and navigate to this project's production directory called "Factory".
3. Within the Factory directory, create a file titled appsettings.json
4. Open your file editor and navigate to appsettings.json
5. In the appsettings.json file, paste the following code:
```javascript
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=noah_cowan;uid=[uid];pwd=[pwd];"
  }
}
```
6. Replace [uid] and [pwd] with your created SQL username and password respectively (excluding the braces).

### Create the Database with Entity Framework Migrations
1. Open your terminal to your local root directory and install ef migrations: 
  run: "dotnet tool install --global dotnet-ef --version 6.0.0"
2. In the project directory, run the following command to install Entity Framework Core Design:
  "dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0"
3. When you're you're ready to create the database, run the following two commands in the project directory:
  "dotnet ef migrations add initial"
  "dotnet ef database update"

### Execute the Program
1. Open the terminal and navigate to the production direction titled Factory.
2. Run `dotnet watch run` in the command line.

## Known Bugs
None
***

## License

_MIT License

Copyright (c) [2023] [Noah Cowan]

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._