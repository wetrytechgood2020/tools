#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster AS build
WORKDIR /src
COPY ["src/SuperUser.Promoter/SuperUser.Promoter.csproj", "src/SuperUser.Promoter/"]
RUN dotnet restore "src/SuperUser.Promoter/SuperUser.Promoter.csproj"
COPY . .
WORKDIR "/src/src/SuperUser.Promoter"
RUN dotnet build "SuperUser.Promoter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuperUser.Promoter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuperUser.Promoter.dll"]