FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceC.Web/ServiceC.Web.csproj", "ServiceC.Web/"]
COPY ["ServiceB.Web/ServiceB.Web.csproj", "ServiceB.Web/"]
COPY ["WeatherApp.Contracts/WeatherApp.Contracts.csproj", "WeatherApp.Contracts/"]
RUN dotnet restore "ServiceC.Web/ServiceC.Web.csproj"
COPY . .
WORKDIR "/src/ServiceC.Web"
RUN dotnet build "ServiceC.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceC.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceC.Web.dll"]
