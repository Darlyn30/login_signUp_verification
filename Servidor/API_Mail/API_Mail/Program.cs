using API_Mail.Context;
using API_Mail.Interfaces;
using API_Mail.Models;
using API_Mail.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppConnection");// agregamos la base de datos

// agregamos los contextos
builder.Services.AddDbContext<CuentasContext>(x => x.UseSqlServer(conn));
builder.Services.AddDbContext<SesionContext>(x => x.UseSqlServer(conn));
builder.Services.AddDbContext<TriggerContext>(x => x.UseSqlServer(conn));

builder.Services.AddTransient<ISend, MailService>();
builder.Services.AddScoped<ISesion, SesionService>();
builder.Services.AddScoped<ITrigger, TriggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowAnyOrigin();
});

app.MapControllers();

app.Run();
