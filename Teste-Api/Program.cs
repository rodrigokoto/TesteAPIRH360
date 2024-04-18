using Application.InterfaceServices;
using Application.Services;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

var connectionString = configuration.GetConnectionString("DefaultConnection");

InjectionDependency(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//});


builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(connectionString));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void InjectionDependency(WebApplicationBuilder builder)
{

    builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
    builder.Services.AddScoped<IPessoaService, PessoaService>();

}