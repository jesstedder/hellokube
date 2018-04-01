FROM microsoft/aspnetcore-build:2.1.300-preview1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY HelloKube.core/*.csproj ./HelloKube.core/
COPY HelloKube.web/*.csproj ./HelloKube.web/
RUN dotnet restore HelloKube.core/*.csproj
RUN dotnet restore HelloKube.web/*.csproj

# copy and build everything else
COPY . ./
RUN dotnet publish HelloKube.web/*.csproj -c Release -o out

FROM microsoft/aspnetcore:2.1.0-preview1
COPY --from=build-env /app/HelloKube.web/out ./

ENTRYPOINT ["dotnet", "HelloKube.web.dll"]

