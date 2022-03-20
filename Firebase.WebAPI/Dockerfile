#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Firebase.WebAPI/Firebase.WebAPI.csproj", "Firebase.WebAPI/"]
COPY ["./FirebaseFCM.Standard/FirebaseFCM.Standard.csproj", "FirebaseFCM.Standard/"]
RUN dotnet restore "Firebase.WebAPI/Firebase.WebAPI.csproj"
COPY . .
WORKDIR "/src/Firebase.WebAPI"
RUN dotnet build "Firebase.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Firebase.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Firebase.WebAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HerokuApp.dll