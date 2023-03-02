FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7018

ENV ASPNETCORE_URLS=http://+:7018
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ConnectionStrings__DefaultConnection="Server=medicalservicesdb;Database=MedicalServicesDb;Uid=DiagnoseMe;Pwd=DiagnoseMe"
# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MedicalServices/MedicalServices.Api/MedicalServices.Api.csproj", "MedicalServices/MedicalServices.Api/"]
RUN dotnet restore "MedicalServices/MedicalServices.Api/MedicalServices.Api.csproj"
COPY . .
WORKDIR "/src/MedicalServices/MedicalServices.Api"
RUN dotnet build "MedicalServices.Api.csproj" -c Release -o /app/build

FROM build AS final
WORKDIR /src/MedicalServices/MedicalServices.Api
COPY --from=build /src/MedicalServices/MedicalServices.Api .
ENTRYPOINT ["dotnet", "run"]
