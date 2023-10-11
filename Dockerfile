#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ["NuGet.Config", ""]
#RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh

COPY ["EFSoft.Products.Api/EFSoft.Products.Api.csproj", "EFSoft.Products.Api/"]
COPY ["EFSoft.Products.Application/EFSoft.Products.Application.csproj", "EFSoft.Products.Application/"]
COPY ["EFSoft.Products.Domain/EFSoft.Products.Domain.csproj", "EFSoft.Products.Domain/"]
COPY ["EFSoft.Products.Infrastructure/EFSoft.Products.Infrastructure.csproj", "EFSoft.Products.Infrastructure/"]
#COPY ["NuGet.Config", ""]

ARG NUGET_PASSWORD
RUN apk add --update sed 
#RUN sed -i "s|</configuration>|<packageSourceCredentials><ProjectFeed><add key=\"Username\" value=\"PAT\"/><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\"/></ProjectFeed></packageSourceCredentials></configuration>|" nuget.config
#RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"PAT\"/><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\"/></emilfilip3></packageSourceCredentials></configuration>|" nuget.config

RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"emilfilip3\" /><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\" /></emilfilip3></packageSourceCredentials></configuration>|" NuGet.Config

#ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/emilfilip3/_packaging/emilfilip3/nuget/v3/index.json\", \"username\":\"emilfilip3\", \"password\":\"PAT\"}]}"

RUN dotnet restore "EFSoft.Products.Api/EFSoft.Products.Api.csproj" --configfile NuGet.Config

COPY . .
WORKDIR "/src/EFSoft.Products.Api"
RUN dotnet build "EFSoft.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Products.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Products.Api.dll"]