# ---------- Stage 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj file(s) first for better layer caching
COPY EMPAPI/*.csproj ./EMPAPI/
COPY EMPBAL/*.csproj ./EMPBAL/
COPY EMPDAL/*.csproj ./EMPDAL/
COPY EMPMAL/*.csproj ./EMPMAL/
RUN dotnet restore ./EMPAPI/EMPAPI.csproj

# Copy the rest of the source code
COPY . .

# Build and publish the app
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- Stage 2: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published output from the build stage
COPY --from=build /app/publish .

# Expose the port your app listens on
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

# Set the entrypoint (replace with your actual DLL name)
ENTRYPOINT ["dotnet", "EMPAPI.dll"]