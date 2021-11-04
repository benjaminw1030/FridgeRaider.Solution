# Fridge Raider

### by Art Weinstein, Benjamin Wilson, Erica Marroquin, Scott Hutley 

### A web application that makes use of a meal API and allows users to access meals as well as ingredients. Users are able to add ingredients to their virtual fridge and compare what they have with what is required in the recipe.

## Technologies Used

* C#
* ASP.NET CORE MVC
* MySql WorkBench
* Entity Framework Core
* HTML
* CSS

## Description

This website pulls recipes and ingredients from TheMealDB API, allowing users to view potential items they would like to cook, and gives them. Users are able to freely navigate through the site, search for recipes and look at the avaiable ingredients, however users must be authenticated to add recipes into their recipe book or ingredients into their fridge. Once the user is logged in, the website will compare what is in the user's virtual fridge and return what more is needed for a specific recipe. Users are able to search for both recipes and ingredients via a search box, or navigate through the site based on recipe categories or the first letter of an ingredient. If all the ingredients are in the user's fridge, the site will let them know they are ready to cook! Each recipe will provide the user with a video link, list of ingredients, what ingredients are stil required (based on what is in the user fridge), instructions on how to cook the meal, and a link to the source. Each recipe view allows the user to add or remove that recipe from the user's recipe book. To add an ingredient, the user simply has to click on an ingredient, which will then be moved to their fridge. To remove an ingredient, the user has the option to either remove it from the ingredient or fridge page. 

## Technology Requirements

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* A text editor like [VS Code](https://code.visualstudio.com/)

## Setup/Installation Requirements

1. Install the [.NET framework](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50).
2. If on MacOS, Install [MySQL Community Server](https://dev.mysql.com/downloads/file/?id=484914) and [MySQL Workbench](https://dev.mysql.com/downloads/file/?id=484391). If on Windows 10 download the [MySQL Web Installer](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi) and follow installation instructions.
3. During installation, note the password used for your server.
4. [Clone](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository-from-github/cloning-a-repository) this repository from GitHub to your local machine.
5. Open the new directory.
6. Create a new file called "appsettings.json" in the FridgeRaider directory.
7. Copy the following code into this file (noting where to insert your password):
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=fridge_raider;uid=root;pwd=epicodus;"
  }
}
```
8. Create a new file called "EnvironmentVariables.cs" in the FridgeRaider/Models directory.
9. Copy the following code into this file (API key approved for public usage):
```
namespace FridgeRaider.Models
{
  public static class EnvironmentVariables
  {
    public static string ApiKey = "9973533";
  }
}
```
8. Open a new terminal instance in the FridgeRaider.Solution/FridgeRaider directory.
10. Open MySQL Workbench and connect to localhost:3306 at root.
11. Type "dotnet build" in the terminal to create the file structure and install packages.
12. Apply the included Migration file by typing "dotnet ef database update"
14. To view, type "dotnet watch run" in the terminal and navigate to http://localhost:5000 or https://localhost:5001 in any web browser.

## Known Bugs

* No bugs known at the moment.

## License

* [MIT License](https://opensource.org/licenses/MIT)

Copyright (c) 2021 Art Weinstein, Benjamin Wilson, Erica Marroquin, Scott Hutley 

## Contact Information

[Art Weinstein - Email](artur.weintsein@gmail.com)

[Ben Wilson - Email](benjaminw1030@gmail.com)

[Erica Marroquin - Email](ericamarroquin03@gmail.com)

[Scott Hutley - Email](scotthutley1@comcast.net)