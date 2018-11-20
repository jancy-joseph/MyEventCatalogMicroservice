FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 57247
EXPOSE 44352

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . WebMVC
RUN dotnet restore WebMVC/WebMVC.csproj
COPY . .
WORKDIR /src/WebMVC
RUN dotnet build "WebMVC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebMVC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebMVC.dll"]