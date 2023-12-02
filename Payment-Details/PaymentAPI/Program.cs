using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
//Add Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
);
try
{
    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(options =>
    options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );

    app.UseAuthorization();

    app.MapControllers();
    Log.Information("Application Starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, ("Application start-up failed"));
}
finally
{
    Log.CloseAndFlush();
}