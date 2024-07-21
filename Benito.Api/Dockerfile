#  imagen docker con .net 7.0

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY ./bin/Release/net7.0 .
 
EXPOSE 80
EXPOSE 5000
EXPOSE 443
RUN set ASPNETCORE_ENVIRONMENT=Staging

RUN dotnet dev-certs https
RUN dotnet dev-certs https -ep /usr/local/share/ca-certificates/aspnet/https.crt --format PEM
RUN update-ca-certificates

ENTRYPOINT ["dotnet", "Benito.Api.dll"]

