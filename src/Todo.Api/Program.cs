
using Todo.Api.Interfaces.Repositories;
using Todo.Api.Interfaces.Services;
using Todo.Api.Repositories;
using Todo.Api.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => { options.AddDefaultPolicy(config => { config.AllowAnyOrigin().AllowAnyMethod(); }); });

if (builder.Configuration.GetValue<string>("StoreType") == "Text")
    builder.Services.AddScoped<ITodoRepository, TodoTextRepository>();
else
    builder.Services.AddScoped<ITodoRepository, TodoPostgresRepository>();

builder.Services.AddScoped<ITodoService, TodoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();