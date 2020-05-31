FROM mcr.microsoft.com/dotnet/core/sdk:3.1.300-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Foodopedia.Api/*.csproj ./Foodopedia.Api/
COPY Foodopedia.Core/*.csproj ./Foodopedia.Core/
COPY Foodopedia.Services/*.csproj ./Foodopedia.Services/
COPY Foodopedia.OpenFoodFacts/*.csproj ./Foodopedia.OpenFoodFacts/
COPY *.sln ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN ls
RUN dotnet build -c Release -o build
RUN dotnet publish ./Foodopedia.Api/Foodopedia.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Foodopedia.Api.dll"]