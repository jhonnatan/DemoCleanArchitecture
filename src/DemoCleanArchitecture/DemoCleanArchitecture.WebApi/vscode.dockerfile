FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS debug
#EXPOSE 5000
#ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /src/
COPY ["DemoCleanArchitecture.WebApi/DemoCleanArchitecture.WebApi.csproj", "DemoCleanArchitecture.WebApi/"]
COPY ["DemoCleanArchitecture.Domain/DemoCleanArchitecture.Domain.csproj", "DemoCleanArchitecture.Domain/"]
COPY ["DemoCleanArchitecture.Infrastructure/DemoCleanArchitecture.Infrastructure.csproj", "DemoCleanArchitecture.Infrastructure/"]
COPY ["DemoCleanArchitecture.Application/DemoCleanArchitecture.Application.csproj", "DemoCleanArchitecture.Application/"]
RUN dotnet restore "DemoCleanArchitecture.WebApi/DemoCleanArchitecture.WebApi.csproj"
COPY . /src/
RUN mkdir /out/
RUN dotnet publish --no-restore "DemoCleanArchitecture.WebApi/DemoCleanArchitecture.WebApi.csproj" -c Release -o /out/
#install debugger for NET Core
RUN apt-get update
RUN apt-get install -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg
#Change to project directory
WORKDIR /src/DemoCleanArchitecture.WebApi
ENTRYPOINT ["dotnet","run","--urls","http://*:5000"]

###########START NEW IMAGE###########################################
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim as prod
RUN mkdir /app/
WORKDIR /app/
COPY --from=debug /out/ /app/
RUN chmod +x /app/ 
ENTRYPOINT ["dotnet", "DemoCleanArchitecture.WebApi.dll"]