# Clean Architecture with CQRS and react js and TypeScript 

# Migration
#### run these commands in api project <br/>
1)dotnet ef migrations add init  -c AppDbContext <br/>
2)dotnet ef database update -c AppDbContext <br/>
3)dotnet ef migrations add initIdentity  -c AppIdentityDbContext <br/>
4)dotnet ef database update -c AppIdentityDbContext <br/>

# Database 
in identity migration a user generate with this username and password <br/>
username : admin <br/>
password : Abcd@1234 <br/>


# Run project
1) for backend project you can go to api project and run this  command : <br/> dotnet run
   dotnet run <br/>
2) for ui project you can run these two command in your terminal <br/>
   a) cd src/UI/client-app  <br/>
   b) npm start <br/>
3) you can login with admin user in database section


# Docker build
run this command : docker build . -t api -f .\src\API\Api\Dockerfile