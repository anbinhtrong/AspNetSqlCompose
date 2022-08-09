FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY DockerizeMultiProject/*.csproj ./DockerizeMultiProject/
COPY DockerizeMultiProject.Domain/*.csproj ./DockerizeMultiProject.Domain/
COPY DockerizeMultiProject.Infrastructure/*.csproj ./DockerizeMultiProject.Infrastructure/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY DockerizeMultiProject/. ./DockerizeMultiProject/
COPY DockerizeMultiProject.Domain/. ./DockerizeMultiProject.Domain/
COPY DockerizeMultiProject.Infrastructure/. ./DockerizeMultiProject.Infrastructure/ 
#
WORKDIR /app/DockerizeMultiProject
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app 
#
COPY --from=build-env /app/DockerizeMultiProject/out .
ENTRYPOINT ["dotnet", "DockerizeMultiProject.dll"]