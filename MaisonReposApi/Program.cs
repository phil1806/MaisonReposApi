using AutoMapper;
using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using MaisonReposApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injection de l'autoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Injection  des Services
builder.Services.AddScoped<IFonctionService, FonctionService>();
builder.Services.AddScoped<IAuthManagerService, AuthManagerService>();
builder.Services.AddScoped<IPersonnelService, PersonnelService>();
builder.Services.AddScoped<IResidantService, ResidantService>();
builder.Services.AddScoped<IResidantSuiviService, ResidantSuiviService>();
builder.Services.AddScoped<ICategorieDesSoinsService, CategorieDesSoinService>();
builder.Services.AddScoped<ISoinsAjoutService, SoinsAjoutService>();
builder.Services.AddScoped<IParametreService, ParametreService>();
builder.Services.AddScoped<IBaseInterfaceService<TrancheHoraire>, TrancheHoraireService>();
builder.Services.AddScoped<IBaseInterfaceService<Repas>, RepasService>();
builder.Services.AddScoped<IBaseInterfaceService<Toillette>, ToilletesService>();
builder.Services.AddScoped<IBaseInterfaceService<Selle>, SelleService>();
builder.Services.AddScoped<IBaseInterfaceService<Boisson>, BoissonService>();
builder.Services.AddScoped<IBaseInterfaceService<Therapie>, TherapieService>();
builder.Services.AddScoped<IBaseInterfaceService<TherapieTrancheHoraire>, TherapieTrancheHoraireService>();
builder.Services.AddScoped<IBaseInterfaceService<SoinsAjoutResidantSuivi>, SoinsAjout_ResidantSuiviService>();


//Ici je fais appel ? ma connectionString
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));

});


//Expliquer ? l'aplication comme valider le token 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    Options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value
             ))
        };
    }
);


//Mise en Place des Cors
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
