using Consultorio.Context;
using Consultorio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailService, EmailService>();

//Capturando string de conexão do appsettings
var connectionString = builder.Configuration.GetConnectionString("Default");

// Agora você pode configurar o DbContext usando a string de conexão e o assembly de migrações.
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
