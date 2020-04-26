# MS-Learn-Scoreboard
An API to track users' Microsoft Learn Experience Point

## Build:
* Open sln in Visual Studio 2019 with Web Development installed

* Peform NuGet Restore

* Build and run with IIS Express

## To update database table structure:
```
cd MS-Learn-Scoreboard
del Scoreboard.db
dotnet ef migrations remove
Make the modification to the Data Models in Visual Studio
dotnet ef migrations add BlankDB
dotnet ef database update
```
