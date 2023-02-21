# Использовать образ ASP.NET 6 в качестве базового образа
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app

# Установить PostgreSQL
RUN apt-get update \
    && apt-get install -y postgresql postgresql-contrib \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# Использовать образ SDK ASP.NET 6 в качестве образа для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye AS build
WORKDIR /src

# Копировать исходный код приложения в образ
COPY . .

# Восстановить зависимости и собрать приложение
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# Использовать образ базового контейнера в качестве образа для запуска приложения
FROM base AS final
WORKDIR /app

# Копировать бинарный файл приложения в контейнер
COPY --from=build /app/build .

# Установить переменные среды для подключения к PostgreSQL
ENV PGHOST=<localhost>
ENV PGDATABASE=<GAMEDB3.1.3>
ENV PGUSER=<postgres>
ENV PGPASSWORD=<43215670Еа>

# Установить порт контейнера
EXPOSE 80

# Запустить приложение
ENTRYPOINT ["dotnet", "GamingIndustrios.dll"]
