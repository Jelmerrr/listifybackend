FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 44337

ENV ASPNETCORE_URLS=http://+:44337

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Listify-Backend/Listify-Backend.csproj", "./"]
RUN dotnet restore "Listify-Backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Listify-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Listify-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Listify-Backend.dll"]
