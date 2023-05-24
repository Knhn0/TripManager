FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TripManager/TripManager.csproj", "TripManager/"]
RUN dotnet restore "TripManager/TripManager.csproj"
COPY . .
WORKDIR "/src/TripManager"
RUN dotnet build "TripManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TripManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TripManager.dll"]
