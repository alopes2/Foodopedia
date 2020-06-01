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

The solution is a multi-layer API designed in 5 projects.
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

## Features

### Swashbuckle (Swagger)

Swagger was added to present a nice UI for interacting with the API and add documentation.

### Logging

Logging was implemented using Serilog package.

It was configured to log to the console and to log to a file.
File location can be configured by changing the *FilePath* property in the *Serilog* section of the appsettings.json.

Default is set to */var/Foodopedia/Logs/log.log*, which is translated to *C:\var\Foodopedia\Logs\log.log* on Windows OS.

### Global Exception Handling

A middleware was set to globally handle any exception that is thrown inside the application.
It's purpose is to log the exception using our logging implementation and return a formatted response to the user.

### Metrics

Metrics were implemented using *Prometheus-net* package.

The default metrics and Http metrics were set in `Startup.cs` .
Also a custom metrics was set for counting the number of Exceptions thrown in the application. It was set through the `MetricsService.cs` for setting a Prometheus counter and applied in a Metrics Middleware using `MetricsMiddleware.cs`.

Note that if more metrics are required, you just need to add a property to `MetricsService.cs` and initialize it in there with Prometheus-net.

You can check metrics by going to `/metrics` URL (like: `http://localhost:5000/metrics`).

### Object Mapping

Mappings between Domain and Resource models is done using AutoMapper package.

Mapping profile is defined in the `Mappings` folder in `MappingProfile.cs`.

### Throttling / Rate Limit

Rate Limit is applied to prevent more than 3 request every 3 seconds.

### Docker

A Dockerfile was written to allow the build of docker production image.

### Unit Tests

A few unit tests were implemented.

Also it is able to generate a code coverage reports by running the following code in the solution folder:

```
dotnet test ./src/Foodopedia.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

This will generate a opencover report in the Foodopedia.UnitTests folder.

### Continuous Integration Pipeline

A continuous integration pipeline was set using [Travis CI](https://travis-ci.com/) .
It is set to build and tests the application.
It generates and pushes a docker production image to docker hub.
It also generates and push our code coverage to [Codecov](https://codecov.io/) .

You can check pipeline and code coverage status through the **badges** in this README file.

## Dependencies

* [.NET Core SDK 3.1.300](https://dotnet.microsoft.com/download/dotnet-core/3.1) - C# Backend Framework
* [Prometheus-net 3.5.0](https://github.com/prometheus-net/prometheus-net) - Metrics package
* [Swashbuckle 5.4.1](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - ASPNET.Core API documentation
* [AutoMapper 9.0.0](https://github.com/AutoMapper/AutoMapper) - Mapping package
* [Coverlet](https://github.com/tonerdo/coverlet) - Code coverage generation package - **coverlet.msbuild** and **coverlet.collector** are the depencies packages needed
* [AspNetCoreRateLimit 3.0.5](https://github.com/stefanprodan/AspNetCoreRateLimit) - Rate Limit package