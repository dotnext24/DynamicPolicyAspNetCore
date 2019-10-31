FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ./Consumer.API.csproj .
RUN dotnet restore "Consumer.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Consumer.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Consumer.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Consumer.API.dll"]