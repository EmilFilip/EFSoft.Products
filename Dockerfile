#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh

COPY ["EFSoft.Products.Api/EFSoft.Products.Api.csproj", "EFSoft.Products.Api/"]
COPY ["NuGet.Config", "."]

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/emilfilip3/_packaging/emilfilip3/nuget/v3/index.json\", \"username\":\"docker\", \"password\":\b461ee19-0e11-4e29-a84b-881602ea8e3e}]}"

RUN dotnet restore "EFSoft.Products.Api/EFSoft.Products.Api.csproj"
COPY . .
WORKDIR "/src/EFSoft.Products.Api"
RUN dotnet build "EFSoft.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Products.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Products.Api.dll"]