FROM alpine
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Env variables
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_EnableDiagnostics=0

ENV UserName=user-service-user
ENV GroupName=non-root

# Setup not root user
RUN addgroup $GroupName
RUN adduser --ingroup $GroupName $UserName

USER $UserName

# Build Solution
WORKDIR /API

COPY --chown=$UserName . ./
RUN chmod -R 755 .

RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /API

COPY --chown=$UserName --from=build-env /API/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

#debug:
RUN ls -al

ENTRYPOINT ["dotnet", "API.dll"]