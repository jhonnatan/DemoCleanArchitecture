FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DemoCleanArchitecture.WebApi/DemoCleanArchitecture.WebApi.csproj", "DemoCleanArchitecture.WebApi/"]
COPY ["DemoCleanArchitecture.Infrastructure/DemoCleanArchitecture.Infrastructure.csproj", "DemoCleanArchitecture.Infrastructure/"]
COPY ["DemoCleanArchitecture.Domain/DemoCleanArchitecture.Domain.csproj", "DemoCleanArchitecture.Domain/"]
COPY ["DemoCleanArchitecture.Application/DemoCleanArchitecture.Application.csproj", "DemoCleanArchitecture.Application/"]
RUN dotnet restore "DemoCleanArchitecture.WebApi/DemoCleanArchitecture.WebApi.csproj"
COPY . .
WORKDIR "/src/DemoCleanArchitecture.WebApi"
RUN dotnet build "DemoCleanArchitecture.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoCleanArchitecture.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoCleanArchitecture.WebApi.dll"]