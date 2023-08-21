using NLog.Web;
using NLog;
using PracticaTicketManagement.Repositories;

using PracticaTicketManagement.Services;
using Microsoft.AspNetCore.Diagnostics;
using PracticaTicketManagement.Middleware;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddTransient<IEventRepository, EventRepository>();

    builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

    builder.Services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
    
    builder.Services.AddTransient<IOrderRepository, OrderRepository>();

    /*builder.Services.AddSingleton<ITestService, TestService>();*/
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:5174") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    /*app.UseHttpsRedirection();*/

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseAuthorization();

    app.MapControllers();
    app.UseCors();
    app.Run();
}

catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}