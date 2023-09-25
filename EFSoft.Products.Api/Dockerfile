#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.11-alpine3.18-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0.11-alpine3.18-amd64 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["EFSoft.Products.Api/EFSoft.Products.Api.csproj", "EFSoft.Products.Api/"]
COPY ["EFSoft.Products.Application/EFSoft.Products.Application.csproj", "EFSoft.Products.Application/"]
COPY ["EFSoft.Products.Domain/EFSoft.Products.Domain.csproj", "EFSoft.Products.Domain/"]
COPY ["EFSoft.Products.Infrastructure/EFSoft.Products.Infrastructure.csproj", "EFSoft.Products.Infrastructure/"]
RUN dotnet restore "EFSoft.Products.Api/EFSoft.Products.Api.csproj"
COPY . .
WORKDIR "/src/EFSoft.Products.Api"
RUN dotnet build "EFSoft.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Products.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Products.Api.dll"]
