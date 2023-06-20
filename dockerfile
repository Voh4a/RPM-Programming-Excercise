# FROM  mcr.microsoft.com/dotnet/sdk:5.0-buster-slim
# WORKDIR /app
# COPY . .
# RUN dotnet restore
# RUN dotnet publish -c release
# CMD dotnet run /app/bin/Release/net5.0/publish/RPM-Programming-Excercise.dll
FROM  mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as base
WORKDIR /app
EXPOSE 80

FROM  mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /src
COPY . .
RUN dotnet restore "RPM-Programming-Excercise.csproj"
RUN dotnet publish "RPM-Programming-Excercise.csproj" -c release -o /src/app/publish

FROM  build as final
WORKDIR /app
COPY --from=build /src/app/publish .
CMD dotnet RPM-Programming-Excercise.dll