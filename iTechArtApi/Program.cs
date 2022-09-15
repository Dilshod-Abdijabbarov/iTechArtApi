using iTechArtApi.Data;
using iTechArtApi.IRepositories;
using iTechArtApi.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DatabaseContext>(context => 
context.UseSqlServer(
    builder.Configuration.GetConnectionString("DatabaseConnectionName")
    ));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddScoped<IXmlRepository, XmlRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
