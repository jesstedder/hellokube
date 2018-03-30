FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY HelloKube.core/*.csproj ./HelloKube.core/
COPY HelloKube.service/*.csproj ./HelloKube.service/
RUN dotnet restore HelloKube.core/*.csproj
RUN dotnet restore HelloKube.service/*.csproj

# copy and build everything else
COPY . ./
RUN dotnet publish HelloKube.service/*.csproj -c Release -o out

FROM microsoft/dotnet:2.1-runtime
COPY --from=build-env /app/HelloKube.service/out ./
ENTRYPOINT ["dotnet", "HelloKube.service.dll"]

