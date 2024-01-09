#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Web_shop/Web_shop.csproj", "Src/Web_shop/"]
COPY ["Src/Infrastructure/Infrastructure.csproj", "Src/Infrastructure/"]
COPY ["Src/Application/Application.csproj", "Src/Application/"]
COPY ["Src/Domain/Domain.csproj", "Src/Domain/"]
RUN dotnet restore "./Src/Web_shop/Web_shop.csproj"
COPY . .
WORKDIR "/src/Src/Web_shop"
RUN dotnet build "./Web_shop.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web_shop.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_shop.dll"]