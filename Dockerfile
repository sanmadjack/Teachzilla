# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source
COPY --link *.sln .

COPY --link Teachzilla.Model/*.csproj ./Teachzilla.Model/
COPY --link Teachzilla/*.csproj ./Teachzilla/
RUN dotnet restore

COPY Teachzilla.Model/. ./Teachzilla.Model/
COPY Teachzilla/. ./Teachzilla/
WORKDIR /source/Teachzilla
RUN dotnet publish -c release --no-restore -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
VOLUME /db
ENV SQLITE_CONNECTION_STRING="Data Source=/db/teachzilla.db"
WORKDIR /app
COPY --link --from=build /app .
ENTRYPOINT ["./Teachzilla"]
