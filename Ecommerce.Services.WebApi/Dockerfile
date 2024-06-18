#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecommerce.Services.WebApi/Ecommerce.Services.WebApi.csproj", "Ecommerce.Services.WebApi/"]
COPY ["Ecommerce.Application.DTO/Ecommerce.Application.DTO.csproj", "Ecommerce.Application.DTO/"]
COPY ["Ecommerce.Application.Interface/Ecommerce.Application.Interface.csproj", "Ecommerce.Application.Interface/"]
COPY ["Ecommerce.Transversal.Common/Ecommerce.Transversal.Common.csproj", "Ecommerce.Transversal.Common/"]
COPY ["Ecommerce.Application.Main/Ecommerce.Application.Main.csproj", "Ecommerce.Application.Main/"]
COPY ["Ecommerce.Domain.Entity/Ecommerce.Domain.Entity.csproj", "Ecommerce.Domain.Entity/"]
COPY ["Ecommerce.Domain.Interface/Ecommerce.Domain.Interface.csproj", "Ecommerce.Domain.Interface/"]
COPY ["Ecommerce.Domain.Core/Ecommerce.Domain.Core.csproj", "Ecommerce.Domain.Core/"]
COPY ["Ecommerce.Infraestructure.Interface/Ecommerce.Infraestructure.Interface.csproj", "Ecommerce.Infraestructure.Interface/"]
COPY ["Ecommerce.Infraestructure.Data/Ecommerce.Infraestructure.Data.csproj", "Ecommerce.Infraestructure.Data/"]
COPY ["Ecommerce.Infraestructure.Repository/Ecommerce.Infraestructure.Repository.csproj", "Ecommerce.Infraestructure.Repository/"]
COPY ["Ecommerce.Transversal.Logging/Ecommerce.Transversal.Logging.csproj", "Ecommerce.Transversal.Logging/"]
COPY ["Ecommerce.Transversal.Mapper/Ecommerce.Transversal.Mapper.csproj", "Ecommerce.Transversal.Mapper/"]
RUN dotnet restore "./Ecommerce.Services.WebApi/Ecommerce.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Services.WebApi"
RUN dotnet build "./Ecommerce.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecommerce.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Services.WebApi.dll"]