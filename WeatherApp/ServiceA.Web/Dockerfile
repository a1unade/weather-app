FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceA.Web/ServiceA.Web.csproj", "ServiceA.Web/"]
COPY ["Messaging.Kafka/Messaging.Kafka.csproj", "Messaging.Kafka/"]
RUN dotnet restore "ServiceA.Web/ServiceA.Web.csproj"
COPY . .
WORKDIR "/src/ServiceA.Web"
RUN dotnet build "ServiceA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceA.Web.dll"]
