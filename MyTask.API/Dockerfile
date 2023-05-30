FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyTask.API/MyTask.API.csproj", "MyTask.API/"]
RUN dotnet restore "MyTask.API/MyTask.API.csproj"
COPY . .
WORKDIR "/src/MyTask.API"
RUN dotnet build "MyTask.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTask.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTask.API.dll"]
