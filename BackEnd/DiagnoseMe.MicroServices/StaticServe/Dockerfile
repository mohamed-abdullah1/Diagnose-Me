FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5127

ENV ASPNETCORE_URLS=http://+:7199

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DiagnoseMe.MicroServices/StaticServe", "StaticServe/"]
RUN dotnet restore "StaticServe/StaticServe.csproj"
COPY . .
WORKDIR "/src/StaticServe"
RUN dotnet build "StaticServe.csproj" -c Release -o /app/build

FROM build AS final
WORKDIR /src/StaticServe
RUN dotnet dev-certs https --trust
COPY --from=build /src/StaticServe .
ENTRYPOINT ["dotnet", "run"]
