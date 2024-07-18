# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
VOLUME /app/Files

# Set environment variables
ENV ConnectionStrings__SQLiteConnection=Data Source="/app/Files/MMS.db"
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

# Ensure the app user can access the database file
RUN mkdir -p /app/Files && chown -R app:app /app/Files

# Switch to the app user
USER app

# SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore project
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "./Api/Api.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/Api"

# Build the application
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: create the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ensure necessary permissions
RUN chmod -R 777 /app/Files

# Entry point
ENTRYPOINT ["dotnet", "Api.dll"]
