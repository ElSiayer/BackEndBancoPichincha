FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development 
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BackEndBancoPichincha.csproj", "./"]
RUN dotnet restore "BackEndBancoPichincha.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "BackEndBancoPichincha.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BackEndBancoPichincha.dll"]