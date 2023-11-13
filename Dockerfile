FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleTaskAPI/SimpleTaskAPI.csproj", "SimpleTaskAPI/"]
RUN dotnet restore "SimpleTaskAPI/SimpleTaskAPI.csproj"
COPY . .
WORKDIR "/src/SimpleTaskAPI"
RUN dotnet build "SimpleTaskAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleTaskAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleTaskAPI.dll"]