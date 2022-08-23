ARG VERSION=6.0-alpine
# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env
WORKDIR /app

#Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

#Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
WORKDIR /app
COPY --from=build-env /app/out .
CMD ["dotnet", "ContosoUniversity.dll"]