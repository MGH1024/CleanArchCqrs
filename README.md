# CleanArchCqrs


PS C:\Projects\CleanArchCqrs\src\Api\api>
 dotnet ef migrations add init  -c AppDbContext
 dotnet ef database update -c AppDbContext
 dotnet ef migrations add initIdentity  -c AppIdentityDbContext
 dotnet ef database update -c AppIdentityDbContext
