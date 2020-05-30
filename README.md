# Foodopedia

Gateway API to fetch food/recipes from Open Food API.

## Requirements

* .NET Core SDK 3.1.300
* Microsoft SQL Server 2019 - Developer Edition
* Docker (For container image management)

## Setup

### Work directory

Make sure that your work directory is the `src` folder and not the root folder.

If it is not, navigate to the `src` folder and use it as the work directory in your command line.


### Environment

Set your .NET Core environment to Development by setting the Enviroement Variable `ASPNETCORE_ENVIRONMENT` to `Development`.

### Dependencies restore

Restore all packages with:

```
dotnet restore
```

### Application run

To run the application just run the following command:

```
dotnet run -p ./Foodopedia.Api/Foodopedia.Api.csproj
```

You can access the application on one of the following URLs::

```
http://localhost:5000
https://localhost:5001
```

## The project

The solution is a multi-layer API designed in 4 projects.
The main point behind this approach is that we can provide a better separation of concerns and to decouple one project from another.

### Foodopedia.Api

This is our API entry point.

### Foodopedia.Service

This is our business logic layer.

### Foodopedia.Core

This is our application’s foundation, it will hold our contracts (interfaces, …), our models and everything else that is essential for our application to work.

### Foodopedia.OpenFoodApi

This is where our connection to Open Food API will be held.