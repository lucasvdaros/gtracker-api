FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
COPY *.sln .
COPY src/GTracker.Application/*.csproj ./src/GTracker.Application/
COPY src/GTracker.Domain/*.csproj ./src/GTracker.Domain/
COPY src/GTracker.Domain.Core/*.csproj ./src/GTracker.Domain.Core/
COPY src/GTracker.Infra.CrossCutting.Bus/*.csproj ./src/GTracker.Infra.CrossCutting.Bus/
COPY src/GTracker.Infra.CrossCutting.IoC/*.csproj ./src/GTracker.Infra.CrossCutting.IoC/
COPY src/GTracker.Infra.Data/*.csproj ./src/GTracker.Infra.Data/
COPY src/GTracker.Service/*.csproj ./src/GTracker.Service/
COPY test/GTracker.Test.Integration/*.csproj ./test/GTracker.Test.Integration/
COPY test/GTracker.Test.Unit/*.csproj ./test/GTracker.Test.Unit/
RUN dotnet restore
COPY src/. ./src/
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "GTracker.Application.dll"]