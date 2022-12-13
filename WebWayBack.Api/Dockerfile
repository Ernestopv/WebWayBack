#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN curl --silent --location https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ["WebWayBack.Api/WebWayBack.Api.csproj", "WebWayBack.Api/"]
COPY ["WebWayBack.Filters/WebWayBack.Filters.csproj", "WebWayBack.Filters/"]
COPY ["WebWayBack.Models/WebWayBack.Models.csproj", "WebWayBack.Models/"]
COPY ["WebWayBack.Infrastructure/WebWayBack.Infrastructure.csproj", "WebWayBack.Infrastructure/"]
COPY ["WebWayBack.Services/WebWayBack.Services.csproj", "WebWayBack.Services/"]
COPY ["WebWayBack.ExternalServices/WebWayBack.ExternalServices.csproj", "WebWayBack.ExternalServices/"]
RUN dotnet restore "WebWayBack.Api/WebWayBack.Api.csproj"
COPY . .
WORKDIR "/src/WebWayBack.Api"
RUN dotnet build "WebWayBack.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebWayBack.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebWayBack.Api.dll"]