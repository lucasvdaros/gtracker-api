# What is GTracker?
It's an open source project, written in .NET 5.0
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
* ASP.NET Core 5.0 (with .NET Core 5.0)
* Entity Framework Core 5.0.7
* FluentValidation 10.2.3
* Swagger UI 6.1.4
* MediatR 9.0.0
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