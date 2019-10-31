
FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY ./*.csproj .
RUN dotnet restore 
COPY . .
RUN dotnet publish  -c Release -o /dist

FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "Publisher.API.dll"]