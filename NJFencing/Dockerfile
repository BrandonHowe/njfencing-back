FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NJFencing/NJFencing.csproj", "NJFencing/"]
RUN dotnet restore "NJFencing/NJFencing.csproj"
COPY . .
WORKDIR "/src/NJFencing"
RUN dotnet build "NJFencing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NJFencing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NJFencing.dll"]
