using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using Ivanov_Denis_Evgenievich_KT_31_23.Data;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Инициализация приложения");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Добавляем сервисы контроллеров
    builder.Services.AddControllers();
    
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Настройка Swagger/OpenAPI
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Настройка HTTP конвейера (Pipeline)
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Остановка программы из-за исключения");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
