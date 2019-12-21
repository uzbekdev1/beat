Price beating project
-------------------------------------
Project list:  
    
    1. UzExTaskAPI - project API, based on dotnet core framework
    2. UzExTaskBeater - beater simulator, dotnet console application
    3. UzExTaskWeb - front end interface for real user, created on ReactJS

Database:
    
    MongoDB is used to develope this project. In appsettings.json of UzExTaskAPI must be included MongoDB database connection settings:
    
    "MongoDBConnection": {
        "CollectionName": "uzexbeat",
        "ConnectionString": "mongodb://localhost:27017",
        "DatabaseName": "UzExBeatDB"
    }

Required tools:
    
    UzExTaskAPI
        DotNetCore 3.0.1
        MongoDB.Driver 2.10.0
    
    UzExTaskWeb       
        ReactJS 16.12.0 
        > npm install jquery
        > npm install datatables.net

Using project:
    
    1. UzExTaskAPI - start debugging
        > cd /path/to/UzExTaskAPI
        > dotnet run
    
    2. UzExTaskBeater - to create simulated user, you must locate inside of project folder, run console application in console, and give a name to virtual user.  
        > cd /path/to/UzExTaskBeater 
        > dotnet run        
        Insert your name: Xxxx

    3. UzExTaskWeb - run react project
        > npm start