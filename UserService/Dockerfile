# ----------------------
# STAGE 1: BUILD
# ----------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем csproj (важно: именно UserService.csproj)
COPY UserService.csproj ./
RUN dotnet restore

# Копируем остальные файлы проекта
COPY . .
RUN dotnet publish -c Release -o /app/out

# ----------------------
# STAGE 2: RUNTIME
# ----------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Копируем опубликованное приложение из build-стадии
COPY --from=build /app/out .

# Документируем порт этого сервиса (для людей)
EXPOSE 5003

# Точка входа — запускаем UserService
ENTRYPOINT ["dotnet", "UserService.dll"]