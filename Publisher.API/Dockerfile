FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Publisher.API.csproj"



COPY . .
WORKDIR "/src"
RUN dotnet build "Publisher.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Publisher.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Publisher.API.dll"]