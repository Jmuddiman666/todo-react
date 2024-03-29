using Todo.Api.Interfaces.Repositories;
using Todo.Api.Interfaces.Services;
using Todo.Api.Repositories;
using Todo.Api.Services;
string AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
                         {
                             options.AddPolicy(AllowSpecificOrigins,
                                               policy =>
                                               {
                                                   policy.WithOrigins("https://localhost:3000",
                                                                      "http://localhost:3000",
                                                                      "https://ashy-sky-098133f03.1.azurestaticapps.net/")
                                                         .AllowAnyHeader()
                                                         .AllowAnyMethod();
                                               });
                             options.AddDefaultPolicy(config => { config.AllowAnyOrigin().AllowAnyMethod(); });
                         });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseRouting();
app.UseCors(AllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();