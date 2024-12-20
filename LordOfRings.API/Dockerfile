FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LordOfRings.API/LordOfRings.API.csproj", "LordOfRings.API/"]
COPY ["LordOfRings.App/LordOfRings.App.csproj", "LordOfRings.App/"]
COPY ["LordOfRings.Domain/LordOfRings.Domain.csproj", "LordOfRings.Domain/"]
COPY ["LordOfRings.Infrastructure/LordOfRings.Infrastructure.csproj", "LordOfRings.Infrastructure/"]
RUN dotnet restore "LordOfRings.API/LordOfRings.API.csproj"
COPY . .
WORKDIR "/src/LordOfRings.API"

# Install EF Core tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet build "LordOfRings.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LordOfRings.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LordOfRings.API.dll"]