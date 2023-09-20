FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY src/Common.Constants/*.csproj src/Common.Constants/
COPY src/Common.DTO/*.csproj src/Common.DTO/
COPY src/Common.Extensions/*.csproj src/Common.Extensions/
COPY src/Common.Messaging/*.csproj src/Common.Messaging/
COPY src/Common.Middlewares/*.csproj src/Common.Middlewares/
COPY src/Common.Services/*.csproj src/Common.Services/
COPY src/Planning.API/*.csproj src/Planning.API/
COPY src/Planning.Business/*.csproj src/Planning.Business/
COPY src/Planning.Common/*.csproj src/Planning.Common/
COPY src/Planning.DataAccess/*.csproj src/Planning.DataAccess/
COPY src/Planning.Models/*.csproj src/Planning.Models/
COPY src/Planning.Translators/*.csproj src/Planning.Translators/


RUN dotnet restore src/Planning.API/Planning.API.csproj

# copy and build app and libraries
COPY src/Common.Constants/ src/Common.Constants/
COPY src/Common.DTO/ src/Common.DTO/
COPY src/Common.Extensions/ src/Common.Extensions/
COPY src/Common.Messaging/ src/Common.Messaging/
COPY src/Common.Middlewares/ src/Common.Middlewares/
COPY src/Common.Services/ src/Common.Services/
COPY src/Planning.API/ src/Planning.API/
COPY src/Planning.Common/ src/Planning.Common/
COPY src/Planning.DataAccess/ src/Planning.DataAccess/
COPY src/Planning.Business/ src/Planning.Business/
COPY src/Planning.Models/ src/Planning.Models/
COPY src/Planning.Translators/ src/Planning.Translators/

FROM build AS publish
WORKDIR /src/src/Planning.API
RUN dotnet publish -c Release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.14
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5057
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Planning.API.dll"]

RUN apk add --no-cache icu-libs
RUN apk add --no-cache curl


ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Local
