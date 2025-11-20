var builder = WebApplication.CreateBuilder(args);

// Подключаем контроллеры (они будут работать позже)
builder.Services.AddControllers();

// Подключаем OpenAPI/Swagger (для просмотра API в браузере)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// В режиме разработки включаем Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Убираем HTTPS (работаем по HTTP)
app.UseAuthorization();

// Подключаем маршрутизацию контроллеров
app.MapControllers();

app.Run();