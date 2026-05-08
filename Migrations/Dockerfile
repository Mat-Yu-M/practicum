FROM mcr.microsoft.com/dotnet/sdk:9.0 AS publish
WORKDIR /src

COPY "Migrations/Migrations.csproj" "./Migrations/"
COPY "PracticumProject.Api/PracticumProject.Api.csproj" "./PracticumProject.Api/"

RUN dotnet restore "./Migrations/Migrations.csproj"

COPY "Migrations/" "./Migrations/"
COPY "PracticumProject.Api/" "./PracticumProject.Api/"

RUN dotnet publish "./Migrations/Migrations.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Migrations.dll"]