# ----------------------
# STAGE 1: BUILD
# ----------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем csproj (важно: имя файла именно OrderService.csproj)
COPY OrderService.csproj ./
RUN dotnet restore

# Копируем остальные файлы проекта
COPY . .
RUN dotnet publish -c Release -o /app/out

# ----------------------
# STAGE 2: RUNTIME
# ----------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Копируем опубликованное приложение из предыдущего stage
COPY --from=build /app/out .

# Документируем порт сервиса
EXPOSE 5002

# Точка входа — запускаем наш сервис
ENTRYPOINT ["dotnet", "OrderService.dll"]
