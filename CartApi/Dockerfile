FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52073
EXPOSE 44312

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . CartApi
RUN dotnet restore "CartApi/CartApi.csproj"
COPY . .
WORKDIR "/src/CartApi"
RUN dotnet build "CartApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CartApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CartApi.dll"]