using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FinControlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FinControlContext))));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();