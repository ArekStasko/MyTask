FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyTask.IdP/MyTask.IdP.csproj", "MyTask.IdP/"]
RUN dotnet restore "MyTask.IdP/MyTask.IdP.csproj"
COPY . .
WORKDIR "/src/MyTask.IdP"
RUN dotnet build "MyTask.IdP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTask.IdP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTask.IdP.dll"]
