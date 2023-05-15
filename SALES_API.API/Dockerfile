#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SALES_API.API/SALES_API.API.csproj", "SALES_API.API/"]
RUN dotnet restore "SALES_API.API/SALES_API.API.csproj"
COPY . .
WORKDIR "/src/SALES_API.API"
RUN dotnet build "SALES_API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SALES_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SALES_API.API.dll"]