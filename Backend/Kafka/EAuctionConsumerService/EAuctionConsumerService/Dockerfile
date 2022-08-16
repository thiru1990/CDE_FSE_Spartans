#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EAuctionConsumerService/EAuctionConsumerService.csproj", "EAuctionConsumerService/"]
RUN dotnet restore "EAuctionConsumerService/EAuctionConsumerService.csproj"
COPY . .
WORKDIR "/src/EAuctionConsumerService"
RUN dotnet build "EAuctionConsumerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EAuctionConsumerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EAuctionConsumerService.dll"]
