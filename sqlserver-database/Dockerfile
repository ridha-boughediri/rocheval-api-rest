# Use the .NET SDK image to build the project files.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy the C# project file and restore dependencies.
COPY ["Api-rest-eau.csproj", "./"]
RUN dotnet restore "Api-rest-eau.csproj"

# Copy the rest of the application's source code and build the project.
COPY . ./
RUN dotnet publish -c Release -o out

# Use the .NET runtime image to run the application.
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Api-rest-eau.dll"]
