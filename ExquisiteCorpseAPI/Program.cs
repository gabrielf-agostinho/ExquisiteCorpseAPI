using ExquisiteCorpseAPI;
using ExquisiteCorpseAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<Context>(options => options.UseSqlite("Data Source=Data/ExquisiteCorpse.db"));
DependencyInjector.Register(builder.Services);

var app = builder.Build();

ContextInitializer.Initialize(app.Services);

if (app.Environment.IsDevelopment())
  app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
