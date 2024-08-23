FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["InstrumentoT4E0_29.csproj", "./"]
RUN dotnet restore "./InstrumentoT4E0_29.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "InstrumentoT4E0_29.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstrumentoT4E0_29.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstrumentoT4E0_29.dll"]
