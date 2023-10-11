#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh

COPY ["EFSoft.Products.Api/EFSoft.Products.Api.csproj", "EFSoft.Products.Api/"]
COPY ["EFSoft.Products.Application/EFSoft.Products.Application.csproj", "EFSoft.Products.Application/"]
COPY ["EFSoft.Products.Domain/EFSoft.Products.Domain.csproj", "EFSoft.Products.Domain/"]
COPY ["EFSoft.Products.Infrastructure/EFSoft.Products.Infrastructure.csproj", "EFSoft.Products.Infrastructure/"]
COPY ["NuGet.Config", ""]

ARG PAT
#RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"PAT\" /><add key=\"ClearTextPassword\" value=\"${PAT}\" /></emilfilip3></packageSourceCredentials></configuration>|" NuGet.Config

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/emilfilip3/_packaging/emilfilip3/nuget/v3/index.json\", \"username\":\"emilfilip3\", \"password\":\"PAT\"}]}"

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