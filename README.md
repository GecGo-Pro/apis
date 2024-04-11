

# Project GecGo-Pro [BE]
If you found this project useful, then please consider giving it a ⭐ on Github and follow me on GitHub.


## How To Run
-   Backend ()
       -   Installation Laragon (xammpp,..)
            ```
            Install mySql
            Create a account and let SQL Server run as service of Windows
            Database already seeded in by code first method or you can download database in document folder
            ```
       -   Setup backend database
            ```
            $ Adjust the appsetting.json file with your SQL Server account
            $ Visual Studio: Open Nuget console and run the command: "update-database"
            $ Visual Studio Code: Open Terminal and run the command: "dotnet ef database update" 
            $ Wait for database is created and updated
            $ After finishing, Start the ASP.NET server
            $ With Visual Studio Code -> terminal -> "dotnet run"

            $ Enviroment Dev: Folder  Properties
                                        -> launchSettings.json
                                            -> "ASPNETCORE_ENVIRONMENT": "Development"

            $ Enviroment Pro: Folder  Properties
                                        -> launchSettings.json
                                                -> "ASPNETCORE_ENVIRONMENT": "Production"

       
## Techs:
       -   mySql. 
       -   ASP.NET - A server-side web-application framework designed for web development to produce dynamic web pages.
