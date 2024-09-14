FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["examples/Nexalith.Example/Nexalith.Example.Api/Nexalith.Example.Api.csproj", "examples/Nexalith.Example/Nexalith.Example.Api/"]
COPY ["examples/Nexalith.Example/Nexalith.Example.Application/Nexalith.Example.Application.csproj", "examples/Nexalith.Example/Nexalith.Example.Application/"]
COPY ["examples/Nexalith.Example/Nexalith.Example.Domain/Nexalith.Example.Domain.csproj", "examples/Nexalith.Example/Nexalith.Example.Domain/"]
COPY ["src/Core/Nexalith.Domain/Nexalith.Domain.csproj", "src/Core/Nexalith.Domain/"]
COPY ["src/Core/Nexalith.Application/Nexalith.Application.csproj", "src/Core/Nexalith.Application/"]
COPY ["examples/Nexalith.Example/Nexalith.Example.Persistence/Nexalith.Example.Persistence.csproj", "examples/Nexalith.Example/Nexalith.Example.Persistence/"]
COPY ["src/Infrastructure/Persistence/Nexalith.Persistence.EntityFrameworkCore/Nexalith.Persistence.EntityFrameworkCore.csproj", "src/Infrastructure/Persistence/Nexalith.Persistence.EntityFrameworkCore/"]
COPY ["src/Presentation/Nexalith.Api/Nexalith.Api.csproj", "src/Presentation/Nexalith.Api/"]
RUN dotnet restore "examples/Nexalith.Example/Nexalith.Example.Api/Nexalith.Example.Api.csproj"
COPY . .
WORKDIR "/src/examples/Nexalith.Example/Nexalith.Example.Api"
RUN dotnet build "Nexalith.Example.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Nexalith.Example.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nexalith.Example.Api.dll"]
