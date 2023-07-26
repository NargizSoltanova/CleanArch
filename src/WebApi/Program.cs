using practice.Application;
using practice.Infrastructure;
using practice.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

using IServiceScope scope = app.Services.CreateScope();
AppDbContextInitialiser initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
await initializer.InitializeAsync();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
