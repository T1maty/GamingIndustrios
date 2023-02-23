
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app


RUN apt-get update \
    && apt-get install -y postgresql postgresql-contrib \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*


FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye AS build
WORKDIR /src


COPY . .


RUN dotnet restore
RUN dotnet build -c Release -o /app/build


FROM base AS final
WORKDIR /app


COPY --from=build /app/build .


ENV PGHOST=<localhost>
ENV PGDATABASE=<GAMEDB3.1.3>
ENV PGUSER=<postgres>
ENV PGPASSWORD=<43215670Åà>


EXPOSE 80


ENTRYPOINT ["dotnet", "GamingIndustrios.dll"]
