FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/API/Api/Api.csproj", "Api/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/Api"
RUN dotnet build "API/Api/Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API/Api/Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
