FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceB.Web/ServiceB.Web.csproj", "ServiceB.Web/"]
COPY ["WeatherApp.Contracts/WeatherApp.Contracts.csproj", "WeatherApp.Contracts/"]
RUN dotnet restore "ServiceB.Web/ServiceB.Web.csproj"
COPY . .
WORKDIR "/src/ServiceB.Web"
RUN dotnet build "ServiceB.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceB.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceB.Web.dll"]
