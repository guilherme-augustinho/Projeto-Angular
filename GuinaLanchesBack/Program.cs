using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GuinaLanchesBack.Model;
using GuinaLanchesBack.Services;
using Trevisharp.Security.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GuinaLanchesContext>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddSingleton<ISecurityService, SecurityService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(options => 
{
    options.AddPolicy("DefaultPolicy",
        policy => {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

// Crypto para jwt
builder.Services.AddSingleton<CryptoService>(p => new(){
    InternalKeySize = 24,
    UpdatePeriod = TimeSpan.FromDays(1)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
