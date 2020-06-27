#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["my-secured-app/my-secured-app.csproj", "my-secured-app/"]

RUN dotnet restore "my-secured-app/my-secured-app.csproj"
COPY . .
WORKDIR "/src/my-secured-app"
RUN dotnet build "my-secured-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "my-secured-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ExternalCert.pem /etc/ssl/certs/ExternalCert.pem
ENTRYPOINT ["dotnet", "my-secured-app.dll"]