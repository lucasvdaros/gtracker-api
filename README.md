# What is GTracker?
It's an open source project, written in .NET Core, currently in version 3.1.
The project's goals is to organize eletronic games and manage its loans to friends and others.

## How to use:
### Requisits
* Docker installed (click [here](https://docs.docker.com/get-docker/) to see how to install)
* Docker compose (click [here](https://docs.docker.com/compose/install/) to see how to install)
### How to run
1. Clone this project into your machine
2. Run `docker-compose up -d`
3. Go to `http://localhost:5000` to access the application
4. Run `docker-compose down --rmi all` to stop the application and erase the generated images

### Credentials to test
1. login: admin
2. password: senhalegal

## Technologies implemented:
* ASP.NET Core 3.1 (with .NET Core 3.1)
* Entity Framework Core 3.1.5
* FluentValidation 9.0.0
* Swagger UI 5.5.0
* MediatR 8.1.0
* MySql Database Connection

## Architecture:
* CQRS Layer architecture
* S.O.L.I.D. principles
* Clean Code
* Native DI
* Domain Validations
* Domain Notifications
* Domain Driven Design
* Repository Pattern
* Notification Pattern
* Mapper by Extension Methods