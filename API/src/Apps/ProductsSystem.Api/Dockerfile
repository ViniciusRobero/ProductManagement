#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/ProductsSystem.Api/ProductsSystem.Api.csproj", "src/Apps/ProductsSystem.Api/"]
COPY ["src/Common/ProductsSystem.Infrastructure/ProductsSystem.Infrastructure.csproj", "src/Common/ProductsSystem.Api.Infrastructure/"]
COPY ["src/Common/ProductsSystem.Application/ProductsSystem.Application.csproj", "src/Common/ProductsSystem.Api.Application/"]
COPY ["src/Common/ProductsSystem.Domain/ProductsSystem.Domain.csproj", "src/Common/ProductsSystem.Api.Domain/"]
RUN dotnet restore "src/Apps/ProductsSystem.Api/ProductsSystem.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/ProductsSystem.Api"
RUN dotnet build "ProductsSystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsSystem.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsSystem.Api.dll"]