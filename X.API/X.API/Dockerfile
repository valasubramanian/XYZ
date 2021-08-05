#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["X.API/X.API.csproj", "X.API/"]
RUN dotnet restore "X.API/X.API.csproj"
COPY . .
WORKDIR "/src/X.API"
RUN dotnet build "X.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "X.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "X.API.dll"]