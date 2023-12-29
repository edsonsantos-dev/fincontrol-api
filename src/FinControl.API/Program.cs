using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Business.Notifications;
using FinControl.Business.Services;
using FinControl.Data.Context;
using FinControl.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependecyInjection();

builder.Services.AddDbContext<FinControlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FinControlContext)))
        .UseLowerCaseNamingConvention());
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

void DependecyInjection()
{
    builder.Services.AddScoped<INotifier, Notifier>();

    builder.Services.AddScoped<IGenericService<AccountValidation, Account>, AccountService>();
    builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
    builder.Services.AddScoped<IGenericService<CategoryValidation, Category>, CategoryService>();
    builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
    builder.Services.AddScoped<IGenericService<TransactionValidation, Transaction>, TransactionService>();
    builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IRepository<User>, UserRepository>();
}