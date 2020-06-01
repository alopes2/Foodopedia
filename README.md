# Foodopedia [![Build Status](https://travis-ci.com/alopes2/Foodopedia.svg?token=Ez5vcDho5XVCHGCQaAoh&branch=master)](https://travis-ci.com/alopes2/Foodopedia) [![codecov](https://codecov.io/gh/alopes2/Foodopedia/branch/master/graph/badge.svg?token=KJ80GLW8IS)](https://codecov.io/gh/alopes2/Foodopedia)

Gateway API to fetch food/recipes from Open Food API.

## Requirements

* .NET Core SDK 3.1.300
* Docker (For container image management and application running)

## Setup

### Work directory

Make sure that your work directory is the `src` folder and not the root folder.

If it is not, navigate to the `src` folder and use it as the work directory in your command line.


### Environment

Set your .NET Core environment to Development by setting the Enviroement Variable `ASPNETCORE_ENVIRONMENT` to `Development`.

### Application run

To run the application, please have `docker` installed.

Now you can just run:

```
docker-compose up
```

This will automatically build and run our application in a docker container.

You can access the application from:

```
http://localhost:5000
```

This routes the local port `5000` to the port `80` inside the docker container.

### Application standalone run

Restore all packages with:

```
dotnet restore
```

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

### Foodopedia.OpenFoodFacts

This is where our connection to Open Food Facts API will be held.

### Foodopedia.UnitTests

Here are the **Unit Tests** for our projects. To run them just go to the `src` folder and run:

`dotnet test`

It is also set to generate a code coverage file with `coverlet` . To generate a coverage file just run:

`dotnet test ./src/Foodopedia.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover`

This will generate a `coverage.opencover.xml` file in the `Foodopedia.UnitTests` project folder.