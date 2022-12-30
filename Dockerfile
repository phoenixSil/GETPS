#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GEPTS.Api/GEPTS.Api.csproj", "GEPTS.Api/"]
COPY ["GEPTS.Ioc/GEPTS.Ioc.csproj", "GEPTS.Ioc/"]
COPY ["GEPTS.Application/GEPTS.Application.csproj", "GEPTS.Application/"]
COPY ["GEPTS.Features/GEPTS.Features.csproj", "GEPTS.Features/"]
COPY ["GETPS.Api/GETPS.Domain.csproj", "GETPS.Api/"]
COPY ["GEPTS.Datas/GEPTS.Datas.csproj", "GEPTS.Datas/"]
RUN dotnet restore "GEPTS.Api/GEPTS.Api.csproj"
COPY . .
WORKDIR "/src/GEPTS.Api"
RUN dotnet build "GEPTS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GEPTS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GEPTS.Api.dll"]