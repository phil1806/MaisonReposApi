using AutoMapper;
using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injection de l'autoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Injection  des Services
builder.Services.AddScoped<IFonctionService, FonctionService>();


//Ici je fais appel à ma connectionString
builder.Services.AddDbContext<myDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));

});






//builder.Services.AddDbContext<myDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
//});

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
