#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SellerAPI/SellerAPI.csproj", "SellerAPI/"]
COPY ["SellerAPI.Data/SellerAPI.Data.csproj", "SellerAPI.Data/"]
COPY ["SellerAPI.Service/SellerAPI.Service.csproj", "SellerAPI.Service/"]
RUN dotnet restore "SellerAPI/SellerAPI.csproj"
COPY . .
WORKDIR "/src/SellerAPI"
RUN dotnet build "SellerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SellerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SellerAPI.dll"]
