Steps for installing app:
1.Download application
2.Make sure you have installed all dependencies like Entity Framework 3.1, JWTToken
3.The app should run with localhost:4000. Go to Debug -> properties -> debug -> App URL and should be without SSL
4.In appsettings you should set connection string with database 
5.In Package Manager Console you should run add-migration and update-database.