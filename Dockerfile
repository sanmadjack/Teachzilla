# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG TARGETARCH
WORKDIR /source

COPY --link Techzilla.Model/*.csproj ./model/
RUN dotnet restore -a $TARGETARCH

# Copy project file and restore as distinct layers
COPY --link Techzilla/*.csproj .
RUN dotnet restore -a $TARGETARCH

# Copy source code and publish app
COPY --link Techzilla/. .
RUN dotnet publish -a $TARGETARCH --no-restore -o /app


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
WORKDIR /app
COPY --link --from=build /app .
USER $APP_UID
ENTRYPOINT ["./aspnetapp"]