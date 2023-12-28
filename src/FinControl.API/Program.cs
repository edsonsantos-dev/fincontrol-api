using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Business.Notifications;
using FinControl.Business.Services;
using FinControl.Data.Context;
using FinControl.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INotifier, Notifier>();
builder.Services.AddScoped<IGenericService<TransactionValidation, Transaction>, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddDbContext<FinControlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FinControlContext))));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();