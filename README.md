# Project GecGo.
back end with .NET


## How To Run
-   apis
       -   Database use mySql.
                Install one of the following tools that supports mySQL:  laragon, xampp,....
                Set up and run mySql.
                Database already seeded in by code first method.
                
       -   Setup backend database
            ```
            $ Adjust the appsetting.json file with your SQL Server account
            $ create and update database: 
                    - with Visual Studio Code: open terminal and run command: 
                            "cd apis" 
                            "dotnet ef database update"
                    - with Visual Studio: Open Nuget console and run the command: 
                            "update-database"              
            $ Wait for database is created and updated
            $ After finishing,  - with Visual Studio Code: open terminal and run command: "dotnet run"
                                - with Visual Studio: Start the ASP.NET server
            $ Delete database: 
                    - with Visual Studio Code: open terminal and run command:  
                            "dotnet ef database drop"
                    - with Visual Studio: Open Nuget console and run the command: 
                            "drop-database" 
            ``` 


## Techs:
       -   mySql
       -   ASP.NET - A server-side web-application framework designed for web development to produce dynamic web pages.