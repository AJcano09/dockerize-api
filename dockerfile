FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY Netcore.dockerize.API.csproj .
RUN dotnet restore Netcore.dockerize.API.csproj
COPY . .

RUN dotnet build "Netcore.dockerize.API.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
COPY --from=build /app/build ./
ENTRYPOINT ["dotnet", "Netcore.dockerize.API.dll"]