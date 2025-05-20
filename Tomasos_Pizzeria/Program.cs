using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tomasos.Domain.Entities;
using Tomasos.Infrastructure;
using Tomasos.Infrastructure.Identity;
using Tomasos_Pizzeria.Data.Interfaces;
using Tomasos_Pizzeria.Data.Repos;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(opt =>
     {
         opt.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = "http://localhost:5077",
             ValidAudience = "http://localhost:5077",
             IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("privatekey197354%¤%#098713)%¤?913864%%%%##"))
         };
     });


builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Skriv 'Bearer <din-token>' för att autentisera.",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(

        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});



//builder.Services.AddDbContext<TomasosPizzeriaContext>(
//   options => options.UseSqlServer(
//       "Server=tcp:pizzeria.database.windows.net,1433;Initial Catalog=TomasosPizzeria;Persist Security Info=False;User ID=tomasospizzeria;Password=pizzeria123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
//       sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
//);

builder.Services.AddDbContext<TomasosPizzeriaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("Tomasos.Infrastructure") 


    )
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationUserContext>()
.AddDefaultTokenProviders();







builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
);


app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});






app.Run();
