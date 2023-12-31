using System.Text;
using FinControl.API.Extensions;
using FinControl.Business.Interfaces;
using FinControl.Business.Interfaces.Repositories;
using FinControl.Business.Models;
using FinControl.Business.Models.Validations;
using FinControl.Business.Notifications;
using FinControl.Business.Services;
using FinControl.Data.Context;
using FinControl.Data.Repository;
using FinControl.Shared.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.LoadSettings();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Instance!.Secret);
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = Settings.Instance.Issuer,
            ValidAudience = Settings.Instance.Audience,
        };
    });
builder.Services.AddAuthorization();

DependecyInjection();

builder.Services.AddDbContext<FinControlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FinControlContext)))
        .UseLowerCaseNamingConvention());
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
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
    builder.Services.AddScoped<IGenericService<UserValidation, User>, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();

    builder.Services.AddScoped<IUserContext, UserContext>();
}