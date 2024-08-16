using DevFreela.API.ExceptionHandler;
using DevFreela.Application.Models;
using DevFreela.API.Services;
using DevFreela.Application;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FreeLanceTotalCostConfig>(
    builder.Configuration.GetSection("FreeLanceTotalCostConfig"));

// SAlva o valor e continua persistindo a cada requisição
   // builder.Services.AddSingleton<IConfigService, ConfigService>();

// renova a configuracao e cria uma nova a cada requisicao
    builder.Services.AddSingleton<IConfigService, ConfigService>();

//add injecao de dependencia
    builder.Services.AddApplication();

//Acesso a dados
   // builder.Services.AddDbContext<DevFreelaDbContext>(o => o.UseInMemoryDatabase("DevFreelaDB"));
   var conectionString = builder.Configuration.GetConnectionString("DevFreelaDB");

   builder.Services.AddDbContext<DevFreelaDbContext>(o => o.UseSqlServer(conectionString)); 
//Gerenciar as exceçoes
//builder.Services.AddExceptionHandler<ApiExceptionHandler>();
 builder.Services.AddProblemDetails();

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
//Usar as escecoes
app.UseExceptionHandler();

//fim


app.UseHttpsRedirection();

app.UseCors("*");

app.UseAuthorization();

app.MapControllers();

app.Run();


