FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /API

ENV ASPNETCORE_ENVIRONMENT=Development

ENV DOTNET_EnableDiagnostics=0

# Build project
COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /API
COPY --from=build-env /API/out .
COPY /Products /API/Products

EXPOSE 8080

#degug:
RUN ls -al

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080 

ENTRYPOINT ["dotnet", "API.dll"]