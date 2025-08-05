using WhatForToday.Application.Interfaces.Repositories;
using WhatForToday.Infrastructure.Persistence.Configuration.Services;
using WhatForToday.Infrastructure.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

//Db context
builder.Services.AddPersistence(builder.Configuration);

#region Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();