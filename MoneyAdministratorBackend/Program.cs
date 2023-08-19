using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyAdministratorBackend;
using MoneyAdministratorBackend.Data;
using MoneyAdministratorBackend.Interfaces;
using MoneyAdministratorBackend.Services;
using MoneyAdministratorBackend.Services.Security;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
StartupServices.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
StartupConfiguration.Configure(app);

app.Run();
