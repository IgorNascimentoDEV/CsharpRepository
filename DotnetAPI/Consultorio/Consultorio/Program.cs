using Consultorio.Context;
using Consultorio.Repository;
using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

//Capturando string de conex�o do appsettings
var connectionString = builder.Configuration.GetConnectionString("Default");

// Agora voc� pode configurar o DbContext usando a string de conex�o e o assembly de migra��es.
builder.Services.AddDbContext<ConsultorioContext>(options =>
{
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly(typeof(ConsultorioContext).Assembly.FullName));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
